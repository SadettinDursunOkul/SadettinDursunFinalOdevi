using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sadettin_Dursun_20200108033
{
    public partial class Dersler : Form
    {
        public Dersler()
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
            dataGridViewDrs.DataSource = (from x in db.Ders
                                           select new
                                           {
                                               x.Id,
                                               x.Ad,
                                               x.Kredisi,
                                               x.OkulYonetim.AdSoyad

                                           }).ToList();
            
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            Ders drs = new Ders();
            drs.Ad = txtDersAd.Text;
            drs.Kredisi = txtDersKredi.Text;
            drs.OkulYonetimId = int.Parse(cmbEğitmen.SelectedValue.ToString());
            db.Ders.Add(drs);
            db.SaveChanges();
            MessageBox.Show("Ders Eklendi");
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtDersId.Text);
            var drs = db.Ders.Find(x);
            drs.Ad = txtDersAd.Text;
            drs.Kredisi = txtDersKredi.Text;
            drs.OkulYonetimId = int.Parse(cmbEğitmen.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ders Güncellendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtDersId.Text);
            var drs = db.Ders.Find(x);
            db.Ders.Remove(drs);
            db.SaveChanges();
            MessageBox.Show("Ders Silindi");
        }


        private void Dersler_Load(object sender, EventArgs e)
        {
            cmbEğitmen.DisplayMember = "AdSoyad";
            cmbEğitmen.ValueMember = "Id";
            cmbEğitmen.DataSource = db.OkulYonetim.ToList();
        }

        private void dataGridViewDrs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridViewDrs.SelectedCells[0].RowIndex;
            
            txtDersId.Text = dataGridViewDrs.Rows[selected].Cells[0].Value.ToString();
            txtDersAd.Text = dataGridViewDrs.Rows[selected].Cells[1].Value.ToString();
            txtDersKredi.Text = dataGridViewDrs.Rows[selected].Cells[2].Value.ToString();
            cmbEğitmen.Text = dataGridViewDrs.Rows[selected].Cells[3].Value.ToString();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            string aranan = txtAra.Text;
            var degerler = from item in db.Ders
                           where item.Ad.Contains(aranan)
                           select item;
            dataGridViewDrs.DataSource = degerler.ToList();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridViewDrs.DataSource = db.Ders.Where(x => x.Ad == txtAra.Text).ToList();
        }
    }
}
