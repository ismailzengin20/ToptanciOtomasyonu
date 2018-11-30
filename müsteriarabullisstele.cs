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
    public partial class müsteriarabullisstele : Form
    {
        SqlConnection baglan = new SqlConnection("Server=USER;Database=toptancı;Integrated Security=True");

        public müsteriarabullisstele()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bürünaara_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
            {
                int id = Convert.ToInt32(textBox3.Text);
                baglan.Open();
                SqlCommand komut = new SqlCommand("select * from musteri where mid=@mid", baglan);
                komut.Parameters.AddWithValue("@mid", id);
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    kulad.Text = oku["mad"].ToString();
                    textBox4.Text = oku["msoyad"].ToString();
                    textBox2.Text = oku["eposta"].ToString();
                    textBox1.Text = oku["telefon"].ToString();
                     dateTimePicker1.Text = oku["dtarih"].ToString();
                     if (oku["cinsiyet"].ToString() == "Erkek")
                     {
                         radioButton1.Checked = true;
                         radioButton2.Checked = false;
                     }
                     else
                     {
                         radioButton1.Checked = false;
                         radioButton2.Checked = true;
                     }
                }

                baglan.Close();
            }
            else
            {
                MessageBox.Show("lutfen müsteri NO giriniz");
                textBox2.Clear();
            }
        }

        private void bürünsil_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
            {
                int id = Convert.ToInt32(textBox3.Text);
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from musteri where mid=@mid", baglan);
                komut.Parameters.AddWithValue("@mid", id);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("müsteri silindi");
            }
            else
            {
                MessageBox.Show("silinecek müsterinin müsteri no giriniz");
            }
        }

        private void büründüzenle_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
            {
                int id = Convert.ToInt32(textBox3.Text);

                baglan.Open();
                SqlCommand komut = new SqlCommand("update musteri set mad=@mad,msoyad=@msoyad,eposta=@eposta,telefon=@telefon,dtarih=@dtarih where mid=@mid", baglan);
                komut.Parameters.AddWithValue("@mad", kulad.Text);
                komut.Parameters.AddWithValue("@msoyad", textBox4.Text);
                komut.Parameters.AddWithValue("@eposta", textBox2.Text);
                komut.Parameters.AddWithValue("@telefon", textBox1.Text);
                komut.Parameters.AddWithValue("@dtarih", dateTimePicker1.Value);
                if (radioButton1.Checked)
                    komut.Parameters.AddWithValue("@cinsiyet", radioButton1.Text);
                if (radioButton2.Checked)
                    komut.Parameters.AddWithValue("@cinsiyet", radioButton2.Text);
                komut.Parameters.AddWithValue("@mid", id);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("müsteri basarılı bir sekilde güncellendi");
            }
            else
            {
                MessageBox.Show("güncellenecek müsterinin müsteri no  giriniz ve arama yapınız");
            }
        }

        private void bürüntemizle_Click(object sender, EventArgs e)
        {
            kulad.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox3.Clear();
            radioButton1.Checked = true;
        }

      
    }
}
