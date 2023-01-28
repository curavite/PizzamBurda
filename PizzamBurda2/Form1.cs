using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PizzamBurda2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        SqlConnection conn;
        SqlDataReader dr;
        SqlCommand com;
        //SqlConnection baglanti = new SqlConnection("Data Source = FURKAN\\SQLEXPRESS; Initial Catalog = PizzamBurda; Integrated Security = True");
        private void button1_Click(object sender, EventArgs e)
        {
           string user = textBox1.Text;
            string password = textBox5.Text;
            if(user == "admin" && password == "sa1234")
            {
                Form5 form = new Form5();
                form.Show();
                this.Hide();
            }
            conn = new SqlConnection("Data Source = FURKAN\\SQLEXPRESS; Initial Catalog = PizzamBurda; Integrated Security = True");
            com = new SqlCommand();
           conn.Open();
            com.Connection = conn;
            com.CommandText = "select * from Giris where mail='" + textBox1.Text + "' and sifre='" + textBox5.Text + "'";
            dr =com.ExecuteReader();
            if (dr.Read())
            {
                Form4 form = new Form4();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mail adres veya şifresinizi kontrol ediniz!!");
            }
           
            conn.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }
    }
}
