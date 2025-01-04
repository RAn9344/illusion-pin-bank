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
    public partial class Print : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\IllusionPin\IllusionPin\illusiontb.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd;
        public string accno;

        public Print()
        {
            InitializeComponent();
        }

        private void Print_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'illusiontbDataSet.transtb' table. You can move, or remove it, as needed.
           // this.transtbTableAdapter.Fill(this.illusiontbDataSet.transtb);

            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select * from transtb where Accno='"+accno +"' date  between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                cmd = new SqlCommand("select * from transtb where where Accno='" + accno + "'  date between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(illusiontbDataSet.transtb);
                reportViewer1.RefreshReport();
                reportViewer1.Refresh();
                reportViewer1.Visible = true;
            }
            else
            {
                MessageBox.Show("No Record Found!");
            }

            con.Close();
        }
    }
}
