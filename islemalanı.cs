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
    public partial class islemalanı : Form
    {
        SqlConnection baglan = new SqlConnection("Server=USER;Database=toptancı;Integrated Security=True");

        public islemalanı()
        {
            InitializeComponent();
            urungetir();
            musterigetir();
            combodoldur();
            stokgetir();
            musteridoldur();
            urundoldur();
            personeldoldur();
            satısgetir();                 
        }
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ürünekle ürnekle = new ürünekle();
            ürnekle.ShowDialog();
            urungetir();
            combodoldur();
            urundoldur();

        }
        private void ürünListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ürünlistele ürnlistele = new ürünlistele();
            ürnlistele.ShowDialog();
        }
        private void araSilDüzeneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ürünarabuldüzenle ürarabuldüzenle = new ürünarabuldüzenle();
            ürarabuldüzenle.ShowDialog();
            urungetir();
        }
        private void müşteriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            müsteriekle müsteriekle = new müsteriekle();
            müsteriekle.ShowDialog();
            musterigetir();
            musteridoldur();
        
        }
        private void müşteriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            müsterilistele müsterilistele = new müsterilistele();
            müsterilistele.ShowDialog();
        }
        private void müşteriAraSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            müsteriarabullisstele müsteriarabulisstele = new müsteriarabullisstele();
            müsteriarabulisstele.ShowDialog();
            musterigetir();
        }
        private void personelEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personelekle personelekle = new personelekle();
            personelekle.ShowDialog();
            personeldoldur();
        }

        private void personelListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personellistele personellistele = new personellistele();
            personellistele.ShowDialog();
        }

        private void araSilDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personelarabullistele personelarabullistele = new personelarabullistele();
            personelarabullistele.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }
        void urungetir()
        {
            baglan.Open();
            SqlDataAdapter oku = new SqlDataAdapter("select * from urun order by id  ", baglan);
            DataTable tablo = new DataTable();
            oku.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        void musterigetir()
        {
            baglan.Open();
            SqlDataAdapter oku = new SqlDataAdapter("select * from musteri order by mid  ", baglan);
            DataTable tablo = new DataTable();
            oku.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglan.Close();
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }
        public void combodoldur()
        {

            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from urun",baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                comboBox1.Items.Add ( oku["uad"].ToString());              
           
            }
            baglan.Close();
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into stok (ad,tur,adet,tarih)values(@ad,@tur,@adet,@tarih) ", baglan);
            komut.Parameters.AddWithValue("@ad", comboBox1.Text);
            komut.Parameters.AddWithValue("@tur", comboBox2.Text);
            komut.Parameters.AddWithValue("@adet", Convert.ToInt32(textBox1.Text));
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
            komut.ExecuteNonQuery();
            baglan.Close();
            urundoldur();
            MessageBox.Show("urun stoğa eklendi");
            stokgetir();
            textBox1.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        public void stokgetir()
        {
            baglan.Open();
            SqlDataAdapter oku = new SqlDataAdapter("select *from stok", baglan);
            DataTable tablo = new DataTable();
            oku.Fill(tablo);
            dataGridView3.DataSource = tablo;
            baglan.Close();
        }
        private void BKaydet_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex > -1 && comboBox5.SelectedIndex > -1 && comboBox6.SelectedIndex > -1
                && comboBox8.SelectedIndex > -1 && comboBox7.SelectedIndex > -1 && comboBox7.SelectedIndex > -1 && comboBox10.SelectedIndex > -1)
            {
                baglan.Open();
                string ad = comboBox2.Text;
                DataTable dt = new DataTable();
                SqlDataAdapter oku = new SqlDataAdapter("select * from stok where ad=ad ", baglan);
                oku.Fill(dt);
                int adet = Convert.ToInt32(dt.Rows[0]["adet"]);
                baglan.Close();

                try
                {
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("insert into satıs (musadı,mussoyadı,peradı,persoyad,urunad,urunsoyad,urunfiyat,sadet,satıstarihi)values(@musadı,@mussoyadı,@peradı,@persoyad,@urunad,@urunsoyad,@urunfiyat,@sadet,@satıstarihi)", baglan);
                    komut.Parameters.AddWithValue("@musadı", comboBox4.Text);
                    komut.Parameters.AddWithValue("@mussoyadı", comboBox3.Text);
                    komut.Parameters.AddWithValue("@peradı", comboBox6.Text);
                    komut.Parameters.AddWithValue("@persoyad", comboBox5.Text);
                    komut.Parameters.AddWithValue("@urunad", comboBox8.Text);
                    komut.Parameters.AddWithValue("@urunsoyad", comboBox7.Text);
                    komut.Parameters.AddWithValue("@urunfiyat", Convert.ToInt32(comboBox10.Text));
                    komut.Parameters.AddWithValue("@sadet", Convert.ToInt32(textBox2.Text));
                    komut.Parameters.AddWithValue("@satıstarihi", dateTimePicker2.Value);
                    komut.ExecuteNonQuery();
                    baglan.Close();

                    MessageBox.Show("basarılı bir sekilde satıldı");
                    stokguncelle();
                    satısgetir();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "");
                }
            }

            else
            {
                MessageBox.Show("bilgi girişi yapınız");
            }
        }
        public void satısgetir()
        {
            baglan.Open();
            SqlDataAdapter oku = new SqlDataAdapter("select * from satıs ", baglan);
            DataTable tablo = new DataTable();
            oku.Fill(tablo);
            dataGridView4.DataSource = tablo;
            baglan.Close();
        }
        private void btemizle_Click(object sender, EventArgs e)
        {
            comboBox4.Text = "";
            comboBox3.Text = "";
            comboBox8.Text = "";
            comboBox7.Text = "";
            comboBox6.Text = "";
            comboBox5.Text = "";
            comboBox10.Text = "";
            textBox2.Clear();
        }
        private void bsatısraporla_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void bstoktoplam_Click(object sender, EventArgs e)
        {

            stoktoplamgörüntüle stkg = new stoktoplamgörüntüle(textBox2, comboBox8);
            stkg.Show();
        
        }

        private void bkasahareketi_Click(object sender, EventArgs e)
        {
            kasahareketi k = new kasahareketi();
            k.Show();
        }

        private void bsatıssil_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
            {
                int id = Convert.ToInt32(textBox3.Text);
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from satıs where stokid=@stokid", baglan);
                komut.Parameters.AddWithValue("@stokid", id);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("satıs silindi");
                satısgetir();
                textBox3.Clear();
                //stokarttır();
            }
            else
            {
                MessageBox.Show("silinecek satısın stok no giriniz");
            }
        }   
        public void urundoldur()
        { 
            baglan.Open();
            comboBox8.Items.Clear();
                SqlCommand komut = new SqlCommand("select * from stok", baglan);
                  SqlDataReader oku = komut.ExecuteReader();
                   while (oku.Read())
                    {
                    comboBox8.Items.Add(oku["ad"].ToString());                    
                    }
            baglan.Close();
        }      
             
        public void musteridoldur()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from musteri", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox4.Items.Add(oku["mad"].ToString());
            }
            baglan.Close();
        }   
        private void comboBox4_Leave(object sender, EventArgs e)
        {
            baglan.Open();                   
            SqlCommand komut = new SqlCommand("select * from musteri where mad=@mad", baglan);
            komut.Parameters.AddWithValue("@mad", comboBox4.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox3.Items.Add(oku["msoyad"].ToString());
            }
            baglan.Close();
        }
        private void comboBox8_Leave(object sender, EventArgs e)
        {
            baglan.Open();
            comboBox7.Items.Clear();
            SqlCommand komut = new SqlCommand("select * from stok where ad=@ad", baglan);
            komut.Parameters.AddWithValue("@ad", comboBox8.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox7.Items.Add(oku["tur"].ToString());
            }
            baglan.Close();
        }
        public void personeldoldur()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from personel", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox6.Items.Add(oku["pad"].ToString());
            }
            baglan.Close();
        }
        private void comboBox6_Leave(object sender, EventArgs e)
        {
            baglan.Open();
            comboBox5.Items.Clear();
            SqlCommand komut = new SqlCommand("select * from personel where pad=@pad", baglan);
            komut.Parameters.AddWithValue("@pad", comboBox6.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox5.Items.Add(oku["psoayad"].ToString());
            }
            baglan.Close();

        }
        private void comboBox7_Leave(object sender, EventArgs e)
        {
            baglan.Open();
            comboBox10.Items.Clear();
            SqlCommand komut = new SqlCommand("select * from urun where uad=@uad", baglan);
            komut.Parameters.AddWithValue("@uad", comboBox8.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox10.Items.Add(oku["ufiyat"].ToString());
            }
            baglan.Close();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("select * from urun where uad=@uad", baglan);
            komut.Parameters.AddWithValue("@uad", comboBox1.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku["utur"].ToString());
            }
            baglan.Close();
        }



        public void stokguncelle()
        {

            baglan.Open();
            string ad = comboBox8.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter oku = new SqlDataAdapter("select * from stok where ad=ad ", baglan);
            oku.Fill(dt);
            int adet = Convert.ToInt32(dt.Rows[0]["adet"]);
            int satılan = Convert.ToInt32(textBox2.Text);
            adet = adet - satılan;
            SqlCommand komut = new SqlCommand("update stok set adet=@adet where ad=@ad", baglan);
            komut.Parameters.AddWithValue("@adet", adet);
            komut.Parameters.AddWithValue("@ad", ad);
            komut.ExecuteNonQuery();
            baglan.Close();
        
        }

        private void müşteriRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView3.CurrentCell.RowIndex;
            dataGridView3.Rows.RemoveAt(rowindex);
            
            int deger = Convert.ToInt32(dataGridView3.CurrentRow.Cells["no"].Value);
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from stok where no=@id", baglan);
            komut.Parameters.AddWithValue("@id", deger+1);        
            komut.ExecuteNonQuery();
            baglan.Close();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
      
        
    }
    
    
}
