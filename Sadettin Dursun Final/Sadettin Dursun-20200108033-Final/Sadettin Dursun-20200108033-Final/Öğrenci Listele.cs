using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sadettin_Dursun_20200108033_Final.Personel_Listele;

namespace Sadettin_Dursun_20200108033_Final
{
    public partial class Öğrenci_Listele : Form
    {
        public Öğrenci_Listele()
        {
            InitializeComponent();
        }

        /* Bu form öğrencileri listeleme,arama,sıralama işlemlerini yapmaktadır.
        Ayrıca formun üzerindeki datagridwiev'e iki kere tıklarsanız bu verileri
        öğrenci ekle,sil,güncelle işlemlerinin yapıldığı formu açar ve tıkladığınız hücredeki
        verileri o formdaki araçlara atar.*/

        OkulYonetimEntities2 db = new OkulYonetimEntities2();
        private void Öğrenci_Listele_Load(object sender, EventArgs e)
        {
            /*Form yüklenirken "cmbFiltre,cmbSütun,cmbÖlçü" araçlarına 
            "Enum" yapısında veriler atanır. Ayrıca dataGridViewOgr aracına
            "Ogrenci" tablosunun verileri taşınır.*/

            List<ComboBoxFiltre> list = new List<ComboBoxFiltre>();
            list.Add(new ComboBoxFiltre() { ID = "1", Name = "Ad-Soyad" });
            list.Add(new ComboBoxFiltre() { ID = "2", Name = "Öğrenci No" });
            list.Add(new ComboBoxFiltre() { ID = "3", Name = "Bölüm" });
            list.Add(new ComboBoxFiltre() { ID = "4", Name = "Tümü" });

            cmbFiltre.DataSource = list;
            cmbFiltre.DisplayMember = "Name";
            cmbFiltre.ValueMember = "ID";

            List<ComboBoxFiltre> list1 = new List<ComboBoxFiltre>();

            list1.Add(new ComboBoxFiltre() { ID = "1", Name = "Ad-Soyad" });

            cmbSütun.DataSource = list1;
            cmbSütun.DisplayMember = "Name";
            cmbSütun.ValueMember = "ID";

            List<ComboBoxFiltre> list2 = new List<ComboBoxFiltre>();

            list2.Add(new ComboBoxFiltre() { ID = "1", Name = "A-Z" });
            list2.Add(new ComboBoxFiltre() { ID = "2", Name = "Z-A" });

            cmbÖlçü.DataSource = list2;
            cmbÖlçü.DisplayMember = "Name";
            cmbÖlçü.ValueMember = "ID";

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

        private void btnYenile_Click(object sender, EventArgs e)
        {
            /*"dataGridViewOgr" aracına "Ogrenci" tablosundan veriler aktarılır,
             yapılan değişikliğin görünmesi için kullanılır.*/

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

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            /*"txtAra" isimli textbox arama yapma maksatlı kullanılmaktadır,
            bu kodlar bu arama işlemi içerisinde filtre işlemi için kullanılır.*/

            string aranan = txtAra.Text;
            if (cmbFiltre.Text == "Ad-Soyad")
            {
                var degerler = from item in db.Ogrenci
                               where item.AdSoyad.Contains(aranan)
                               select new { item.AdSoyad, item.OgrenciNo, item.Bolum };
                dataGridViewOgr.DataSource = degerler.ToList();
            }
            if (cmbFiltre.Text == "Öğrenci No")
            {
                var degerler = from item in db.Ogrenci
                               where item.OgrenciNo.Contains(aranan)
                               select new { item.AdSoyad, item.OgrenciNo, item.Bolum };
                dataGridViewOgr.DataSource = degerler.ToList();
            }
            if (cmbFiltre.Text == "Bölüm")
            {
                var degerler = from item in db.Ogrenci
                               where item.Bolum.ToString().Contains(aranan)
                               select new { item.AdSoyad, item.OgrenciNo, item.Bolum };
                dataGridViewOgr.DataSource = degerler.ToList();
            }
            if (cmbFiltre.Text == "Tümü")
            {
                var degerler = from item in db.Ogrenci
                               where item.AdSoyad.Contains(aranan) || item.OgrenciNo.Contains(aranan) || item.Bolum.ToString().Contains(aranan)
                               select new { item.AdSoyad, item.OgrenciNo, item.Bolum };
                dataGridViewOgr.DataSource = degerler.ToList();
            }

        }

        private void btnSırala_Click(object sender, EventArgs e)
        {
            /*Aşağıdaki kod "btnSırala" isimli objeye tıklandığı zaman aktif olur.
           Bu kod "dataGridViewOgr" objesi içinde koşullu sıralama işlemi yapar.*/

            var data = (from x in db.Ogrenci
                        select new { 
                            x.Id,
                            x.AdSoyad,
                            x.KayitTarih,
                            x.OgrenciNo,
                            x.DTarih,
                            x.Bolum
                        }).ToList();
            if (cmbÖlçü.Text == "A-Z")
            {
                data = data.OrderBy(x => x.AdSoyad).ToList();
            }
            else if (cmbÖlçü.Text == "Z-A")
            {
                data = data.OrderByDescending(x => x.AdSoyad).ToList();
            }
            dataGridViewOgr.DataSource = data;
        }

        private void dataGridViewOgr_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Aşağıdaki kod "dataGridViewOgr" nesnesindeki bir hücreye iki kez tıklandığında tetiklenir.
            İşlevi ise kaydet,güncelle ve sil işlemlerinin yapıldığı vindows formunu açıp bu formdaki araçlara
            verileri taşır.*/

            int selected = dataGridViewOgr.SelectedCells[0].RowIndex;
            Öğrenci öğrenci = new Öğrenci();

            öğrenci.lblId.Text = dataGridViewOgr.Rows[selected].Cells[0].Value.ToString();
            öğrenci.txtÖgrAd.Text = dataGridViewOgr.Rows[selected].Cells[1].Value.ToString();
            öğrenci.kytTarih.Text = dataGridViewOgr.Rows[selected].Cells[2].Value.ToString();
            öğrenci.mskÖgrNo.Text = dataGridViewOgr.Rows[selected].Cells[3].Value.ToString();
            öğrenci.dTarih.Text = dataGridViewOgr.Rows[selected].Cells[4].Value.ToString();
            öğrenci.cmbBölüm.Text = dataGridViewOgr.Rows[selected].Cells[5].Value.ToString();

            öğrenci.MdiParent = this.MdiParent;
            öğrenci.Show();
        }
    }
}
