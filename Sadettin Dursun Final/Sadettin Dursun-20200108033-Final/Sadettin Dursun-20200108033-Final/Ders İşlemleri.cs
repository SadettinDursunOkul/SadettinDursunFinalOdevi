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
    public partial class Ders_İşlemleri : Form
    {
        public Ders_İşlemleri()
        {
            InitializeComponent();
        }
        
        /*Bu formda "Ders" kaydet,güncelle ve sil işlemleri yapılır. Ayrıca
        ilgili formun datagridwiev aracına iki kere tıklandıysa veriler bu formdaki
        araçlara taşınır ve burada güncelle ve sil işlemleri yapılır.*/

        OkulYonetimEntities2 db = new OkulYonetimEntities2();
        private void Ders_İşlemleri_Load(object sender, EventArgs e)
        {

            /*Form yüklenirken "cmbDersKredi ve cmbRenk" araçlarına 
            "Enum" yapısında veriler atanır.*/
            
            cmbEğitmen.DisplayMember = "AdSoyad";
            cmbEğitmen.ValueMember = "Id";
            cmbEğitmen.DataSource = db.Personel.ToList();

            List<ComboBoxDersKredi> list = new List<ComboBoxDersKredi>();
            list.Add(new ComboBoxDersKredi() { ID = "1", Name = "1" });
            list.Add(new ComboBoxDersKredi() { ID = "2", Name = "2" });
            list.Add(new ComboBoxDersKredi() { ID = "3", Name = "3" });
            list.Add(new ComboBoxDersKredi() { ID = "4", Name = "4" });
            list.Add(new ComboBoxDersKredi() { ID = "5", Name = "5" });
            list.Add(new ComboBoxDersKredi() { ID = "6", Name = "6" });
            list.Add(new ComboBoxDersKredi() { ID = "7", Name = "7" });
            list.Add(new ComboBoxDersKredi() { ID = "8", Name = "8" });
            list.Add(new ComboBoxDersKredi() { ID = "9", Name = "9" });
            list.Add(new ComboBoxDersKredi() { ID = "10", Name = "10" });

            cmbDersKredi.DataSource = list;
            cmbDersKredi.DisplayMember = "Name";
            cmbDersKredi.ValueMember = "ID";

            List<ComboBoxDersRenk> list1 = new List<ComboBoxDersRenk>();
            list1.Add(new ComboBoxDersRenk() { ID = "1", Name = "Siyah" });
            list1.Add(new ComboBoxDersRenk() { ID = "2", Name = "Beyaz" });
            list1.Add(new ComboBoxDersRenk() { ID = "3", Name = "Kırmızı" });
            list1.Add(new ComboBoxDersRenk() { ID = "4", Name = "Yeşil" });
            list1.Add(new ComboBoxDersRenk() { ID = "5", Name = "Sarı" });
            list1.Add(new ComboBoxDersRenk() { ID = "6", Name = "Mavi" });
            list1.Add(new ComboBoxDersRenk() { ID = "7", Name = "Pembe" });
            list1.Add(new ComboBoxDersRenk() { ID = "8", Name = "Gri" });
            list1.Add(new ComboBoxDersRenk() { ID = "9", Name = "Kahverengi" });
            list1.Add(new ComboBoxDersRenk() { ID = "10", Name = "Turuncu" });
            list1.Add(new ComboBoxDersRenk() { ID = "11", Name = "Mor" });

            cmbRenk.DataSource = list1;
            cmbRenk.DisplayMember = "Name";
            cmbRenk.ValueMember = "ID";
        }

        private void btnDersKaydet_Click(object sender, EventArgs e)
        {
            //Araçlara girilen verileri veritabanına kaydetmeye yarar.

            Ders drs = new Ders();
            drs.Ad = txtDersAd.Text;
            drs.Kredisi = int.Parse(cmbDersKredi.SelectedValue.ToString());
            drs.OkulYonetimId = int.Parse(cmbEğitmen.SelectedValue.ToString());
            drs.DersRenk = int.Parse(cmbRenk.SelectedValue.ToString());
            db.Ders.Add(drs);
            db.SaveChanges();
            MessageBox.Show("Ders Eklendi");
        }

        private void btnDersGüncelle_Click(object sender, EventArgs e)
        {
            //Seçilmiş "Id" değerine ait olan verileri veritabanda güncellemeye yarar.

            int x = Convert.ToInt32(labelId.Text);
            var drs = db.Ders.Find(x);
            drs.Ad = txtDersAd.Text;
            drs.Kredisi = int.Parse(cmbDersKredi.SelectedValue.ToString());
            drs.OkulYonetimId = int.Parse(cmbEğitmen.SelectedValue.ToString());
            drs.DersRenk = int.Parse(cmbRenk.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ders Güncellendi");
        }

        private void btnDersSil_Click(object sender, EventArgs e)
        {
            //Seçilmiş "Id" değerine ait olan verileri veritabanından silmeye yarar.

            int x = Convert.ToInt32(labelId.Text);
            var drs = db.Ders.Find(x);
            db.Ders.Remove(drs);
            db.SaveChanges();
            MessageBox.Show("Ders Silindi");
        }

        


    }

    //Aşağıdaki kodları derleyici oluşturuyor onlar olmadan işlem yapamıyorum.
    internal class ComboBoxDersRenk
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }

    internal class ComboBoxDersKredi
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}
