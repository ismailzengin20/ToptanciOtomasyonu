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
    public partial class personelarabullistele : Form
    {
        SqlConnection baglan = new SqlConnection("Server=USER;Database=toptancı;Integrated Security=True");

        public personelarabullistele()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bürünaara_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 0)
            {
                int id = Convert.ToInt32(textBox4.Text);
                baglan.Open();
                SqlCommand komut = new SqlCommand("select * from personel where id=@id", baglan);
                komut.Parameters.AddWithValue("@id", id);
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    kulad.Text = oku["pad"].ToString();
                    textBox3.Text = oku["psoayad"].ToString();
                    textBox2.Text = oku["gorevi"].ToString();
                    textBox1.Text = oku["telefonu"].ToString();                                     
                }

                baglan.Close();
            }
            else
            {
                MessageBox.Show("lutfen personel NO giriniz");
                textBox2.Clear();
            }
        }

        private void bürünsil_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 0)
            {
                int id = Convert.ToInt32(textBox4.Text);
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from personel where id=@id", baglan);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("personel silindi");
                kulad.Clear();
                textBox1.Clear();
                textBox3.Clear();
                textBox2.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("silinecek personel personel no giriniz");
            }
        }

        private void büründüzenle_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 0)
            {
                int id = Convert.ToInt32(textBox4.Text);
              
                baglan.Open();
                SqlCommand komut = new SqlCommand("update personel set pad=@pad,psoayad=@psoayad,gorevi=@gorevi,telefonu=@telefonu where id=@id", baglan);
                komut.Parameters.AddWithValue("@pad", kulad.Text);
                komut.Parameters.AddWithValue("@psoayad", textBox3.Text);                  
                komut.Parameters.AddWithValue("@gorevi", textBox2.Text);                  
                komut.Parameters.AddWithValue("@telefonu", textBox1.Text);                          
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("personel basarılı bir sekilde güncellendi");
                kulad.Clear();
                textBox1.Clear();
                textBox3.Clear();
                textBox2.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("güncellenecek personel ürun no  giriniz ve arama yapınız");
            }
        
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
