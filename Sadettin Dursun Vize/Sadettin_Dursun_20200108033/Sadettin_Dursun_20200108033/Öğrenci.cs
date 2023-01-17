using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace Sadettin_Dursun_20200108033
{
    public partial class Öğrenci : Form
    {
        public Öğrenci()
        {
            InitializeComponent();
        }

        private void anaMenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }

        private void yönetimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yönetim fr = new Yönetim();
            fr.Show();
            this.Hide();
        }

        private void dersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dersler fr = new Dersler();
            fr.Show();
            this.Hide();
        }

        private void öğrenciDersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Öğrenci_Ders fr = new Öğrenci_Ders();
            fr.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        OkulYonetimEntities db = new OkulYonetimEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {

            dataGridViewOgr.DataSource = (from x in db.Ogrenci
                                          select new
                                          {
                                              x.Id,
                                              x.AdSoyad,
                                              x.KayitTarih,
                                              x.OgrenciNo,
                                              x.DTarih,
                                              x.Bolum

                                          }).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ogrenci ogr = new Ogrenci();
            ogr.AdSoyad = txtAdSoyad.Text;
            ogr.KayitTarih = kytTarih.Value;
            ogr.OgrenciNo = mskOgrNo.Text;
            ogr.DTarih = DTarih.Value;
            ogr.Bolum = txtBolum.Text;
            db.Ogrenci.Add(ogr);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Eklendi");
            
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var ogr = db.Ogrenci.Find(x);
            ogr.AdSoyad = txtAdSoyad.Text;
            ogr.KayitTarih = kytTarih.Value;
            ogr.OgrenciNo = mskOgrNo.Text;
            ogr.DTarih = DTarih.Value;
            ogr.Bolum = txtBolum.Text;
            db.SaveChanges();
            MessageBox.Show("Öğrenci Güncellendi");
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var ogr = db.Ogrenci.Find(x);
            db.Ogrenci.Remove(ogr);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Silindi");
        }
        

        private void dataGridViewOgr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridViewOgr.SelectedCells[0].RowIndex;

            txtId.Text = dataGridViewOgr.Rows[selected].Cells[0].Value.ToString();
            txtAdSoyad.Text = dataGridViewOgr.Rows[selected].Cells[1].Value.ToString();
            kytTarih.Text = dataGridViewOgr.Rows[selected].Cells[2].Value.ToString();
            mskOgrNo.Text = dataGridViewOgr.Rows[selected].Cells[3].Value.ToString();
            DTarih.Text = dataGridViewOgr.Rows[selected].Cells[4].Value.ToString();
            txtBolum.Text = dataGridViewOgr.Rows[selected].Cells[5].Value.ToString();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            string aranan = txtAra.Text;
            var degerler = from item in db.Ogrenci
                           where item.AdSoyad.Contains(aranan)
                           select item;
            dataGridViewOgr.DataSource = degerler.ToList();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridViewOgr.DataSource = db.Ogrenci.Where(x => x.AdSoyad == txtAra.Text).ToList();
        }
    }
}
