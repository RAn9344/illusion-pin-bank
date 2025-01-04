using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;

namespace IllusionPin
{
    public partial class NewPin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\IllusionPin\IllusionPin\illusiontb.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        public string id, pass;
        public NewPin()
        {
            InitializeComponent();
        }

        private void NewPin_Load(object sender, EventArgs e)
        {
            label4.Text = id;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 6)
            {

              

                if (textBox1.Text == textBox2.Text)
                {
                    cmd = new SqlCommand("select * from regtb where userid='" + id + "' and Password='" + pass + "'", con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {


                        dr.Close();


                        string ss = Encrypt(textBox1.Text);

                        cmd = new SqlCommand("Update regtb set Pin='" + ss + "' where userid='" + id + "' and Password='" + pass + "'", con);
                        cmd.ExecuteNonQuery();


                        LoginType ii = new LoginType();
                        ii.id = id;
                        ii.pass = pass;
                        ii.pin = textBox1.Text;
                        ii.Show();


                    }
                    else
                    {

                        MessageBox.Show("UserName Or Password Incorrect!");

                    }


                    con.Close();
                }

                else
                {
                    MessageBox.Show("Password mismatch!");
                }

            }
            else
            {

                MessageBox.Show("Please enter 6 digit Pin");

            }






        }


        


        private string Encrypt(string clearText)
        {
            string ECC = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ECC, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";


        }


    }
}
