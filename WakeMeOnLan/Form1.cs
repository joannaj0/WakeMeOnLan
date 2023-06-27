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
using IPAddresses;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WakeMeOnLan
{
    public partial class Form1 : Form
    {
        private Thread watekSkanuj;
 
        string adresMAC;
        string adresIP;
        int stan = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public static bool IsHostUp(string hostNameOrAddress, int port)
        {
            var client = new TcpClient();
            if (!client.ConnectAsync(hostNameOrAddress, port).Wait(500))
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

        static bool SprawdzCzyOk(string adres)
        {
            string wzorzec = @"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$";
            return Regex.IsMatch(adres, wzorzec);
        }

        public List<string> DajNumeryPortow(string tekst)
        {
            List<string> numery = new List<string>(tekst.Split(','));
            return numery;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            flowLayoutPanel.Visible = false;
            labelAdresIP.Visible = false;
            labelAdresMAC.Visible = false;
            labelStan.Visible = false;
            buttonAnuluj.Enabled = false;
            labelInfoAdresy.Text = "";
        }

        public void SkanujPodsiec()
        {
            //flowLayoutPanel.Invoke(new Action(() => {
            //    buttonAnuluj.Enabled = true;
            //}));

            listView.Invoke(new Action(() => {
                listView.View = View.Details;
                listView.GridLines = true;
                listView.FullRowSelect = true;

                buttonAnuluj.Enabled = true;
                buttonSkanuj.Enabled = false;
            }));

            //flowLayoutPanel.Invoke(new Action(() => { flowLayoutPanel.Controls.Clear();}));

            listView.Invoke(new Action(() => { listView.Items.Clear();}));

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
                            if (ni.Name == "Wi-Fi" && (textBoxAdresIP.Text == "" || textBoxMaska.Text == "" || textBoxPorty.Text == ""))
                            {
                                flowLayoutPanel.Invoke(new Action(() => {
                                    textBoxMaska.Text = ip.IPv4Mask.ToString();
                                    textBoxAdresIP.Text = ip.Address.ToString();
                                    textBoxPorty.Text = "80";
                                }));
                            }
                        }
                    }
                }

                //Console.WriteLine();

            }

            List<string> numeryPortow = DajNumeryPortow(textBoxPorty.Text);

            if (SprawdzCzyOk(textBoxMaska.Text) == true && SprawdzCzyOk(textBoxAdresIP.Text) == true)
            {
                labelInfoAdresy.Text = "";
                List<IPAddress> IpAddressList = IpAdressesClass.GetUsableIPForSubnet(textBoxAdresIP.Text, textBoxMaska.Text);

                //foreach (IPAddress IpAddress in IpAddressList)
                //{
                //    Console.WriteLine(IpAddress);
                //}

                foreach (IPAddress IpAddress in IpAddressList)
                {
                    foreach (string port in numeryPortow)
                    {
                        if (int.Parse(port) < 0 || int.Parse(port) > 65535)
                        {
                            continue;
                        }
                        else
                        {
                            //Console.WriteLine("Status: *** \n Port:" + port + " \n Adres IP: " + IpAddress.ToString());
                            //Console.WriteLine();

                            if (IsHostUp(IpAddress.ToString(), int.Parse(port)) == true)
                            {
                                adresMAC = GetMacAddress(IpAddress.ToString());

                                Console.WriteLine("Status: Success \n Port:" + port + " \n Adres IP: " + IpAddress.ToString() + " \n Adres MAC : " + adresMAC);
                                Console.WriteLine();

                                adresIP = IpAddress.ToString();
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
                                Console.WriteLine("Status: - \n Port:" + port + " \n Adres IP: " + IpAddress.ToString());
                                Console.WriteLine();
                            }
                        }
                    }
                }

                var sieci2 = dc.Sieci.ToList();
                foreach (var siec2 in sieci2)
                {
                    string przed_obcieciem = siec2.Adres_IP;
                    char[] ktore_sa = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    string po_obcieciu = przed_obcieciem.TrimEnd(ktore_sa);
                    string adresIP_pocz = textBoxAdresIP.Text.TrimEnd(ktore_sa);

                    //Console.WriteLine(po_obcieciu);

                    if (siec2.Czy_byl == 1)
                    {
                        siec2.Czy_obudzony = 1;
                    }
                    else if (po_obcieciu != adresIP_pocz)
                    {
                        siec2.Czy_obudzony = 2;
                    }
                    else
                    {
                        siec2.Czy_obudzony = 0;
                    }

                }
                dc.SubmitChanges();

                listView.Invoke(new Action(() => {
                      //listView.Columns.Add("Stan", listView.Width/3);
                        listView.Columns.Add("Adres IP", listView.Width/2);
                        listView.Columns.Add("Adres MAC", listView.Width/2);
                }));

                string[] dane = new string[2];
                ListViewItem item;

                var ContextMenuStrip = new ContextMenuStrip();
                var itemObudz = new ToolStripMenuItem("Obudź");

                itemObudz.Click += (sender, e) =>
                {
                    if (listView.FocusedItem != null)
                    {
                        string adres_IP = listView.FocusedItem.SubItems[0].Text;
                        string adres_MAC = listView.FocusedItem.SubItems[1].Text;
                        Obudz(adres_IP, adres_MAC, listView);
                    }
                };

                ContextMenuStrip.Items.Add(itemObudz);

                listView.MouseClick += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        if (listView.FocusedItem != null)
                        {
                            listView.FocusedItem.Selected = true;
                            ContextMenuStrip.Show(listView, e.Location);
                        }
                    }
                };

                var sieci3 = dc.Sieci.ToList();
                foreach (var siec3 in sieci3)
                {
                    string adres_IP = siec3.Adres_IP;
                    string adres_MAC = siec3.Adres_MAC;
                    int stan = siec3.Czy_obudzony;
                    int czy_byl = siec3.Czy_byl;

                    //UserControlDane userControl = new UserControlDane(stan, adres_IP, adres_MAC,textBoxMaska.Text);
                    //flowLayoutPanel.Invoke(new Action(() => {
                    //flowLayoutPanel.Controls.Add(userControl);
                    //}));

                    listView.Invoke(new Action(() => {

                        //arr[0] = stan.ToString();
                        dane[0] = adres_IP;
                        dane[1] = adres_MAC;

                        item = new ListViewItem(dane);
                        if(stan == 0)
                        {
                            item.BackColor = Color.Red;
                        }
                        else if(stan == 1)
                        {
                            item.BackColor = Color.Green;
                        }
                        else
                        {
                            item.BackColor = Color.Yellow;
                        }

                        listView.Items.Add(item);

                    }));
                }
            }
            else
            {
                labelInfoAdresy.ForeColor = Color.Red;
                labelInfoAdresy.Text = "Błędne dane adresu IP lub/i maski!";
            }

            if (watekSkanuj != null && watekSkanuj.IsAlive)
            {
                listView.Invoke(new Action(() => {
                    buttonAnuluj.Enabled = false;
                    buttonSkanuj.Enabled = true;
                }));
                watekSkanuj.Abort();
                watekSkanuj.Join(); 
            }
        }

        private void buttonSkanuj_Click(object sender, EventArgs e)
        {
            watekSkanuj = new Thread(SkanujPodsiec);
            watekSkanuj.Start();
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            if (watekSkanuj != null && watekSkanuj.IsAlive)
            {
                buttonAnuluj.Enabled = false;
                buttonSkanuj.Enabled = true;
                watekSkanuj.Abort();
                watekSkanuj.Join(); 
            }
        }

        private void Obudz(string adresIP, string adresMAC, System.Windows.Forms.ListView listView)
        {
            var dc = DataContextSingleton.GetInstance();
            var si = dc.Sieci.FirstOrDefault(x => x.Adres_IP == adresIP && x.Adres_MAC == adresMAC);
            if (si != null)
            {
                  si.Czy_obudzony = 1;
                  dc.SubmitChanges();
            }

            foreach (ListViewItem item in listView.Items)
            {
                if (item.SubItems[0].Text == adresIP && item.SubItems[1].Text == adresMAC)
                {
                    item.BackColor = Color.Green;
                    break;
                }
            }

            //IPAddress IP = IPAddress.Parse("192.168.17.255");  
            IPAddress IP = IPAddress.Parse(adresIP);
            IPEndPoint target = new IPEndPoint(IP, 40000);
            byte[] macAddress = Encoding.ASCII.GetBytes(adresMAC);
            MagicPacket.Send(target, macAddress);
        }
    }
 }
