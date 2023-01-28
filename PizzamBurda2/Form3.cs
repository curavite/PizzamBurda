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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        static string constring = ("Data Source = FURKAN\\SQLEXPRESS; Initial Catalog = PizzamBurda; Integrated Security = True");
        SqlConnection baglan = new SqlConnection(constring);
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    
                    SqlCommand komut = new SqlCommand("insert into Siparis (ilce, sokak, binaNo ,adresTarifi, pizzaCesidi,icecek,alternatif) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "')", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    

                    MessageBox.Show("Siparişiniz verildi,Teşekküler.." );
                    
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hatalı kayıt." + hata.Message);
            }
        }
    }


   
}
