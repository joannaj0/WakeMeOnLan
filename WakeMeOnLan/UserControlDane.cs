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
        //string maska;
        int port;
        public UserControlDane()
        {
            InitializeComponent();
            buttonStan.BackColor = Color.White;
            labelAdresIPU.Text = "";
            labelAdresMACU.Text = "";
            buttonBudzenie.Enabled = false;
            buttonOK.Visible = false;
            textBoxPort.Visible = false;
            labelInfoPort.Text = "";
        }

        public UserControlDane(int stan, string adresIP, string MACadres,string m)
        {
            //maska = m;
            InitializeComponent();
            if (stan == 0)
            {
                buttonStan.BackColor = Color.Red;
                buttonBudzenie.Enabled = true;
            }
            else if (stan == 1)
            {
                buttonStan.BackColor = Color.Green;
                buttonBudzenie.Enabled = true;
            }
            else
            {
                buttonStan.BackColor = Color.Yellow;
                buttonBudzenie.Enabled = true;
            }
            labelAdresIPU.Text = adresIP;
            labelAdresMACU.Text = MACadres;
        }

        private void buttonBudzenie_Click(object sender, EventArgs e)
        {
            textBoxPort.Visible = true;
            buttonOK.Visible = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            //var wolClient = new EasyWakeOnLanClient();
            //wolClient.Wake(labelAdresMACU.Text);

            port = int.Parse(textBoxPort.Text);
            if (port > 0 && port <= 65535)
            { 
                buttonStan.BackColor = Color.Green;
                buttonBudzenie.Enabled = false;
                var dc = DataContextSingleton.GetInstance();
                var si = dc.Sieci.FirstOrDefault(x => x.Adres_IP == labelAdresIPU.Text && x.Adres_MAC == labelAdresMACU.Text);
                if (si != null)
                {
                    si.Czy_obudzony = 1;
                    dc.SubmitChanges();
                }

                //IPAddress IP = IPAddress.Parse("192.168.17.255");  
                IPAddress IP = IPAddress.Parse(labelAdresIPU.Text);
                IPEndPoint target = new IPEndPoint(IP, port);
                byte[] macAddress = Encoding.ASCII.GetBytes(labelAdresMACU.Text);
            }
            else
            {
                labelInfoPort.Text = "Błędny numer portu";
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

            sock.SendTo(payload, new IPEndPoint(IPAddress.Parse(maska), 0));  // Broadcast our packet
            sock.Close(10000);*/
        }
    }
}
