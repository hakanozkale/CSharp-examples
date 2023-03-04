using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

/* -- Yönergeler --
Genetik algoritma yardımıyla istenen bireyin gen yapısını oluşturan program.
Öncelikle kullanıcıdan 10 adet 1 ve 0 dan oluşan bir dizi oluşturması istenecektir.
Ardından bilgisayar tarafından her seferinde rastgele oluşturulan anne ve babaya ait genler çaprazlanacaktır.
Anne dizisindeki ilk 5 ve baba dizisindeki son 5 eleman alınarak yeni bir dizide birleştirilecektir.
Ardından rastgele belirlenen bir indekste bulunan eleman 1 ise 0,
0 ise 1 olacak böylelikle mutasyon işlemi gerçekleştirilecektir.
Elde edilen yeni bireyin genleri başta istenen birey ile karşılaştırılacak ve
benzerlik oranı hesaplanacaktır.
Bu döngü benzerlik oranı %100 olana kadar tekrarlanacak istenen
oran yakalandığında kaç iterasyonda (deneme) başarılı sonuç alındığı yazdırılacaktır. Kolay gelsin :)

Örnek Kod: İstediğiniz bireyin gen yapısını giriniz:
1 0 1 1 0 1 1 1 0 1

1.Deneme                       2.Deneme
Anne: 1111100000               Anne: 1011100000
Baba: 0000011110               Baba: 0100011100
Çaprazlama: 1111111110         Çaprazlama: 1011111100
Mutasyon: 1110111110           Mutasyon: 1011111101
Yeni birey: 1110111110         Yeni birey: 1011111101
Benzerlik oranı: % 60          Benzerlik oranı: % 70

Örneğin 207.iterasyonda benzerlik oranı %100 olduğunda;
"İstenen bireye 207. denemede ulaştınız." mesajı verilecektir. */

namespace genApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int genadresi;
            int[] bireyGen = new int[10];
            int[] anneGen = new int[10];
            int[] babaGen = new int[10];
            int[] birlesikGen = new int[10];
            int[] mutasyonluGen = new int[10];
            bool kontrol = true;
            
            int sayac = 0;

            Console.WriteLine("Lütfen 10 adet 0-1 değeri girerek istediğiniz geni oluşturun.");

            // İSTENEN GENİ ALMA 
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Genin " + (i + 1) + ". adresini giriniz :");

                genadresi = Convert.ToInt32(Console.ReadLine());

                if (genadresi == 0 || genadresi == 1)
                {
                    bireyGen[i] = genadresi;
                }
                else
                {
                    Console.Write("Lütfen 0-1 sayılarından birini girin. ");
                    i--;
                    continue;
                }
            }

            //BİREY GENİ
            Console.Write("BİREY GENİ : ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}", bireyGen[i]);
            }

            Console.Write("\n");

            Random rnd = new Random();

            while (kontrol)
            {
                int benzerlik = 0;

                for (int i = 0; i < 10; i++)
                {
                    int rastgele_anne = rnd.Next(0, 2); // 0-1 dahil sadece
                    int rastgele_baba = rnd.Next(0, 2);

                    anneGen[i] = rastgele_anne;
                    babaGen[i] = rastgele_baba;
                }

                //ANNE VE BABA BİRLEŞTİRME 
                for (int i = 0; i < 10; i++)
                {
                    if (i < 5)
                    {
                        birlesikGen[i] = anneGen[i];
                    }
                    else
                    {
                        birlesikGen[i] = babaGen[i];
                    }
                }

                // BİRLESİK GENİ MUTASYON OLMADAN ÖNCE MUTASYOLU DİZİYE ATAYARAK KOPYALIYORUM.
                for (int i = 0; i < 10; i++)
                {
                    mutasyonluGen[i] = birlesikGen[i];
                }

                //MUTASYONLU GEN
                int rastgele_index = rnd.Next(0, 10);

                if (mutasyonluGen[rastgele_index] == 0)
                {
                    mutasyonluGen[rastgele_index] = 1;
                }
                else
                {
                    mutasyonluGen[rastgele_index] = 0;
                }

                //BENZERLİK
                for (int i = 0; i < 10; i++)
                {
                    if (bireyGen[i] == mutasyonluGen[i])
                    {
                        benzerlik += 10;
                    }
                    else { }
                }
                if (benzerlik == 100) { kontrol = false; }
                else
                    sayac++;
            }

            Console.Write(" Deneyimiz {0} iterasyon sonucunda 100% benzerlik oranına ulaştı.", sayac);

            Console.Write("\n \n");

            //ANNE GENİ
            Console.Write("ANNE GENİ : ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}", anneGen[i]);
            }

            Console.Write("\n");

            //BABA GENİ
            Console.Write("BABA GENİ : ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}", babaGen[i]);

            }

            Console.Write("\n");

            //BİRLEŞİK GENİ
            Console.Write("BİRLEŞİK GEN : ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}", birlesikGen[i]);
            }

            Console.Write("\n");

            //MUTASYONLU GEN
            Console.Write("MUTASYONLU (YENİ BİREY) GEN : ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}", mutasyonluGen[i]);
            }

            Console.ReadKey();
        }
    }
}

