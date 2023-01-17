using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sadettin_Dursun_20200108033_Final
{
    public partial class Personel_Listele : Form
    {
        public Personel_Listele()
        {
            InitializeComponent();
        }

        /* Bu form personelleri listeleme,arama,sıralama işlemlerini yapmaktadır.
        Ayrıca formun üzerindeki datagridwiev'e iki kere tıklarsanız bu verileri
        personel ekle,sil,güncelle işlemlerinin yapıldığı formu açar ve tıkladığınız hücredeki
        verileri o formdaki araçlara atar.*/

        OkulYonetimEntities2 db = new OkulYonetimEntities2();

        private void Personel_Listele_Load(object sender, EventArgs e)
        {

            /*Form yüklenirken "cmbFiltre,cmbSütun,cmbÖlçü" araçlarına 
            "Enum" yapısında veriler atanır. Ayrıca dataGridViewPersonel aracına
            "Personel" tablosunun verileri taşınır.
            */
            List<ComboBoxFiltre> list = new List<ComboBoxFiltre>();

            list.Add(new ComboBoxFiltre() { ID = "1", Name = "İsim" });
            list.Add(new ComboBoxFiltre() { ID = "2", Name = "Görev" });
            list.Add(new ComboBoxFiltre() { ID = "3", Name = "Departman" });
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

            dataGridViewPersonel.DataSource = (from x in db.Personel select new {
                x.Id,
                x.AdSoyad, 
                x.Gorevi, 
                x.YonetimTip 
            }).ToList();

        }
        internal class ComboBoxFiltre
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }
        private void btnYenile_Click(object sender, EventArgs e)
        {
            /*"dataGridViewPersonel" aracına "Personel" tablosundan veriler aktarılır,
             yapılan değişikliğin görünmesi için kullanılır.*/

            dataGridViewPersonel.DataSource = (from x in db.Personel select new {
                x.Id,
                x.AdSoyad, 
                x.Gorevi, 
                x.YonetimTip 
            }).ToList();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            /*"txtAra" isimli textbox arama yapma maksatlı kullanılmaktadır,
             bu kodlar bu arama işlemi içerisinde filtre işlemi için kullanılır.*/

            string aranan = txtAra.Text;
            if (cmbFiltre.Text == "İsim")
            {
                var degerler = from item in db.Personel
                               where item.AdSoyad.Contains(aranan)
                               select new { item.AdSoyad, item.Gorevi, item.YonetimTip };
                dataGridViewPersonel.DataSource = degerler.ToList();
            }
            if (cmbFiltre.Text == "Görev")
            {
                var degerler = from item in db.Personel
                               where item.Gorevi.Contains(aranan)
                               select new { item.AdSoyad, item.Gorevi, item.YonetimTip };
                dataGridViewPersonel.DataSource = degerler.ToList();
            }
            if (cmbFiltre.Text == "Departman")
            {
                var degerler = from item in db.Personel
                               where item.YonetimTip.ToString().Contains(aranan)
                               select new { item.AdSoyad, item.Gorevi, item.YonetimTip };
                dataGridViewPersonel.DataSource = degerler.ToList();
            }
            if (cmbFiltre.Text == "Tümü")
            {
                var degerler = from item in db.Personel
                               where item.AdSoyad.Contains(aranan) || item.Gorevi.Contains(aranan) || item.YonetimTip.ToString().Contains(aranan)
                               select new { item.AdSoyad, item.Gorevi, item.YonetimTip };
                dataGridViewPersonel.DataSource = degerler.ToList();
            }


        }

        private void btnSırala_Click(object sender, EventArgs e)
        {
            /*Aşağıdaki kod "btnSırala" isimli objeye tıklandığı zaman aktif olur.
            Bu kod "dataGridViewPersonel" objesi içinde koşullu sıralama işlemi yapar.*/

            var data = (from x in db.Personel
                        select new { 
                            x.Id,
                            x.AdSoyad, 
                            x.Gorevi, 
                            x.YonetimTip 
                        }).ToList();
            if (cmbÖlçü.Text == "A-Z")
            {
                data = data.OrderBy(x => x.AdSoyad).ToList();
            }
            else if (cmbÖlçü.Text == "Z-A")
            {
                data = data.OrderByDescending(x => x.AdSoyad).ToList();
            }
            dataGridViewPersonel.DataSource = data;
        }

        private void dataGridViewPersonel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Aşağıdaki kod "dataGridViewPersonel" nesnesindeki bir hücreye iki kez tıklandığında tetiklenir.
            İşlevi ise kaydet,güncelle ve sil işlemlerinin yapıldığı vindows formunu açıp bu formdaki araçlara
            verileri taşır.*/

            int selected = dataGridViewPersonel.SelectedCells[0].RowIndex;
            Personel_İşlemleri personel = new Personel_İşlemleri();

            personel.labelId.Text = dataGridViewPersonel.Rows[selected].Cells[0].Value.ToString();
            personel.txtPersonelAd.Text = dataGridViewPersonel.Rows[selected].Cells[1].Value.ToString();
            personel.txtGörev.Text = dataGridViewPersonel.Rows[selected].Cells[2].Value.ToString();
            personel.cmbDepartman.Text = dataGridViewPersonel.Rows[selected].Cells[3].Value.ToString();

            personel.MdiParent = this.MdiParent;
            personel.Show();
        }
    }
}
