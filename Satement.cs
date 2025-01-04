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
    public partial class Satement : Form
    {

        public string accno, bal;
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\IllusionPin\IllusionPin\illusiontb.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd;

        public Satement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "BALANCE : " + bal;


            cmd = new SqlCommand("select * from transtb where date between '" + dateTimePicker1.Text + "' and  '" + dateTimePicker2.Text + "' and Accno='" + accno + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }

        private void Satement_Load(object sender, EventArgs e)
        {
         //   label1.Text = accno;


            con.Open();
            cmd = new SqlCommand("select * from regtb where Accno='" + accno + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                bal = dr["Balance"].ToString();


            }
            else
            {


            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Print pp = new Print();
            pp.accno = accno;

            pp.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
