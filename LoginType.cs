using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IllusionPin
{
    public partial class LoginType : Form
    {
        public string id, pass, pin;
        public LoginType()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Illusionpin ii = new Illusionpin();
            ii.id = id;
            ii.pass = pass;
            ii.pin = pin;
            ii.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            brightnessPin iii = new brightnessPin();
            iii.id = id;
            iii.pass = pass;
            iii.pin = pin;
            iii.Show();
        }
    }
}
