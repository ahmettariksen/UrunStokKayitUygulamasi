using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunStokKayitUygulamasi
{
    internal class Urun
    {
        #region SANAL DATABESİMİZ (verileri tutacağımız bölge)
        public static Dictionary<int, Urun> sanalDB = new Dictionary<int, Urun>();
        #endregion

        #region FİELDLARIMIZ
        public string urunAd { get; set; }
        #endregion

        #region KAPSÜLLENECEK FİELDLARIMIZ
        private int _urunID;
        public int urunID
        {
            get
            {
                return _urunID;
            }
            private set
            {
                _urunID = value;
            }
        }
        private int _urunStok;
        public int urunStok
        {
            get
            {
                return _urunStok;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("NEGATİF DEĞERLERDE STOK KAYDI YAPILMAZ");
                }
                else
                {
                    _urunStok = value;
                }
            }
        }
        private decimal _urunFiyat;
        public decimal urunFiyat
        {
            get
            {
                return _urunFiyat;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("NEGATİF FİYAT KAYDI YAPILMAZ");
                }
                else
                {
                    _urunFiyat = value;
                }
            }
        }
        #endregion

        #region INERTYPE
        public ınerType[] ıner;

        #endregion

        #region YAPICI METOT (uygulama ilk çalıştığı zaman burası devreye girecek)
        public Urun()
        {
            this.urunID = ıdUret();
            ıner = new ınerType[10];
        }
        #endregion

        #region ID ÜRETEN METODUMUZ
        private int ıdUret()
        {
            Random rnd = new Random();
            int ıd;
            do
            {
                ıd = rnd.Next(1, 100);
            }
            while (sanalDB.ContainsKey(ıd)); // aynı ıd atandığı zaman döngüden çıkacak
            return ıd;
        }
        #endregion

        #region URUN EKLEME METODUMUZ
        public void urunEkle(Urun U)
        {
            if (U == null || string.IsNullOrEmpty(U.urunAd))
            {
                Console.WriteLine("ÜRÜN ADI BİLGİSİ EKSİK!");
                return;
            }
            if (sanalDB.ContainsKey(U.urunID))
            {
                Console.WriteLine("BU ÜRÜN ZATEN KAYITLI!");
            }
            else
            {
                sanalDB.Add(U.urunID, U); // key, value
                Console.WriteLine($"ÜRÜN EKLENDİ {U.urunAd} (ID : {U.urunID})");
            }
        }
        #endregion

        #region ÜRÜNLERİ LİSTELEME METODUMUZ
        public void urunListele()
        {
            Console.WriteLine("\n---ÜRÜN LİSTESİ---");
            foreach (var urun in sanalDB.Values)
            {
                Console.WriteLine($"ID: {urun.urunID} | Ad: {urun.urunAd} | Stok: {urun.urunStok} " +
                    $"| Fiyat: {urun.urunFiyat}₺");
            }
        }

        #endregion

        #region ID YE GÖRE LİSTELEME
        public void ıdListele()
        {
            Console.Write("LİSTELEMEK İSTEDİĞİNİZ ÜRÜNÜN ID SINI GİRİNİZ :");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (sanalDB.ContainsKey(id))
                {
                    Urun u = sanalDB[id];
                    Console.WriteLine($"\n---{u.urunID} ID NUMARALI ÜRÜNÜN BİLGİLERİ---");
                    Console.WriteLine($"{u.urunAd} | {u.urunStok} | {u.urunFiyat}");
                }
                else
                {
                    Console.WriteLine("YANLIŞ ID GİRDİNİZ!");
                }
            }
            else
            {
                Console.WriteLine("LÜTFEN GEÇERLİ BİR SAYI GİRİNİZ!");
            }
        }
        #endregion
    }
}
