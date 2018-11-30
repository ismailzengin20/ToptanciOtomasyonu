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
    public partial class kasahareketi : Form
    { 
        public int toplam=0;
        SqlConnection baglan = new SqlConnection("Server=USER;Database=toptancı;Integrated Security=True");
        public kasahareketi()
        {
            InitializeComponent();
            baglan.Open();
           
            SqlCommand komut = new SqlCommand("select * from satıs", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                toplam += Convert.ToInt32(oku["urunfiyat"].ToString()) * Convert.ToInt32(oku["sadet"].ToString());
            }
            label1.Text = toplam + " TL";
            baglan.Close();
        }

        private void kasahareketi_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
