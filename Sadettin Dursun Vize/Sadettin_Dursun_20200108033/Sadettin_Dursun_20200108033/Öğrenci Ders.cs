using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sadettin_Dursun_20200108033
{
    public partial class Öğrenci_Ders : Form
    {
        public Öğrenci_Ders()
        {
            InitializeComponent();
        }

        private void anaMenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }

        private void öğrenciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Öğrenci fr = new Öğrenci();
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

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        OkulYonetimEntities db = new OkulYonetimEntities();

        public int DersId { get; private set; }
        public int OgrenciId { get; private set; }

        private void btnListele_Click_1(object sender, EventArgs e)
        {
            dataGridViewOgrDrs.DataSource = (from x in db.OgrenciDers
                                             select new
                                             {
                                                 x.Id,
                                                 x.Ogrenci.AdSoyad,
                                                 x.Ders.Ad


                                             }).ToList();

        }

        private void Öğrenci_Ders_Load(object sender, EventArgs e)
        {
            cmbDrs.DisplayMember = "Ad";
            cmbDrs.ValueMember = "Id";

            cmbOgr.DisplayMember = "AdSoyad";
            cmbOgr.ValueMember = "Id";

            cmbDrs.DataSource = db.Ders.ToList();
            cmbOgr.DataSource = db.Ogrenci.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            OgrenciDers ogrdrs = new OgrenciDers
            {
                DersId = int.Parse(cmbDrs.SelectedValue.ToString()),
                OgrenciId = int.Parse(cmbOgr.SelectedValue.ToString())
            };
            db.OgrenciDers.Add(ogrdrs);
            
            db.SaveChanges();
            MessageBox.Show("Öğrenciye Ders Eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var ogrdrs = db.OgrenciDers.Find(x);
            
            db.OgrenciDers.Remove(ogrdrs);
            db.SaveChanges();
            
            MessageBox.Show("Yönetici Silindi");
        }
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var ogrdrs = db.OgrenciDers.Find(x);

            ogrdrs.DersId = int.Parse(cmbDrs.SelectedValue.ToString());
            ogrdrs.OgrenciId = int.Parse(cmbOgr.SelectedValue.ToString());
            
            db.SaveChanges();
            MessageBox.Show("Öğrencinin Dersi Güncellendi");
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            string aranan = txtAra.Text;
            var degerler = from item in db.Ogrenci
                           where item.AdSoyad.Contains(aranan)
                           select item;
            dataGridViewOgrDrs.DataSource = degerler.ToList();
        }

        private void dataGridViewOgrDrs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridViewOgrDrs.SelectedCells[0].RowIndex;

            txtId.Text = dataGridViewOgrDrs.Rows[selected].Cells[0].Value.ToString();
            cmbOgr.Text = dataGridViewOgrDrs.Rows[selected].Cells[1].Value.ToString();
            cmbDrs.Text = dataGridViewOgrDrs.Rows[selected].Cells[2].Value.ToString();
            
        }

        
    }
}
