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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace PizzamBurda2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        static string constring = ("Data Source = FURKAN\\SQLEXPRESS; Initial Catalog = PizzamBurda; Integrated Security = True");
        SqlConnection baglan = new SqlConnection(constring);
        SqlDataAdapter da;
        SqlCommand komut;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void verilerigor(){
        baglan = new SqlConnection(constring);
            baglan.Open();
            da = new SqlDataAdapter("select * from kaydol", baglan);
            DataTable tablo= new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            verilerigor();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    /*string kaydol= "insert into Kaydol(name,surname,mail,number,password) values ('@ad,@soyad,@mailadres,@numara,@sifre)";
                    SqlCommand komut = new SqlCommand(kaydol, baglan);*/
                    komut = new SqlCommand("insert into Kaydol (name, surname, mail, number, password) values('" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();

                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hatalı kayıt." + hata.Message);
            }
            txtId.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            
             komut = new SqlCommand("Delete From Kaydol where id=@id", baglan);
            komut.Parameters.AddWithValue("@id",Convert.ToInt32(txtId.Text));
            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigor();
            baglan.Open();
            komut= new SqlCommand("insert into silinmisXkayit (Sid,Sname, Ssurname, Smail, Snumber, Spassword) values('" + txtId.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Yedeklenecek yolu belirtiniz.";
            saveFileDialog1.Filter= "Yedekleme dosyları(*.bak)|*.bak|Tüm Dosyalar(*.*)|*.*";
            if(saveFileDialog1.ShowDialog(Owner) == DialogResult.OK)
            {
                textBox1.Text=saveFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Server dbServer = new Server(new ServerConnection(textBox8.Text));
            Backup dbBackup = new Backup();
            dbBackup.Action = BackupActionType.Database;
            dbBackup.Database =textBox7.Text;
            dbBackup.Devices.AddDevice(textBox1.Text, DeviceType.File);
            dbBackup.Initialize = false;
            dbBackup.Complete += DbBackup_Complete;
            dbBackup.SqlBackup(dbServer);
        }

        private void DbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            try
            {
                MessageBox.Show("Yedekleme işlemi başaralı şekilde yapıldı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,"Hata!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
            this.Hide();
        }
    }
}
