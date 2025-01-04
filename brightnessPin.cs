using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;



namespace IllusionPin
{
    public partial class brightnessPin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\IllusionPin\IllusionPin\illusiontb.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        public string id, pass, pin;

        public brightnessPin()
        {
            InitializeComponent();
        }


        Color c1 = System.Drawing.Color.PaleGoldenrod;
        Color c2 = System.Drawing.Color.PaleGoldenrod;
        Color c3 = System.Drawing.Color.Wheat;
        Color c4 = System.Drawing.Color.PaleGoldenrod;
        Color c5 = System.Drawing.Color.PaleGoldenrod;
        Color c6 = System.Drawing.Color.Wheat;


        public static int number;
        public static Random r = new Random();

       


        private void brightnessPin_Load(object sender, EventArgs e)
        {



           




            string ss = "5";

            number = Convert.ToInt32(ss);
            List<int> available = new List<int>(number);
            for (int i = 0; i <= number; i++)
                available.Add(i);
            List<int> result = new List<int>(number);
            while (available.Count > 0)
            {
                int index = r.Next(available.Count);
                result.Add(available[index]);
                available.RemoveAt(index);
            }

            for (int i = 0; i < result.Count; i++)
            {



                if (i == 0)
                {

                    if (result[i] == 0)
                    {

                        pictureBox1.BackColor = c1;
                    }
                    else if (result[i] == 1)
                    {

                        pictureBox1.BackColor = c2;
                    }

                    else if (result[i] == 2)
                    {

                        pictureBox1.BackColor = c3;
                    }

                    else if (result[i] == 3)
                    {

                        pictureBox1.BackColor = c4;
                    }

                    else if (result[i] == 4)
                    {

                        pictureBox1.BackColor = c5;
                    }
                    else if (result[i] == 5)
                    {

                        pictureBox1.BackColor = c6;
                    }


                  

                }
                else if (i == 1)
                {
                    if (result[i] == 0)
                    {

                        pictureBox2.BackColor = c1;
                    }
                    else if (result[i] == 1)
                    {

                        pictureBox2.BackColor = c2;
                    }

                    else if (result[i] == 2)
                    {

                        pictureBox2.BackColor = c3;
                    }

                    else if (result[i] == 3)
                    {

                        pictureBox2.BackColor = c4;

                    }
                    else if (result[i] == 4)
                    {

                        pictureBox2.BackColor = c5;
                    }
                    else if (result[i] == 5)
                    {

                        pictureBox2.BackColor = c6;
                    }






                  //  s2 = result[i].ToString();


                }
                else if (i == 2)
                {
                    if (result[i] == 0)
                    {

                        pictureBox3.BackColor = c1;
                    }
                    else if (result[i] == 1)
                    {

                        pictureBox3.BackColor = c2;
                    }

                    else if (result[i] == 2)
                    {

                        pictureBox3.BackColor = c3;
                    }

                    else if (result[i] == 3)
                    {

                        pictureBox3.BackColor = c4;
                    }
                    else if (result[i] == 4)
                    {

                        pictureBox3.BackColor = c5;
                    }
                    else if (result[i] == 5)
                    {

                        pictureBox3.BackColor = c5;
                    }



                   
                }
                else if (i == 3)
                {
                    if (result[i] == 0)
                    {

                        pictureBox4.BackColor = c1;
                    }
                    else if (result[i] == 1)
                    {

                        pictureBox4.BackColor = c2;
                    }

                    else if (result[i] == 2)
                    {

                        pictureBox4.BackColor = c3;
                    }

                    else if (result[i] == 3)
                    {

                        pictureBox4.BackColor = c4;
                    }

                    else if (result[i] == 4)
                    {

                        pictureBox4.BackColor = c5;
                    }
                    else if (result[i] == 5)
                    {

                        pictureBox4.BackColor = c6;
                    }

                    
                }

                else if (i == 4)
                {
                    if (result[i] == 0)
                    {

                        pictureBox5.BackColor = c1;
                    }
                    else if (result[i] == 1)
                    {

                        pictureBox5.BackColor = c2;
                    }

                    else if (result[i] == 2)
                    {

                        pictureBox5.BackColor = c3;
                    }

                    else if (result[i] == 3)
                    {

                        pictureBox5.BackColor = c4;
                    }

                    else if (result[i] == 4)
                    {

                        pictureBox5.BackColor = c5;
                    }
                    else if (result[i] == 5)
                    {

                        pictureBox5.BackColor = c6;
                    }


                }


                else if (i == 5)
                {
                    if (result[i] == 0)
                    {

                        pictureBox6.BackColor = c1;
                    }
                    else if (result[i] == 1)
                    {

                        pictureBox6.BackColor = c2;
                    }

                    else if (result[i] == 2)
                    {

                        pictureBox6.BackColor = c3;
                    }

                    else if (result[i] == 3)
                    {

                        pictureBox6.BackColor = c4;
                    }

                    else if (result[i] == 4)
                    {

                        pictureBox6.BackColor = c5;
                    }
                    else if (result[i] == 5)
                    {

                        pictureBox6.BackColor = c6;
                    }


                }






            }


        }


        string str;
        string ste;


        private void button1_Click(object sender, EventArgs e)
        {

            //str
            ste = pin;


            str = textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text + textBox6.Text;

            StringBuilder s1 = new StringBuilder(ste);
            StringBuilder s2 = new StringBuilder(str);

            if (pictureBox1.BackColor == System.Drawing.Color.Wheat)
            {

              
                s1.Remove(0, 1);
                s2.Remove(0, 1);

                s1.Insert(0, 0);
                s2.Insert(0, 0);


               
            }
            if (pictureBox2.BackColor == System.Drawing.Color.Wheat)
            {

                s1.Remove(1, 1);
                s2.Remove(1, 1);
              
                s1.Insert(1, 0);
                s2.Insert(1, 0);

            }

            if (pictureBox3.BackColor == System.Drawing.Color.Wheat)
            {

                s1.Remove(2, 1);
                s2.Remove(2, 1);

                s1.Insert(2, 0);
                s2.Insert(2, 0);
          
            }
            if (pictureBox4.BackColor == System.Drawing.Color.Wheat)
            {
                s1.Remove(3, 1);
                s2.Remove(3, 1);
                s1.Insert(3, 0);
                s2.Insert(3, 0);
               
            }

            if (pictureBox5.BackColor == System.Drawing.Color.Wheat)
            {
                s1.Remove(4, 1);
                s2.Remove(4, 1);
                s1.Insert(4, 0);
                s2.Insert(4, 0);

             
            }
            if (pictureBox6.BackColor == System.Drawing.Color.Wheat)
            {
                s1.Remove(5, 1);
                s2.Remove(5, 1);

                s1.Insert(5, 0);

                s2.Insert(5, 0);
              
            }





            MessageBox.Show(s1.ToString ()+ s2.ToString ());






            if (s1.ToString() == s2.ToString())
            {
                con.Open();
                cmd = new SqlCommand("select * from regtb where UserId='" + id + "' and Password='" + pass + "'  ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {


                    MessageBox.Show("Login Successfully!");
                    UserHome uu = new UserHome();
                    uu.accno = dr["Accno"].ToString();
                    uu.bal = dr["Balance"].ToString();
                    uu.Show();


                }

                con.Close();


            }
            else
            {
                MessageBox.Show("Failed");
            }



        }

        private static string AppendAtPosition(string baseString, int position, string character)
        {
            var sb = new StringBuilder(baseString);
            for (int i = position; i < sb.Length; i += (position + character.Length))
                sb.Insert(i, character);
            return sb.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
