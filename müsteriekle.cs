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
    public partial class müsteriekle : Form
    {
        SqlConnection baglan = new SqlConnection("Server=USER;Database=toptancı;Integrated Security=True");

        public müsteriekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into musteri(mad,msoyad,eposta,telefon,dtarih,cinsiyet)values(@mad,@msoyad,@eposta,@telefon,@dtarih,@cinsiyet)", baglan);
                komut.Parameters.AddWithValue("@mad", kulad.Text);
                komut.Parameters.AddWithValue("@msoyad", textBox3.Text);
                komut.Parameters.AddWithValue("@eposta",textBox2.Text);
                komut.Parameters.AddWithValue("@telefon",textBox1.Text);
                komut.Parameters.AddWithValue("@dtarih", dateTimePicker1.Value);
                if(radioButton1.Checked)
                komut.Parameters.AddWithValue("@cinsiyet",radioButton1.Text );
                if (radioButton2.Checked)
                    komut.Parameters.AddWithValue("@cinsiyet", radioButton2.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("müsteri basarılı bir şekide kaydedildi");
                kulad.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                radioButton1.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

      

        
    }
}
