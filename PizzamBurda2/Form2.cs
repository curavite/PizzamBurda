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
using System.Xml.Linq;

namespace PizzamBurda2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        static string constring =("Data Source = FURKAN\\SQLEXPRESS; Initial Catalog = PizzamBurda; Integrated Security = True");
        SqlConnection baglan = new SqlConnection(constring);
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    /*string kaydol= "insert into Kaydol(name,surname,mail,number,password) values ('@ad,@soyad,@mailadres,@numara,@sifre)";
                    SqlCommand komut = new SqlCommand(kaydol, baglan);*/
                    SqlCommand komut = new SqlCommand("insert into Kaydol (name, surname, mail, number, password) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    /*komut.Parameters.AddWithValue("@ad", textBox1.Text);
                    komut.Parameters.AddWithValue("@soyad", textBox2.Text);
                    komut.Parameters.AddWithValue("@mailadres", textBox3.Text);
                    komut.Parameters.AddWithValue("@numara", textBox4.Text);
                    komut.Parameters.AddWithValue("@sifre", textBox5.Text);
                    komut.ExecuteNonQuery();*/

                    Form1 form = new Form1();
                    form.Show();
                    this.Hide();
                }
                
            }
            catch (Exception hata) {
                MessageBox.Show("Hatalı kayıt." +hata.Message);
            }
        }
    }
}
