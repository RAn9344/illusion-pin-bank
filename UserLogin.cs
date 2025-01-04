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
    public partial class UserLogin : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\IllusionPin\IllusionPin\illusiontb.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd;

        public UserLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";



        }

        private void button1_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("select * from regtb where userid='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                if (dr["pin"].ToString() == "")
                {
                    NewPin ii = new NewPin();
                    ii.id = textBox1.Text;
                    ii.pass = textBox2.Text;

                    ii.Show();

                }
                else
                {

                    LoginType ii = new LoginType();
                    ii.id = textBox1.Text;
                    ii.pass = textBox2.Text;
                    ii.pin = Decrypt(dr["Pin"].ToString());
                    ii.Show();


                    //brightnessPin iii = new brightnessPin();
                    //iii.id = textBox1.Text;
                    //iii.pass = textBox2.Text;
                    //iii.pin =Decrypt( dr["Pin"].ToString());
                    //iii.Show();


                }

            }
            else
            {

                MessageBox.Show("UserName Or Password Incorrect!");

            }
            con.Close();
        }


        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

    }
}
