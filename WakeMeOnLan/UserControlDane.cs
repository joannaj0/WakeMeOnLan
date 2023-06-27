using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using EasyWakeOnLan;
using System.Globalization;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace WakeMeOnLan
{
    public partial class UserControlDane : UserControl
    {
        //string mask;
        int port;
        public UserControlDane()
        {
            InitializeComponent();
        }

        public UserControlDane(int stan, string adresIP, string adresMAC,string maska)
        {
            InitializeComponent();
            labelInfoPort.Text = "";
            //mask = maska;
            if (stan == 0)
            {
                buttonStan.BackColor = Color.Red;
            }
            else if (stan == 1)
            {
                buttonStan.BackColor = Color.Green;
            }
            else
            {
                buttonStan.BackColor = Color.Yellow;
            }
            labelAdresIPU.Text = adresIP;
            labelAdresMACU.Text = adresMAC;
        }

        private void buttonBudzenie_Click(object sender, EventArgs e)
        {
            buttonBudzenie.Enabled = false;
            textBoxPort.Visible = true;
            buttonOK.Visible = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            port = int.Parse(textBoxPort.Text);
            if (port > 0 && port <= 65535)
            { 
                buttonStan.BackColor = Color.Green;
                buttonBudzenie.Enabled = true;
                textBoxPort.Visible = false;
                buttonOK.Visible = false;
                var dc = DataContextSingleton.GetInstance();
                var si = dc.Sieci.FirstOrDefault(x => x.Adres_IP == labelAdresIPU.Text && x.Adres_MAC == labelAdresMACU.Text);
                if (si != null)
                {
                    si.Czy_obudzony = 1;
                    dc.SubmitChanges();
                }

                //var wolClient = new EasyWakeOnLanClient();
                //wolClient.Wake(labelAdresMACU.Text);

                //IPAddress IP = IPAddress.Parse("192.168.17.255");  
                IPAddress IP = IPAddress.Parse(labelAdresIPU.Text);
                IPEndPoint target = new IPEndPoint(IP, port);
                byte[] macAddress = Encoding.ASCII.GetBytes(labelAdresMACU.Text);
                MagicPacket.Send(target, macAddress);
                
            }
            else
            {
                labelInfoPort.ForeColor = Color.Red;
                labelInfoPort.Text = "Błędny numer portu. ";
            }


            /*var macAddress = labelAdresMACU.Text;                     
            macAddress = Regex.Replace(macAddress, "[-|:]", "");      
            var sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            {
                EnableBroadcast = true
            };

            int payloadIndex = 0;

            byte[] payload = new byte[1024];

            for (int i = 0; i < 6; i++)
            {
                payload[payloadIndex] = 255;
                payloadIndex++;
            }

            for (int j = 0; j < 16; j++)
            {
                for (int k = 0; k < macAddress.Length; k += 2)
                {
                    var s = macAddress.Substring(k, 2);
                    payload[payloadIndex] = byte.Parse(s, NumberStyles.HexNumber);
                    payloadIndex++;
                }
            }

            sock.SendTo(payload, new IPEndPoint(IPAddress.Parse(mask), 0));
            sock.Close(10000);*/
        }
    }
}
