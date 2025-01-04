using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IllusionPin
{
    public partial class BankHome : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\IllusionPin\IllusionPin\illusiontb.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd;


        public BankHome()
        {
            InitializeComponent();
        }

        private void BankHome_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        //nonnumberenter = true;
                        string abc = "Please enter numbers only.";
                        textBox5.Text = "";

                        DialogResult result1 = MessageBox.Show(abc.ToString(), "Validate numbers", MessageBoxButtons.OK);
                    }
                }
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                //nonnumberenter = true;
                string abc = "Please enter numbers only.";
                DialogResult result1 = MessageBox.Show(abc.ToString(), "Validate numbers", MessageBoxButtons.OK);

            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, pattern))
            {
                //MessageBox.Show("Valid Email address ");
            }
            else
            {
                textBox4.Text = "";

                MessageBox.Show("Not a valid Email address ");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int age = DateTime.Today.Year - dateTimePicker1.Value.Year;

            textBox3.Text = age.ToString();


            if (age < 18)
            {
                //MessageBox.Show("Age Limit Low!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string gender;
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }




            cmd = new SqlCommand("select * from  regtb where Accno ='" + comboBox1.Text + "' or UserId='" + textBox9.Text + "'   ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                MessageBox.Show("Already Register This userid or Account Number");



            }
            else
            {


                dr.Close();

                cmd = new SqlCommand("insert into regtb values(@Accno,@FirstName,@LastName,@Gender,@Dob,@Age,@MobileNo,@Email,@Address,@AadharNo,@UserId,@Password,@Pin,@Balance)", con);
                cmd.Parameters.AddWithValue("@Accno", comboBox1.Text);
                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Dob", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Age", textBox3.Text);
                cmd.Parameters.AddWithValue("@MobileNo", textBox4.Text);
                cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                cmd.Parameters.AddWithValue("@Address", textBox6.Text);
                cmd.Parameters.AddWithValue("@AadharNo", textBox7.Text);
                cmd.Parameters.AddWithValue("@UserId", textBox8.Text);
                cmd.Parameters.AddWithValue("@Password", textBox9.Text);
                cmd.Parameters.AddWithValue("@Pin", "");
                cmd.Parameters.AddWithValue("@Balance", textBox11.Text);
               
                cmd.ExecuteNonQuery();
             
                MessageBox.Show("Record Save!");



              
              

            }
            con.Close();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox11.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";


            
        }

        private void userDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDetails uu = new UserDetails();
            uu.Show();

        }

        private void statementinfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statementinfo ss = new Statementinfo();
            ss.Show();
        }
    }
}
