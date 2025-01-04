using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace IllusionPin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankLogin bb = new BankLogin();
            bb.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }


       
        public static Random r = new Random();
        public static int number;
        private void button4_Click(object sender, EventArgs e)
        {
            //work
            //if (textBox1.Text == "")
            //{
            //    //Response.Write("first enter you count number");

            //    MessageBox.Show("");
            //}
            //else
            //{
            //    number = Convert.ToInt32(textBox1.Text);
            //    List<int> available = new List<int>(number);
            //    for (int i = 1; i <= number; i++)
            //        available.Add(i);
            //    List<int> result = new List<int>(number);
            //    while (available.Count > 0)
            //    {
            //        int index = r.Next(available.Count);
            //        result.Add(available[index]);
            //        available.RemoveAt(index);
            //    }

            //    listBox1.Items.Clear();
            //    for (int i = 0; i < result.Count; i++)
            //    {
            //       // Response.Write(result[i] + "-");

            //        listBox1.Items.Add(result[i].ToString());
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserLogin ll = new UserLogin();
            ll.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Random rr = new Random();
            int i = rr.Next(0, 9);
           // label2.Text = i.ToString();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {

            label2.Text = ComputeSha256Hash(label3.Text);

            label4.Text = ComputeSha256Hash(label2.Text);


        }

        public static string base64Decode(string sData) //Decode    
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            byte[] data = Convert.FromBase64String(textBox1.Text); // decrypt the incrypted text
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox2.Text = UTF8Encoding.UTF8.GetString(results);
                }
            }
        }
        string hash = "1234";

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(textBox2.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox1.Text = Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        
    }
}
