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


namespace WakeMeOnLan
{
    public partial class Form1 : Form
    {

        string nazwa;
        string adresIP;
        int stan=0;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nic = NetworkInterface.GetAllNetworkInterfaces();
            Console.WriteLine("Ilosc: {0} ", nic.Length);
            Console.WriteLine();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    Console.WriteLine(ni.Name);
                    Console.WriteLine(ni.GetPhysicalAddress().ToString());
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            Console.WriteLine(ip.Address.ToString());
                            Console.WriteLine(ip.IPv4Mask.ToString());
                        }
                    }
                }
               Console.WriteLine();
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

            Console.WriteLine("-----");
            string MACadres;
            int[] tablica = new int[] {80,443};
            for (int i = 0; i < 20; i++)
            {
                string numer = "192.168.5.";
                numer += i;
                foreach (int value in tablica)
                {
                    if (IsHostUp(numer, value) == true)
                    {
                        MACadres = "xxx";
                        Console.WriteLine("Status: Success \n Port:" + value + " \n Adres IP: " + numer + " \n Adres MAC : " + MACadres);
                        Console.WriteLine();
                        adresIP = numer;
                        stan = 1;
                        UserControlDane userControl = new UserControlDane(stan, adresIP, MACadres);
                        flowLayoutPanel.Controls.Add(userControl);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Status: - \n Port:" + value + " \n Adres IP: " + numer);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
 }
