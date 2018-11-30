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
    public partial class personelekle : Form
    {
        SqlConnection baglan = new SqlConnection("Server=USER;Database=toptancı;Integrated Security=True");

        public personelekle()
        {
            InitializeComponent();
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
                SqlCommand komut = new SqlCommand("insert into personel(pad,psoayad,gorevi,telefonu)values(@pad,@psoayad,@gorevi,@telefonu)", baglan);
                komut.Parameters.AddWithValue("@pad", kulad.Text);
                komut.Parameters.AddWithValue("@psoayad",textBox3.Text);
                komut.Parameters.AddWithValue("@gorevi", textBox2.Text);
                komut.Parameters.AddWithValue("@telefonu", textBox1.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("personel basarılı bir şekide kaydedildi");
                kulad.Clear();
                textBox1.Clear();
                textBox3.Clear();
                textBox2.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex+"");
            }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
