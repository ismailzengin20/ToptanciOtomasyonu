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
    public partial class stoktoplamgörüntüle : Form
    {
      SqlConnection baglan = new SqlConnection("Server=USER;Database=toptancı;Integrated Security=True");
      ComboBox  ComboBox8;
        public stoktoplamgörüntüle(TextBox t,ComboBox c8)
        {
            
            ComboBox8 = c8;

            InitializeComponent();



            baglan.Open();
            
            SqlDataAdapter oku = new SqlDataAdapter("select ad,adet from stok ", baglan);
            DataTable tablo = new DataTable();
            oku.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
           
        }
        
        private void stoktoplamgörüntüle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'toptancıDataSet.stok' table. You can move, or remove it, as needed.
            this.stokTableAdapter.Fill(this.toptancıDataSet.stok);

            this.reportViewer1.RefreshReport();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
