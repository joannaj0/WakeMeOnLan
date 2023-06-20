using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace WakeMeOnLan
{
    public partial class Form1 : Form
    {

        string nazwa;
        string adresIP;
        int stan = 0;
        public Form1()
        {
            InitializeComponent();
        }

        public static bool IsHostUp(string hostNameOrAddress, int port)
        {
            var client = new TcpClient();
            if (!client.ConnectAsync(hostNameOrAddress, port).Wait(1000))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);

        public static string GetMacAddress(string ipAddress)
        {
            IPAddress IP = IPAddress.Parse(ipAddress);
            byte[] macAddr = new byte[6];
            uint macAddrLen = (uint)macAddr.Length;
            if (SendARP(BitConverter.ToInt32(IP.GetAddressBytes(), 0), 0, macAddr, ref macAddrLen) != 0)
                throw new InvalidOperationException("SendARP failed.");
            string[] str = new string[(int)macAddrLen];
            for (int i = 0; i < macAddrLen; i++)
                str[i] = macAddr[i].ToString("x2");
            return string.Join("-", str);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonSkanuj_Click(object sender, EventArgs e)
        {
            flowLayoutPanel.Controls.Clear();
            var dc = DataContextSingleton.GetInstance();

            var sieci1 = dc.Sieci.ToList();

            foreach (var siec1 in sieci1)
            {
                siec1.Czy_byl = 0;
            }
            dc.SubmitChanges();

            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nic = NetworkInterface.GetAllNetworkInterfaces();
            //Console.WriteLine("Ilosc: {0} ", nic.Length);
            //Console.WriteLine();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    //Console.WriteLine(ni.Name);
                    //Console.WriteLine(ni.GetPhysicalAddress().ToString());
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            //Console.WriteLine(ip.Address.ToString());
                            //Console.WriteLine(ip.IPv4Mask.ToString());
                        }
                    }
                }
                //Console.WriteLine();
            }

            /*Console.WriteLine("-----");
            for (int i = 0; i < 20; i++)
            {
                string numer="192.168.17.";
                numer += i;
                try
                {
                    Ping myPing = new Ping();
                    PingReply reply = myPing.Send(numer, 1000);
                    Console.WriteLine("Adres hosta: " + numer);
                    if (reply != null)
                    {
                       Console.WriteLine("Status :  " + reply.Status + " \n Address : " + reply.Address);
                       Console.WriteLine();

                    }
                }
                catch
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine();
                }
            }*/

            //Console.WriteLine("-----");
            string adresMAC;
            int[] tablica = new int[] { 80, 443 };
            for (int i = 0; i < 20; i++)
            {
                string numer = "192.168.5.";
                numer += i;
                foreach (int value in tablica)
                {
                    if (IsHostUp(numer, value) == true)
                    {
                        adresMAC = GetMacAddress(numer);
                        //Console.WriteLine("Status: Success \n Port:" + value + " \n Adres IP: " + numer + " \n Adres MAC : " + MACadres);
                        //Console.WriteLine();
                        adresIP = numer;
                        stan = 1;
                        bool exists = dc.Sieci.Any(s => s.Adres_IP == adresIP && s.Adres_MAC == adresMAC);
                        if (!exists)
                        {
                            var s = new Siec
                            {
                                Adres_IP = adresIP,
                                Adres_MAC = adresMAC,
                                Czy_obudzony = stan,
                                Czy_byl = 1
                            };
                            dc.Sieci.InsertOnSubmit(s);
                            dc.SubmitChanges();
                        }
                        else
                        {
                             var s = dc.Sieci.FirstOrDefault(x => x.Adres_IP == adresIP && x.Adres_MAC == adresMAC);
                             if (s != null)
                             {
                                s.Czy_byl = 1;
                                dc.SubmitChanges();
                             }      
                        }
                        break;
                    }
                    else
                    { 
                        //Console.WriteLine("Status: - \n Port:" + value + " \n Adres IP: " + numer);
                        //Console.WriteLine();
                    }
                }
            }


            var sieci2 = dc.Sieci.ToList();
            foreach (var siec2 in sieci2)
            {
                if (siec2.Czy_byl == 1)
                {
                    siec2.Czy_obudzony = 1; 
                }
                else
                {
                    siec2.Czy_obudzony = 0;
                }
                    
            }
            dc.SubmitChanges();

            var sieci3 = dc.Sieci.ToList();
            foreach (var siec3 in sieci3)
            {
                string adres_IP = siec3.Adres_IP;
                string adres_MAC = siec3.Adres_MAC;
                int stan = siec3.Czy_obudzony;
                int czy_byl = siec3.Czy_byl;

                UserControlDane userControl = new UserControlDane(stan, adres_IP, adres_MAC);
                flowLayoutPanel.Controls.Add(userControl);
            }
        }
    }
 }
