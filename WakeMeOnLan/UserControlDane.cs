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
            else
            {
                buttonStan.BackColor = Color.Green;
                buttonBudzenie.Enabled = false;
            }
            labelAdresIPU.Text = adresIP;
            labelAdresMACU.Text = MACadres;
        }

        private void UserControlDane_Load(object sender, EventArgs e)
        {

        }

        private void buttonBudzenie_Click(object sender, EventArgs e)
        {
            buttonStan.BackColor = Color.Green;
            buttonBudzenie.Enabled = false;
        }
    }
}
