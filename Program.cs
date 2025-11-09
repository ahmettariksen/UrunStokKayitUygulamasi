using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunStokKayitUygulamasi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Urun u = new Urun()
            {
                urunAd = "EKMEK",
                urunFiyat = 10.5M,
                urunStok = 400
            };
            u.ıner[0] = new ınerType()
            {
                kullanımYerleri = "SULU YEMEKLER"
            };
            u.urunEkle(u);

            Urun u1 = new Urun()
            {
                urunAd = "SÜT",
                urunFiyat = 25.75M,
                urunStok = 700
            };
            u1.urunEkle(u1);
            u.urunListele();

            Console.WriteLine("TEKLİ LİSTELEME İÇİN Q HARFİNE BASINIZ");
            
            string cevap = Console.ReadLine().ToUpper();
            if (cevap == "Q")
                Console.Clear();
            u.ıdListele();
        }
    }
}
