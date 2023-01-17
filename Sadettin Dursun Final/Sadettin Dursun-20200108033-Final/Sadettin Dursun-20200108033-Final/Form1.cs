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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void personelİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Personel penceremizi ana formumuza çağırıyoruz
            Personel_İşlemleri ekle = new Personel_İşlemleri();
            ekle.MdiParent = this;
            ekle.Show();
        }

        private void personelListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Personel litele penceremizi ana formumuza çağırıyoruz
            Personel_Listele ekle = new Personel_Listele();
            ekle.MdiParent = this;
            ekle.Show();
        }

        private void dersİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ders penceremizi ana formumuza çağırıyoruz
            Ders_İşlemleri ekle = new Ders_İşlemleri();
            ekle.MdiParent = this;
            ekle.Show();
        }

        private void dersleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ders listele penceremizi ana formumuza çağırıyoruz
            Ders_Listele ekle = new Ders_Listele();
            ekle.MdiParent = this;
            ekle.Show();
        }

        private void öğrenciEkleSilGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Öğrenci penceremizi ana formumuza çağırıyoruz
            Öğrenci ekle = new Öğrenci();
            ekle.MdiParent = this;
            ekle.Show();
        }

        private void öğrenciListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Öğrenci listele penceremizi ana formumuza çağırıyoruz
            Öğrenci_Listele ekle = new Öğrenci_Listele();
            ekle.MdiParent = this;
            ekle.Show();
        }

        private void öğrencilereDersİliştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Öğrenci-Ders penceremizi ana formumuza çağırıyoruz
            Öğrenci_Ders ekle = new Öğrenci_Ders();
            ekle.MdiParent = this;
            ekle.Show();
        }

        private void öğrencilerVeDersleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Öğrenci-Ders listele penceremizi ana formumuza çağırıyoruz
            Öğrenci_Ders_Listele ekle = new Öğrenci_Ders_Listele();
            ekle.MdiParent = this;
            ekle.Show();
        }
    }
}
