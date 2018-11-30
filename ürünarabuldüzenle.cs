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

namespace dolphin
{
    public partial class ürünarabuldüzenle : Form
    {
        SqlConnection baglan = new SqlConnection("Server=USER;Database=toptancı;Integrated Security=True");
        public ürünarabuldüzenle()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bürünaara_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                int id=Convert.ToInt32(textBox2.Text);
                baglan.Open();
                SqlCommand komut = new SqlCommand("select * from urun where id=@id",baglan);
                komut.Parameters.AddWithValue("@id",id);
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                   kulad.Text= oku["uad"].ToString();
                   textBox1.Text = oku["ufiyat"].ToString();
                   comboBox1.Text = oku["utur"].ToString();
                   dateTimePicker1.Text = oku["utarih"].ToString();
                }

                baglan.Close();

            }
            else 
            {
                MessageBox.Show("lutfen ÜRÜN NO giriniz");
                textBox2.Clear();
            }
        }

        private void bürünsil_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                int id = Convert.ToInt32(textBox2.Text);
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from urun where id=@id",baglan);
                komut.Parameters.AddWithValue("@id",id);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("urun silindi");
            }
            else
            {
                MessageBox.Show("silinecek urun no giriniz");
            }
        }

        private void büründüzenle_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                int id = Convert.ToInt32(textBox2.Text);
                if (textBox2.Text.Length > 0 && textBox1.Text.Length > 0 && kulad.Text.Length > 0 && comboBox1.Text.Length > 0)
                {
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update urun set uad=@uad,utur=@utur,ufiyat=@ufiyat,utarih=@utarih where id=@id", baglan);
                    komut.Parameters.AddWithValue("@uad", kulad.Text);
                    komut.Parameters.AddWithValue("@utur", comboBox1.Text);
                    komut.Parameters.AddWithValue("@ufiyat", Convert.ToInt32(textBox1.Text));
                    komut.Parameters.AddWithValue("@utarih", dateTimePicker1.Value);
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("urun basarılı bir sekilde güncellendi");
                }
                else
                {
                    MessageBox.Show("bos yerleri doldurup tekrar deneyiniz");
                }
            }
            else
            {
                MessageBox.Show("güncellenecek ürünün ürun no  giriniz ve arama yapınız");
            }
        }

        private void bürüntemizle_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = 0;
            textBox2.Clear();
            kulad.Clear();
            
        }
    }
}
