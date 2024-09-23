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
using System.Runtime.InteropServices;

namespace TestSefer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string oturmanumarası;
        void sefergetir()
        {
            // DATA GRİD VİEW İÇİN VERİLERİ ÇEKME İŞLEMİ
           SqlDataAdapter da = new SqlDataAdapter("Select * from TBLSEFERBILGI",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
      /*  void login ()
        {
            DialogResult dialog = MessageBox.Show("TAB'a Hoşgeldiniz.\nMüşterimisiniz?", "Login Page",
                MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                Form1 frm = new Form1();
                
            }else
            {
                Form2 frm2 = new Form2();
                frm2.Show();
            }

        }*/ 

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-O581UK8\SQLEXPRESS;Initial Catalog=TestYolcuBilet;Integrated Security=True");
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();    
            SqlCommand komut = new SqlCommand("insert into TBLYOLCUBILGI (AD,SOYAD,TELEFON,TC,CINSIYET,MAIL) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2",txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3",msktel.Text);
            komut.Parameters.AddWithValue("@p4",msktc.Text);
            komut.Parameters.AddWithValue("@p5",cmbcinsiyet.Text);
            komut.Parameters.AddWithValue("@p6",mskmail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yolcu Bilgilerini Bize Gönderdin","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);


        }

        private void btnkaptan_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into TBLKAPTAN (KAPTANNO,ADSOYAD,TELEFON) values" +
                "(@p1,@p2,@p3)",baglanti);
            komut1.Parameters.AddWithValue("@p1", mskkaptanno.Text);
            komut1.Parameters.AddWithValue("@p2", txtkaptanad.Text);
            komut1.Parameters.AddWithValue("@p3", mskkaptantel.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaptan Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnsefer_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSEFERBILGI (KALKIS,VARIS,TARIH,SAAT,KAPTAN,FIYAT) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1",txtkalkıs.Text);
            komut.Parameters.AddWithValue("@p2", txtvaris.Text);
            komut.Parameters.AddWithValue("@p3",msktarih.Text);
            komut.Parameters.AddWithValue("@p4",msksaat.Text);
            komut.Parameters.AddWithValue("@p5", mskkaptan.Text);
            komut.Parameters.AddWithValue("@p6",txtfiyat.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sefer Bilgisi Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sefergetir();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // login();
            sefergetir();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex; //satır indexini aldı
            txtsefernumara.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtkoltukno.Text = "9";
        }

        private void btnrezerve_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLSEFERDETAY (SEFERNO,YOLCUTC,KOLTUK) values " +
                "(@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1",txtsefernumara.Text);
            komut.Parameters.AddWithValue("@p2", mskyolcutc.Text);
            komut.Parameters.AddWithValue("@p3",txtkoltukno.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Rezerve İşleminiz Onaylandı \n Lütfen Boş Koltukları Yeniden Görüntüleyiniz","BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLSEFERDETAY where KOLTUK=@P1 ",baglanti);
            komut.Parameters.AddWithValue("@p1",txtkoltukno.Text);
            SqlDataReader reader = komut.ExecuteReader();

            if (reader.Read())
            {
                oturmanumarası = txtkoltukno.Text;
                
                if(oturmanumarası == Convert.ToString(1) )
                {
                    btn1.Hide();

                }
                if (oturmanumarası == Convert.ToString(2))
                {
                    btn2.Hide();

                }
                if (oturmanumarası == Convert.ToString(3))
                {
                    btn3.Hide();

                }
                if (oturmanumarası == Convert.ToString(4))
                {
                    btn4.Hide();

                }
                if (oturmanumarası == Convert.ToString(5))
                {
                    btn5.Hide();

                }
                if (oturmanumarası == Convert.ToString(6))
                {
                    btn6.Hide();

                }
                if (oturmanumarası == Convert.ToString(7))
                {
                    btn7.Hide();

                }
                if (oturmanumarası == Convert.ToString(8))
                {
                    btn8.Hide();

                }
                if (oturmanumarası == Convert.ToString(9))
                {
                    btn9.Hide();

                }


            } else { MessageBox.Show("Bir şeyler ters gitti"); }
            baglanti.Close();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btn1.Show(); btn2.Show(); btn3.Show(); btn4.Show(); btn5.Show(); btn6.Show(); btn7.Show(); btn8.Show(); btn9.Show();
        }
    }
}
