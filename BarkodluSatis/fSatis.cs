﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluSatis
{
    public partial class fSatis : Form
    {
        public fSatis()
        {
            InitializeComponent();
        }
        private void fSatis_Load(object sender, EventArgs e)
        {
            HizliButonDoldur(); //para birim
            b5.Text = 5.ToString("C2");
            b10.Text = 10.ToString("C2");
            b20.Text = 20.ToString("C2");
            b50.Text = 50.ToString("C2");
            b100.Text = 100.ToString("C2");
            b200.Text = 200.ToString("C2");
            using (var db = new BarkodDbEntities())
            {
                var sabit = db.Sabit.FirstOrDefault();
                chYazdirmaDurumu.Checked = Convert.ToBoolean(sabit.Yazici);
            }
        }

        private void HizliButonDoldur() //25 butonumuzu hizlibutondoldur metodumuza tanımlıyoruz ve tablodan alıyoruz 
        {
            var hizliurun = db.HizliUrun.ToList();//db içerisinden listele 
            foreach (var item in hizliurun)
            {
                Button bh = this.Controls.Find("bH" + item.Id, true).FirstOrDefault() as Button;
                if (bh != null)
                {
                    double fiyat = Islemler.DoubleYap(item.Fiyat.ToString());
                    bh.Text = item.UrunAd + "\n" + fiyat.ToString("C2");
                }
            }
        }

        private void HizliButonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int butonid = Convert.ToUInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));

            if (b.Text.ToString().StartsWith("-"))  //butonun texti - ile başlıyorsa işlem yap
            {
                fHizliButonUrunEkle f = new fHizliButonUrunEkle(); //form
                f.lButonId.Text = butonid.ToString();
                f.ShowDialog();
            }
            else
            {
                var urunbarkod = db.HizliUrun.Where(a => a.Id == butonid).Select(a => a.Barkod).FirstOrDefault(); //sadece barkod alanını seçtik ürünbarkod değişkenimize gelecek
                var urun = db.Urun.Where(a => a.Barkod == urunbarkod).FirstOrDefault();
                UrunGetirListeye(urun, urunbarkod, Convert.ToDouble(tMiktar.Text));
                GenelToplam();
            }
        }

        BarkodDbEntities db = new BarkodDbEntities(); //veritabanamızı tanıttık 

        private void tBarkod_KeyDown(object sender, KeyEventArgs e) //barkod kutusunda enter basıldığında
        {
            if (e.KeyCode == Keys.Enter) //tbarkoda enter eventini atama
            {
                string barkod = tBarkod.Text.Trim(); //barkod 2 karakter yada 2 karakterden küçükse miktar olarak aktarıyoruz
                if (barkod.Length <= 2)
                {
                    tMiktar.Text = barkod;
                    tBarkod.Clear();
                    tBarkod.Focus();
                }
                else //eğer barkod 2 karakterden fazlaysa ürünü arıyoruz
                {
                    if (db.Urun.Any(a => a.Barkod == barkod)) //bize true false değeri veriyor any //barkood varmı var ise 
                    {
                        var urun = db.Urun.Where(a => a.Barkod == barkod).FirstOrDefault();
                        UrunGetirListeye(urun, barkod, Convert.ToDouble(tMiktar.Text)); //listede ürün var ise bu işlem yapılacak
                    }
                    else  // eğer yoksa öneki alıyoruz ve teraziyi kontrol ediyoruz 
                    {
                        int onek = Convert.ToInt32(barkod.Substring(0, 2));
                        if (db.Terazi.Any(a => a.TeraziOnEk == onek))
                        {
                            string teraziurunno = barkod.Substring(2, 5);
                            if (db.Urun.Any(a => a.Barkod == teraziurunno))
                            {
                                var urunterazi = db.Urun.Where(a => a.Barkod == teraziurunno).FirstOrDefault();
                                double miktarkg = Convert.ToDouble(barkod.Substring(7, 5)) / 1000;
                                UrunGetirListeye(urunterazi, teraziurunno, miktarkg);
                            }
                            else //eğer kg ürün yok ise
                            {
                                Console.Beep(900, 2000);
                                MessageBox.Show("Kg Ürün Ekleme Sayfası"); //kg ürün ekleme sayfası yapılacak
                            }

                        }
                        else //eğer normal ürün yok ise 
                        {
                            Console.Beep(900, 2000);
                            fUrunGiris f = new fUrunGiris(); //ürün ekleme formu tanıttık
                            f.tBarkod.Text = barkod; // ürün ekleme sayfasındaki barkodu public yapıp satış sayfasındaki barkodu aktardık
                            f.ShowDialog();
                        }
                    }
                }
                gridSatisListesi.ClearSelection();
                GenelToplam();
            }
        }

        private void UrunGetirListeye(Urun urun, string barkod, double miktar)
        {
            int satirsayisi = gridSatisListesi.Rows.Count; //Gridin satır sayısını aldık
                                                           // double miktar = Convert.ToDouble(tMiktar.Text);
            bool eklenmismi = false;
            if (satirsayisi > 0)
            {
                for (int i = 0; i < satirsayisi; i++)   //aynı ürün ekleme miktar ve toplam değişecek
                {
                    if (gridSatisListesi.Rows[i].Cells["Barkod"].Value.ToString() == barkod)  //veritabanından barkod okuma 
                    {
                        gridSatisListesi.Rows[i].Cells["Miktar"].Value = miktar + Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Miktar"].Value); //miktar belirleme miktarın üstüne yeni eklenen miktarları ekleme 2. okuttuğum miktarla mevcut miktarı toplayacak ve yazacak
                        gridSatisListesi.Rows[i].Cells["Toplam"].Value = Math.Round(Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Miktar"].Value) * Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Fiyat"].Value), 2);

                        double dblKdvTutari = (double)urun.KdvTutari;
                        gridSatisListesi.Rows[i].Cells["KdvTutari"].Value = Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Miktar"].Value) * dblKdvTutari;
                        eklenmismi = true;
                    }
                }
            }
            if (!eklenmismi)
            {
                gridSatisListesi.Rows.Add(); //gridsatislistesine satır ekliyoruz ilk aşamada satır yok 
                gridSatisListesi.Rows[satirsayisi].Cells["Barkod"].Value = barkod; //barkodu veritabanından değil değişkenden alıyoruz
                gridSatisListesi.Rows[satirsayisi].Cells["UrunAdi"].Value = urun.UrunAd; //tanımladığmız veritabanından verilerimizi alıyoruz
                gridSatisListesi.Rows[satirsayisi].Cells["UrunGrup"].Value = urun.UrunGrup;
                gridSatisListesi.Rows[satirsayisi].Cells["Birim"].Value = urun.Birim;
                gridSatisListesi.Rows[satirsayisi].Cells["Fiyat"].Value = urun.SatisFiyat;
                gridSatisListesi.Rows[satirsayisi].Cells["Miktar"].Value = miktar; //miktarı veritabanından değil tanımladığımız değişkenden alıyoruz
                gridSatisListesi.Rows[satirsayisi].Cells["Toplam"].Value = Math.Round(miktar * (double)urun.SatisFiyat, 2);
                gridSatisListesi.Rows[satirsayisi].Cells["AlisFiyati"].Value = urun.AlisFiyat;
                gridSatisListesi.Rows[satirsayisi].Cells["KdvTutari"].Value = urun.KdvTutari;
            }
        }

        private void GenelToplam()
        {
            double toplam = 0;  //grid satırı 0 dan büyük ise 
            for (int i = 0; i < gridSatisListesi.Rows.Count; i++)
            {
                toplam += Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Toplam"].Value); //toplam değişkenini arttır
            }
            tGenelToplam.Text = toplam.ToString("C2"); //c2 para birimi 
            tMiktar.Text = "1";
            tBarkod.Clear();
            tBarkod.Focus();
        }

        private void gridSatisListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9) //grid satış listesinden ürün silme 9. index sil image
            {
                gridSatisListesi.Rows.Remove(gridSatisListesi.CurrentRow);
                gridSatisListesi.ClearSelection();
                GenelToplam();
                tBarkod.Focus();
            }
        }

        private void Bh_MouseDown(object sender, MouseEventArgs e) //hizlibuton sağ clicl sil
        {
            if (e.Button == MouseButtons.Right)
            {
                Button b = (Button)sender;
                if (!b.Text.StartsWith("-"))
                {
                    int butonid = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));
                    ContextMenuStrip s = new ContextMenuStrip();
                    ToolStripMenuItem sil = new ToolStripMenuItem();
                    sil.Text = "Temizle - Buton No:" + butonid.ToString();
                    sil.Click += Sil_Click;
                    s.Items.Add(sil);
                    this.ContextMenuStrip = s;
                }
            }
        }

        private void Sil_Click(object sender, EventArgs e)
        {
            int butonid = Convert.ToInt16(sender.ToString().Substring(19, sender.ToString().Length - 19));
            var guncelle = db.HizliUrun.Find(butonid);
            guncelle.Barkod = "-";
            guncelle.UrunAd = "-";
            guncelle.Fiyat = 0;
            db.SaveChanges();
            double fiyat = 0;
            Button b = this.Controls.Find("bH" + butonid, true).FirstOrDefault() as Button;
            b.Text = "-" + "\n" + fiyat.ToString("C2");

        }

        private void bNx_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == ",")
            {
                int virgül = tNumarator.Text.Count(x => x == ',');
                if (virgül < 1)
                {
                    tNumarator.Text += b.Text;
                }
            }
            else if (b.Text == "<")
            {
                if (tNumarator.Text.Length > 0)
                {
                    tNumarator.Text = tNumarator.Text.Substring(0, tNumarator.Text.Length - 1);
                }
            }
            else
            {
                tNumarator.Text += b.Text;
            }
        }

        private void bAdet_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                tMiktar.Text = tNumarator.Text;
                tNumarator.Clear();
                tBarkod.Clear();
                tBarkod.Focus();
            }
        }

        private void bOdenen_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                double sonuc = Islemler.DoubleYap(tNumarator.Text) - Islemler.DoubleYap(tGenelToplam.Text);
                tParaUstu.Text = sonuc.ToString("C2");
                tOdenen.Text = Islemler.DoubleYap(tNumarator.Text).ToString("C2");
                tNumarator.Clear();
                tBarkod.Focus();
            }
        }

        private void bBarkod_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                if (db.Urun.Any(a => a.Barkod == tNumarator.Text))
                {
                    var urun = db.Urun.Where(a => a.Barkod == tNumarator.Text).FirstOrDefault();
                    UrunGetirListeye(urun, tNumarator.Text, Convert.ToDouble(tMiktar.Text));
                    tNumarator.Clear();
                    tBarkod.Focus();
                }
                else
                {
                    MessageBox.Show("Ürün Ekleme Sayfasını Aç");
                }
            }
        }

        private void ParaUstuHesapla_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            double sonuc = Islemler.DoubleYap(b.Text) - Islemler.DoubleYap(tGenelToplam.Text);
            tOdenen.Text = Islemler.DoubleYap(b.Text).ToString("C2");
            tParaUstu.Text = sonuc.ToString("C2");
        }

        private void bDigerUrun_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                int satirsayisi = gridSatisListesi.Rows.Count;
                gridSatisListesi.Rows.Add();
                gridSatisListesi.Rows[satirsayisi].Cells["Barkod"].Value = "1111111111116";
                gridSatisListesi.Rows[satirsayisi].Cells["UrunAdi"].Value = "Barkodsuz Ürün";
                gridSatisListesi.Rows[satirsayisi].Cells["UrunGrup"].Value = "Barkodsuz Ürün";
                gridSatisListesi.Rows[satirsayisi].Cells["Birim"].Value = "Adet";
                gridSatisListesi.Rows[satirsayisi].Cells["Miktar"].Value = 1;
                gridSatisListesi.Rows[satirsayisi].Cells["AlisFiyati"].Value = 0;
                gridSatisListesi.Rows[satirsayisi].Cells["Fiyat"].Value = Convert.ToDouble(tNumarator.Text);
                gridSatisListesi.Rows[satirsayisi].Cells["KdvTutari"].Value = 0;
                gridSatisListesi.Rows[satirsayisi].Cells["Toplam"].Value = Convert.ToDouble(tNumarator.Text);
                tNumarator.Text = "";
                GenelToplam();
                tBarkod.Focus(); ;

            }
        }

        private void bIade_Click(object sender, EventArgs e)
        {
            if (chSatisIadeIslemi.Checked)
            {
                chSatisIadeIslemi.Checked = false;
                chSatisIadeIslemi.Text = "Satış Yapılıyor";

            }
            else
            {
                chSatisIadeIslemi.Checked = true;
                chSatisIadeIslemi.Text = "İade İşlemi";
            }
        }

        private void bTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void Temizle()
        {
            tMiktar.Text = "1";
            tBarkod.Clear();
            tOdenen.Clear();
            tParaUstu.Clear();
            tGenelToplam.Clear();
            tGenelToplam.Text = 0.ToString("C2");
            chSatisIadeIslemi.Checked = false;
            tNumarator.Clear();
            gridSatisListesi.Rows.Clear();
            tBarkod.Clear();
            tBarkod.Focus();
        } //temizleme 

        public void SatisYap(string odemesekli) //ödemeler için 
        {
            int satirsayisi = gridSatisListesi.Rows.Count;
            bool satisiade = chSatisIadeIslemi.Checked;
            double alisfiyattoplam = 0;

            if (satirsayisi > 0)
            {
                int? islemno = db.Islem.First().IslemNo;
                Satis satis = new Satis();
                for (int i = 0; i < satirsayisi; i++)
                {
                    satis.IslemNo = islemno;
                    satis.UrunAd = gridSatisListesi.Rows[i].Cells["UrunAdi"].Value.ToString();
                    satis.UrunGrup = gridSatisListesi.Rows[i].Cells["UrunGrup"].Value.ToString();
                    satis.Barkod = gridSatisListesi.Rows[i].Cells["Barkod"].Value.ToString();
                    satis.Birim = gridSatisListesi.Rows[i].Cells["Birim"].Value.ToString();
                    satis.AlisFiyat = Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["AlisFiyati"].Value.ToString());
                    satis.SatisFiyat = Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["Fiyat"].Value.ToString());
                    satis.Miktar = Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["Miktar"].Value.ToString());
                    satis.Toplam = Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["Toplam"].Value.ToString());
                    satis.KdvTutari = Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["KdvTutari"].Value.ToString()) * Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["Miktar"].Value.ToString());
                    satis.OdemeSekli = odemesekli;
                    satis.Iade = satisiade;
                    satis.Tarih = DateTime.Now;
                    satis.Kullanici = lKullanici.Text;
                    db.Satis.Add(satis);
                    db.SaveChanges();
                    if (!satisiade)
                    {
                        Islemler.StokAzalt(gridSatisListesi.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["Miktar"].Value.ToString()));
                    }
                    else
                    {
                        Islemler.StokArtir(gridSatisListesi.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["Miktar"].Value.ToString()));
                    }
                    alisfiyattoplam += Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["AlisFiyati"].Value.ToString()) * Islemler.DoubleYap(gridSatisListesi.Rows[i].Cells["Miktar"].Value.ToString());
                }

                IslemOzet io = new IslemOzet();
                io.IslemNo = islemno;
                io.Iade = satisiade;
                io.AlisFiyatToplam = alisfiyattoplam;
                io.Gelir = false;
                io.Gider = false;
                if (!satisiade)
                {
                    io.Aciklama = odemesekli + " Satış";
                }
                else
                {
                    io.Aciklama = "İade İşlemi(" + odemesekli + ")";
                }
                io.OdemeSekli = odemesekli;
                io.Kullanici = lKullanici.Text;
                io.Tarih = DateTime.Now;
                switch (odemesekli)
                {
                    case "Nakit":
                        io.Nakit = Islemler.DoubleYap(tGenelToplam.Text);
                        io.Kart = 0; break;
                    case "Kart":
                        io.Nakit = 0;
                        io.Kart = Islemler.DoubleYap(tGenelToplam.Text); break;
                    case "Kart-Nakit":
                        io.Nakit = Islemler.DoubleYap(lNakit.Text);
                        io.Kart = Islemler.DoubleYap(lKart.Text); break;
                }
                db.IslemOzet.Add(io);
                db.SaveChanges();

                var islemnoartir = db.Islem.First();
                islemnoartir.IslemNo += 1;
                db.SaveChanges();
                if (chYazdirmaDurumu.Checked)
                { 
                    //yazdır...
                    Yazdir yazdir = new Yazdir(islemno);
                    yazdir.YazdirmayaBasla();
                }
                Temizle();
            }
        }

        private void bNakit_Click(object sender, EventArgs e)
        {
            SatisYap("Nakit");
        }

        private void bKart_Click(object sender, EventArgs e)
        {
            SatisYap("Kart");
        }

        private void bKartNakit_Click(object sender, EventArgs e)
        {
            fNakitKart f = new fNakitKart(); // nakitkart formumunu tanımladık
            f.ShowDialog();
        }

        private void tBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08) //sadece rakamları almak için keypress eventine karakter tanımlıyoruz
            {
                e.Handled = true;
            }
        }

        private void tMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08) //sadece rakamları almak için keypress eventine karakter tanımlıyoruz
            {
                e.Handled = true;
            }
        }

        private void fSatis_KeyDown(object sender, KeyEventArgs e) //f1 f2 f3 tuşları ile satış yapma 
        {
            if (e.KeyCode == Keys.F1)
                SatisYap("Nakit");
            if (e.KeyCode == Keys.F2)
                SatisYap("Kart");
            if (e.KeyCode == Keys.F3)
            {
                fNakitKart f = new fNakitKart();
                f.ShowDialog();
            }
        }

        private void bIslemBeklet_Click(object sender, EventArgs e) //işlem bekletme
        {
            if (bIslemBeklet.Text == "İşlem Beklet")
            {
                Bekle();
                bIslemBeklet.BackColor = System.Drawing.Color.Crimson;
                bIslemBeklet.Text = "İşlem Bekliyor";
                gridSatisListesi.Rows.Clear();
                GenelToplam(); // 

            }
            else
            {
                BeklemedenCik();
                bIslemBeklet.BackColor = System.Drawing.Color.DimGray;
                bIslemBeklet.Text = "İşlem Beklet";
                gridBekle.Rows.Clear();
                GenelToplam(); // beklemeden sonra textbox temizleme
            }

        }
        private void Bekle() //İşlem bekletme
        {
            int satir = gridSatisListesi.Rows.Count;
            int sutun = gridSatisListesi.Columns.Count;
            if (satir > 0)
            {
                for (int i = 0; i < satir; i++)
                {
                    gridBekle.Rows.Add();

                    for (int j = 0; j < sutun - 1; j++)
                    {
                        gridBekle.Rows[i].Cells[j].Value = gridSatisListesi.Rows[i].Cells[j].Value;
                    }
                }
            }
        }
        private void BeklemedenCik() //işlem bekletme
        {
            int satir = gridBekle.Rows.Count;
            int sutun = gridBekle.Columns.Count;
            if (satir > 0)
            {
                for (int i = 0; i < satir; i++)
                {
                    gridSatisListesi.Rows.Add();

                    for (int j = 0; j < sutun - 1; j++)
                    {
                        gridSatisListesi.Rows[i].Cells[j].Value = gridBekle.Rows[i].Cells[j].Value;
                    }
                }
            }
        }

        private void chSatisIadeIslemi_CheckedChanged(object sender, EventArgs e)
        {
            if (chSatisIadeIslemi.Checked)
            {
                chSatisIadeIslemi.Text = "İade Yapılıyor";
            }
            else
            {
                chSatisIadeIslemi.Text = "Satış Yapılıyor";
            }
        }
    }
}