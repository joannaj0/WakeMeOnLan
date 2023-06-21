using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WakeMeOnLan
{
    public partial class UserControlDane : UserControl
    {
        public UserControlDane()
        {
            InitializeComponent();
            buttonStan.BackColor = Color.White;
            labelAdresIPU.Text = "";
            labelAdresMACU.Text = "";
            buttonBudzenie.Enabled = false;
        }

        public UserControlDane(int stan, string adresIP, string MACadres)
        {
            InitializeComponent();
            if(stan==0)
            {
                buttonStan.BackColor = Color.Red;
                buttonBudzenie.Enabled = true;
            }
            else if(stan == 1)
            {
                buttonStan.BackColor = Color.Green;
                buttonBudzenie.Enabled = false;
            }
            else
            {
                buttonStan.BackColor = Color.Yellow;
                buttonBudzenie.Enabled = false;
            }
            labelAdresIPU.Text = adresIP;
            labelAdresMACU.Text = MACadres;
        }

        private void buttonBudzenie_Click(object sender, EventArgs e)
        {
            buttonStan.BackColor = Color.Green;
            buttonBudzenie.Enabled = false;
            var dc = DataContextSingleton.GetInstance();
            var s = dc.Sieci.FirstOrDefault(x => x.Adres_IP == labelAdresIPU.Text && x.Adres_MAC == labelAdresMACU.Text);
            if(s != null)
            {
                s.Czy_obudzony = 1;
                dc.SubmitChanges();
            }
        }
    }
}
