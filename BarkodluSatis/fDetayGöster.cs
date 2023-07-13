using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluSatis
{
    public partial class fDetayGöster : Form
    {
        public fDetayGöster()
        {
            InitializeComponent();
        }
        public int islemno { get; set; }
        private void fDetayGöster_Load(object sender, EventArgs e)
        {
            lIslemNo.Text = "İşlem No : " + islemno.ToString();
            using (var db=new BarkodDbEntities())
            {
                gridListe.DataSource = db.Satis.Select(s=> new {s.IslemNo,s.UrunAd,s.UrunGrup,s.Miktar,s.Toplam}).Where(x => x.IslemNo == islemno).ToList();
                Islemler.GridDuzenle(gridListe); //grid başlıkları düzenlendi
            }
        }
    }
}
