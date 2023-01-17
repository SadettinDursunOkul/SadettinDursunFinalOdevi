using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sadettin_Dursun_20200108033_Final.Personel_Listele;

namespace Sadettin_Dursun_20200108033_Final
{
    public partial class Ders_Listele : Form
    {
        public Ders_Listele()
        {
            InitializeComponent();
        }

        /* Bu form dersleri listeleme,arama,sıralama işlemlerini yapmaktadır.
        Ayrıca formun üzerindeki datagridwiev'e iki kere tıklarsanız bu verileri
        ders ekle,sil,güncelle işlemlerinin yapıldığı formu açar ve tıkladığınız hücredeki
        verileri o formdaki araçlara atar.*/

        OkulYonetimEntities2 db = new OkulYonetimEntities2();

     
        private void Ders_Listele_Load(object sender, EventArgs e)
        {

            /*Form yüklenirken "cmbFiltre,cmbSütun,cmbÖlçü" araçlarına 
            "Enum" yapısında veriler atanır. Ayrıca dataGridViewDrs aracına
            "Ders" tablosunun verileri taşınır.*/

            List<ComboBoxFiltre> list = new List<ComboBoxFiltre>();
            list.Add(new ComboBoxFiltre() { ID = "1", Name = "Ders Ad" });
            list.Add(new ComboBoxFiltre() { ID = "2", Name = "Ders Kredi" });
            list.Add(new ComboBoxFiltre() { ID = "3", Name = "Eğitmen" });
            list.Add(new ComboBoxFiltre() { ID = "4", Name = "Renk" });
            list.Add(new ComboBoxFiltre() { ID = "5", Name = "Tümü" });

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

            dataGridViewDrs.DataSource = (from x in db.Ders
                                          select new
                                          {
                                              x.Id,
                                              x.Ad,
                                              x.Kredisi,
                                              x.Personel.AdSoyad,
                                              x.DersRenk

                                          }).ToList();

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            /*"dataGridViewDrs" aracına "Ders" tablosundan veriler aktarılır,
             yapılan değişikliğin görünmesi için kullanılır.*/

            dataGridViewDrs.DataSource = (from x in db.Ders
                                          select new
                                          {
                                              x.Id,
                                              x.Ad,
                                              x.Kredisi,
                                              x.Personel.AdSoyad,
                                              x.DersRenk

                                          }).ToList();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            /*"txtAra" isimli textbox arama yapma maksatlı kullanılmaktadır,
             bu kodlar bu arama işlemi içerisinde filtre işlemi için kullanılır.*/

            string aranan = txtAra.Text;
            if (cmbFiltre.Text == "Ders Ad")
            {
                var degerler = from item in db.Ders
                               where item.Ad.Contains(aranan)
                               select new { item.Ad, item.Kredisi, item.Personel.AdSoyad, item.DersRenk };
                dataGridViewDrs.DataSource = degerler.ToList();
            }
            if (cmbFiltre.Text == "Ders Kredi")
            {
                var degerler = from item in db.Ders
                               where item.Kredisi.Value.ToString().Contains(aranan)
                               select new { item.Ad, item.Kredisi, item.Personel.AdSoyad, item.DersRenk };
                dataGridViewDrs.DataSource = degerler.ToList();
            }
            if (cmbFiltre.Text == "Eğitmen")
            {
                var degerler = from item in db.Ders
                               where item.Personel.AdSoyad.Contains(aranan)
                               select new { item.Ad, item.Kredisi, item.Personel.AdSoyad, item.DersRenk };
                dataGridViewDrs.DataSource = degerler.ToList();
            }
            if (cmbFiltre.Text == "Renk")
            {
                var degerler = from item in db.Ders
                               where item.DersRenk.ToString().Contains(aranan)
                               select new { item.Ad, item.Kredisi, item.Personel.AdSoyad, item.DersRenk };
                dataGridViewDrs.DataSource = degerler.ToList();
            }
            if (cmbFiltre.Text == "Tümü")
            {
                var degerler = from item in db.Ders
                               where item.Ad.Contains(aranan) || item.Kredisi.Value.ToString().Contains(aranan) || item.Personel.AdSoyad.Contains(aranan) || item.DersRenk.ToString().Contains(aranan)
                               select new { item.Ad, item.Kredisi, item.Personel.AdSoyad, item.DersRenk };
                dataGridViewDrs.DataSource = degerler.ToList();
            }

        }

