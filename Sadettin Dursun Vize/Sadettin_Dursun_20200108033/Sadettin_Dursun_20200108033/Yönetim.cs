using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sadettin_Dursun_20200108033
{
    public partial class Yönetim : Form
    {
        public Yönetim()
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
            dataGridViewYntm.DataSource = (from x in db.OkulYonetim
                                           select new
                                           {
                                               x.Id,
                                               x.AdSoyad,
                                               x.Gorevi,
                                               x.YonetimTip
                                           }).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            OkulYonetim yntm = new OkulYonetim();
            yntm.AdSoyad = txtAdSoyad.Text;
            yntm.Gorevi = txtGorev.Text;
            yntm.YonetimTip = byte.Parse(cmbTip.SelectedValue.ToString());
            db.OkulYonetim.Add(yntm);
            db.SaveChanges();
            MessageBox.Show("Yönetici Eklendi");
        }

        
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var yntm = db.OkulYonetim.Find(x);
            yntm.AdSoyad = txtAdSoyad.Text;
            yntm.Gorevi = txtGorev.Text;
            yntm.YonetimTip = byte.Parse(cmbTip.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Yönetici Güncellendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var yntm = db.OkulYonetim.Find(x);
            db.OkulYonetim.Remove(yntm);
            db.SaveChanges();
            MessageBox.Show("Yönetici Silindi");
        }

       
        private void Yönetim_Load(object sender, EventArgs e)
        {
            List<ComboBoxYonetimTip> list = new List<ComboBoxYonetimTip>();
            list.Add(new ComboBoxYonetimTip() { ID = "11" , Name = "Idare" });
            list.Add(new ComboBoxYonetimTip() { ID = "12" , Name = "Ogretmen" });
            list.Add(new ComboBoxYonetimTip() { ID = "13" , Name = "OgrenciIsleri" });

            cmbTip.DataSource = list;
            cmbTip.DisplayMember = "Name";
            cmbTip.ValueMember = "ID";

        }

        private void dataGridViewYntm_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridViewYntm.SelectedCells[0].RowIndex;

            txtId.Text = dataGridViewYntm.Rows[selected].Cells[0].Value.ToString();
            txtAdSoyad.Text = dataGridViewYntm.Rows[selected].Cells[1].Value.ToString();
            txtGorev.Text = dataGridViewYntm.Rows[selected].Cells[2].Value.ToString();
            cmbTip.SelectedValue = dataGridViewYntm.Rows[selected].Cells[3].Value.ToString();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            string aranan = txtAra.Text;
            var degerler = from item in db.OkulYonetim
                           where item.AdSoyad.Contains(aranan)
                           select item;
            dataGridViewYntm.DataSource = degerler.ToList();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridViewYntm.DataSource = db.OkulYonetim.Where(x => x.AdSoyad == txtAra.Text).ToList();
        }
    }
}
