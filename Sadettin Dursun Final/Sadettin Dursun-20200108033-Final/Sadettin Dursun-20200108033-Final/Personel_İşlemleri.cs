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
    public partial class Personel_İşlemleri : Form
    {
        public Personel_İşlemleri()
        {
            InitializeComponent();
        }

        /*Bu formda "Personel" kaydet,güncelle ve sil işlemleri yapılır. Ayrıca
        ilgili formun datagridwiev aracına iki kere tıklandıysa veriler bu formdaki
        araçlara taşınır ve burada güncelle ve sil işlemleri yapılır.*/

        OkulYonetimEntities2 db = new OkulYonetimEntities2();
        private void Personel_İşlemleri_Load(object sender, EventArgs e)
        {
            /*Form yüklenirken "cmbDepartman" aracına 
           "Enum" yapısında veriler atanır.*/

            List<ComboBoxYonetimTip> list = new List<ComboBoxYonetimTip>();
            list.Add(new ComboBoxYonetimTip() { ID = "11", Name = "İdare" });
            list.Add(new ComboBoxYonetimTip() { ID = "12", Name = "Öğretmen" });
            list.Add(new ComboBoxYonetimTip() { ID = "13", Name = "Öğrenciİşleri" });

            cmbDepartman.DataSource = list;
            cmbDepartman.DisplayMember = "Name";
            cmbDepartman.ValueMember = "ID";
        }

        private void btnPersonelKaydet_Click(object sender, EventArgs e)
        {
            //Araçlara girilen verileri veritabanına kaydetmeye yarar.

            Personel personel = new Personel();
            personel.AdSoyad = txtPersonelAd.Text;
            personel.Gorevi = txtGörev.Text;
            personel.YonetimTip = int.Parse(cmbDepartman.SelectedValue.ToString());
            db.Personel.Add(personel);
            db.SaveChanges();
            MessageBox.Show("Personel Eklendi");
        }

        private void btnPersonelGüncelle_Click(object sender, EventArgs e)
        {
            //Seçilmiş "Id" değerine ait olan verileri veritabanda güncellemeye yarar.

            int x = Convert.ToInt32(labelId.Text);
            var personel = db.Personel.Find(x);
            personel.AdSoyad = txtPersonelAd.Text;
            personel.Gorevi = txtGörev.Text;
            personel.YonetimTip = int.Parse(cmbDepartman.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Personel Güncellendi");
        }

        private void btnPersonelSil_Click(object sender, EventArgs e)
        {
            //Seçilmiş "Id" değerine ait olan verileri veritabanından silmeye yarar.

            int x = Convert.ToInt32(labelId.Text);
            var personel = db.Personel.Find(x);
            db.Personel.Remove(personel);
            db.SaveChanges();
            MessageBox.Show("Personel Silindi");
        }
    }

    //Aşağıdaki kodları derleyici oluşturuyor onlar olmadan işlem yapamıyorum.
    internal class ComboBoxYonetimTip
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}
