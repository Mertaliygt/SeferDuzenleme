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

namespace TestSefer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O581UK8\SQLEXPRESS;Initial Catalog=LoginYolcuSistemi;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT COUNT(1) FROM FIRMAKODU=@P1 AND FIRMASIFRE=@P2  ",baglanti);
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", maskedTextBox2.Text);
            int count =Convert.ToInt32(komut.ExecuteScalar());
            if(count == 1) {
                MessageBox.Show("GİRİŞ BAŞARILI","HOŞGELDİNİZ,", MessageBoxButtons.OK,MessageBoxIcon.Information);
                Form1 frm = new Form1();
                frm.Show();
            }
            else
            {
                MessageBox.Show("GİRİŞ BAŞARISIZ \n İrtibat No:216 393 4981","Dikkat",MessageBoxButtons.OKCancel);
            }
        }
    }
}
