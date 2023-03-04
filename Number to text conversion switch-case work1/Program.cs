using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// (5 basamakli sayilara kadar) Girilen sayiyi metin şeklinde yazan switch-case örneği.

namespace Program
{
    class Ben
    {
        static void Main(string[] args)
        {
            Console.Write("0-9999 arasi bir sayi giriniz : ");
            int sayi = Convert.ToInt32(Console.ReadLine());

            if (sayi >= 0 && sayi <= 9999)
            {
                Console.Write("{0} Sayisi :", sayi);

                switch (sayi / 1000)
                {
                    case 9: Console.Write("Dokuz bin "); break;
                    case 8: Console.Write("Sekiz bin "); break;
                    case 7: Console.Write("Yedi bin "); break;
                    case 6: Console.Write("Alti bin "); break;
                    case 5: Console.Write("Beş bin "); break;
                    case 4: Console.Write("Dört bin "); break;
                    case 3: Console.Write("Üç bin "); break;
                    case 2: Console.Write("İki bin "); break;
                    case 1: Console.Write("Bin "); break;
                }
                switch (sayi % 1000 / 100)
                {
                    case 9: Console.Write("dokuz yüz "); break;
                    case 8: Console.Write("sekiz yüz "); break;
                    case 7: Console.Write("yedi yüz "); break;
                    case 6: Console.Write("alti yüz "); break;
                    case 5: Console.Write("beş yüz "); break;
                    case 4: Console.Write("dört yüz "); break;
                    case 3: Console.Write("üç yüz "); break;
                    case 2: Console.Write("iki yüz "); break;
                    case 1: Console.Write("yüz "); break;
                }
                switch ((sayi % 100) / 10)
                {
                    case 9: Console.Write("doksan "); break;
                    case 8: Console.Write("seksen "); break;
                    case 7: Console.Write("yetmiş "); break;
                    case 6: Console.Write("altmiş "); break;
                    case 5: Console.Write("elli "); break;
                    case 4: Console.Write("kirk "); break;
                    case 3: Console.Write("otuz "); break;
                    case 2: Console.Write("yirmi "); break;
                    case 1: Console.Write("on "); break;
                }
                switch ((sayi % 10))
                {
                    case 9: Console.Write("dokuz "); break;
                    case 8: Console.Write("sekiz "); break;
                    case 7: Console.Write("yedi "); break;
                    case 6: Console.Write("alti "); break;
                    case 5: Console.Write("beş "); break;
                    case 4: Console.Write("dört "); break;
                    case 3: Console.Write("üç "); break;
                    case 2: Console.Write("iki "); break;
                    case 1: Console.Write("bir "); break;
                }
                if (sayi == 0) { 
                    Console.Write(" Sifir ");
                }

                Console.Write("şeklinde okunur. ");
                    Console.ReadKey();
            }

            else
            {
                Console.Write("Yanlis aralikta bir deger girdiniz. Cikis yapiliyor... ");
                Console.ReadKey();
            }
        }
    }
}
 
           