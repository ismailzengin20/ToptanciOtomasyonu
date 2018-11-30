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
    public partial class ürünekle : Form
    {
        SqlConnection baglan = new SqlConnection("Server=USER;Database=toptancı;Integrated Security=True");
        public ürünekle()
        {
            InitializeComponent();
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }     
        private void kaydet_Click(object sender, EventArgs e)
        {
            try
            {
              
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into urun(uad,utur,ufiyat,utarih)values(@uad,@utur,@ufiyat,@utarih)", baglan);
                komut.Parameters.AddWithValue("@uad", kulad.Text);
                komut.Parameters.AddWithValue("@utur", comboBox1.Text);
                komut.Parameters.AddWithValue("@ufiyat", Convert.ToInt32(textBox1.Text));
                komut.Parameters.AddWithValue("@utarih", dateTimePicker1.Value);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("ürün basarılı bir şekide kaydedildi");
                kulad.Clear();
                comboBox1.SelectedIndex=0;
                textBox1.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex+"");
            }
         }


    }
}
