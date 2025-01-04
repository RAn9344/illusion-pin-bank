using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Net.Mail;





namespace IllusionPin
{
    public partial class UserHome : Form
    {


        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\IllusionPin\IllusionPin\illusiontb.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd;

        public string accno,bal;

        public UserHome()
        {
            InitializeComponent();
        }


        string mobile, mail;

        private void UserHome_Load(object sender, EventArgs e)
        {
            label2.Text = accno;


            con.Open();
            cmd = new SqlCommand("select * from regtb where Accno='" + accno + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                bal = dr["Balance"].ToString();

                mobile = dr["Mobile"].ToString();
                mail = dr["Email"].ToString();

            }
            else
            {


            }
            con.Close();

        }


        decimal balance, amt;

        private void button2_Click(object sender, EventArgs e)
        {




            if (textBox2.Text == "")
            {

                MessageBox.Show("Enter Otp");

            }
            else
            {




                if (textBox2.Text == otp)
                {
                    balance = Convert.ToDecimal(bal);

                    amt = Convert.ToDecimal(textBox1.Text);

                    if (balance >= amt)
                    {
                        balance = balance - amt;


                        cmd = new SqlCommand("update regtb set Balance='" + balance + "' where Accno='" + accno + "'  ", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                        cmd = new SqlCommand("insert into transtb values('" + accno + "','Transaction','" + comboBox3.Text + "','" + textBox1.Text + "','" + System.DateTime.Now.ToShortDateString() + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Transaction Completed!");
                    }
                    else
                    {
                        MessageBox.Show("Balance Low");

                    }
                }

                else
                {
                    MessageBox.Show("OTP Incorrect");

                }

            }



        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deposit dd = new Deposit();
            dd.accno = accno;
            dd.Show();

        }

        private void withrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Withraw ww = new Withraw();
            ww.accno = accno;
            ww.Show();

        }

        private void satementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Satement ss = new Satement();
            ss.accno = accno;
            ss.Show();

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Satement ss = new Satement();
            ss.Close();


            Withraw ww = new Withraw();
            ww.Close();

            Deposit dd = new Deposit();
            dd.Close();


            Form1 ff = new Form1();
            ff.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";


        }


        string otp;


        private void button1_Click(object sender, EventArgs e)
        {


            Random rr = new Random();
            int i = rr.Next(1111, 9999);

            otp =i.ToString();


            sendmessage(mobile, "OTP :" + i.ToString());
            
            
            
            string to = mail;

            string from = "sampletest685@gmail.com";
            // string subject = "Key";
            // string body = TextBox1.Text;
            string password = "hneucvnontsuwgpj";
            using (MailMessage mm = new MailMessage(from, to))
            {
                mm.Subject = "OTP";
                mm.Body = "OTP :" + i.ToString();


                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(from, password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                MessageBox.Show("Mail Send!");

            }

            


        }

        public void sendmessage(string targetno, string message)
        {

            String query = "http://smsserver9.creativepoint.in/api.php?username=fantasy&password=596692&to=" + targetno + "&from=FSSMSS&message=Dear user  your msg is " + message + " Sent By FSMSG FSSMSS &PEID=1501563800000030506&templateid=1507162882948811640";

            WebClient client = new WebClient();
            Stream sin = client.OpenRead(query);
            MessageBox.Show("Message send");
           
        }
    }
}
