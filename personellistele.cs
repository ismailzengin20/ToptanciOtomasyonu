﻿using System;
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
    public partial class personellistele : Form
    {
        SqlConnection baglan = new SqlConnection("Server=USER;Database=toptancı;Integrated Security=True");

        public personellistele()
        {
            InitializeComponent();
            getir();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       public void getir()
        {
            baglan.Open();
            SqlDataAdapter oku = new SqlDataAdapter("select *from personel order by id ", baglan);
            DataTable tablo = new DataTable();
            oku.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        private void personellistele_Load(object sender, EventArgs e)
        {
     
        }
    }
}
