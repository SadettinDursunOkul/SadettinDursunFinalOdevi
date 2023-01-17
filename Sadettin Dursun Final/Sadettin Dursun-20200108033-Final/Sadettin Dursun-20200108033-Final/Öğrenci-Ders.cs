using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sadettin_Dursun_20200108033_Final
{
    public partial class Öğrenci_Ders : Form
    {
        public Öğrenci_Ders()
        {
            InitializeComponent();
        }

        /*Bu formda "Öğrenci-Ders" kaydet ve sil işlemleri yapılır. Ayrıca
        ilgili formun datagridwiev aracına iki kere tıklandıysa veriler bu formdaki
        araçlara taşınamıyor ve burada güncelle ve sil işlemleri yapılması gerekiyordu fakat 
        program düzgün çalışmıyor sorunu çözemedim.(Güncelleme ve silme işlemi araçlara atanan değerler
        üzerinde oluyor fakat araçlara değerleri doğru atamıyor)*/

        OkulYonetimEntities2 db = new OkulYonetimEntities2();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //Araçlara girilen verileri veritabanına kaydetmeye yarar.

            OgrenciDers ögrdrs = new OgrenciDers();
            ögrdrs.OgrenciId = int.Parse(cmbÖgr.SelectedValue.ToString());
            ögrdrs.DersId = int.Parse(cmbDers.SelectedValue.ToString());
            db.OgrenciDers.Add(ögrdrs);
            db.SaveChanges();
            MessageBox.Show("Öğrenciye Ders İliştirildi");
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //Seçilmiş "Id" değerine ait olan verileri veritabanda güncellemeye yaramalıydı fakat düzgün çalışmıyor.

            int x = Convert.ToInt32(labelId.Text);
            var ögrdrs = db.OgrenciDers.Find(x);
            ögrdrs.OgrenciId = int.Parse(cmbÖgr.SelectedValue.ToString());
            ögrdrs.DersId = int.Parse(cmbDers.SelectedValue.ToString());
            MessageBox.Show("Öğrencinin Dersi Güncellendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Seçilmiş "Id" değerine ait olan verileri veritabanından silmeye yaramalıydı fakat düzgün çalışmıyor.

            int x = Convert.ToInt32(labelId.Text);
            var ögrdrs = db.OgrenciDers.Find(x);
            db.OgrenciDers.Remove(ögrdrs);
            db.SaveChanges();
            MessageBox.Show("Ders Silindi");
        }

        private void Öğrenci_Ders_Load(object sender, EventArgs e)
        {
            /*Form yüklenirken "cmbÖgr ve cmbDers" araçlarına 
            ilgili veritabanı tablolarından veriler atanır.*/

            List<Ogrenci> ogrenciler = db.Ogrenci.ToList();
            cmbÖgr.DataSource = ogrenciler;
            cmbÖgr.ValueMember = "Id";
            cmbÖgr.DisplayMember = "AdSoyad";

            List<Ders> dersler = db.Ders.ToList();
            cmbDers.DataSource = dersler;
            cmbDers.ValueMember = "Id";
            cmbDers.DisplayMember = "Ad";
        }
    }
}