        private void btnSırala_Click(object sender, EventArgs e)
        {
            /*Aşağıdaki kod "btnSırala" isimli objeye tıklandığı zaman aktif olur.
            Bu kod "dataGridViewDrs" objesi içinde koşullu sıralama işlemi yapar.*/

            var data = (from x in db.Ders
                        select new
                        {
                            x.Id,
                            x.Ad,
                            x.Kredisi,
                            x.Personel.AdSoyad,
                            x.DersRenk
                        }).ToList();
            if (cmbÖlçü.Text == "A-Z")
            {
                data = data.OrderBy(x => x.Ad).ToList();
            }
            else if (cmbÖlçü.Text == "Z-A")
            {
                data = data.OrderByDescending(x => x.Ad).ToList();
            }
            dataGridViewDrs.DataSource = data;
        }

        private void dataGridViewDrs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Aşağıdaki kod "dataGridViewDrs" nesnesindeki bir hücreye iki kez tıklandığında tetiklenir.
            İşlevi ise kaydet,güncelle ve sil işlemlerinin yapıldığı vindows formunu açıp bu formdaki araçlara
            verileri taşır.*/

            int selected = dataGridViewDrs.SelectedCells[0].RowIndex;
            Ders_İşlemleri ders_İşlemleri = new Ders_İşlemleri();

            ders_İşlemleri.labelId.Text = dataGridViewDrs.Rows[selected].Cells[0].Value.ToString();
            ders_İşlemleri.txtDersAd.Text = dataGridViewDrs.Rows[selected].Cells[1].Value.ToString();
            ders_İşlemleri.cmbDersKredi.Text = dataGridViewDrs.Rows[selected].Cells[2].Value.ToString();
            ders_İşlemleri.cmbEğitmen.Text = dataGridViewDrs.Rows[selected].Cells[3].Value.ToString();
            ders_İşlemleri.cmbRenk.Text = dataGridViewDrs.Rows[selected].Cells[4].Value.ToString();

            ders_İşlemleri.MdiParent = this.MdiParent;
            ders_İşlemleri.Show();

        }

        private void dataGridViewDrs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Aşağıdaki kod "dataGridViewDrs" nesnesindeki "DersRenk" sütununu renklendirir.

            if (e.ColumnIndex == 4 && e.RowIndex != -1) // Renk sütununun kolon indeksi ve satır indeksi kontrol edilir
            {
                string renk = dataGridViewDrs.Rows[e.RowIndex].Cells[4].Value.ToString(); // Sütun değerini alır

                if (renk == "1")
                {
                    e.CellStyle.BackColor = Color.Black;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (renk == "2")
                {
                    e.CellStyle.BackColor = Color.White;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (renk == "3")
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else if (renk == "4")
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (renk == "5")
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
                else if (renk == "6")
                {
                    e.CellStyle.BackColor = Color.Blue;
                }
                else if (renk == "7")
                {
                    e.CellStyle.BackColor = Color.Pink;
                }
                else if (renk == "8")
                {
                    e.CellStyle.BackColor = Color.Gray;
                }
                else if (renk == "9")
                {
                    e.CellStyle.BackColor = Color.Brown;
                }
                else if (renk == "10")
                {
                    e.CellStyle.BackColor = Color.Orange;
                }
                else if (renk == "11")
                {
                    e.CellStyle.BackColor = Color.Purple;
                }
                // diğer renkler için benzer şekilde koşullar yazılabilir
            }
        }
    }
    
}

