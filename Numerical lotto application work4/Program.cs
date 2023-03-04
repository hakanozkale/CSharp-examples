using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

/* -- Yönergeler --
Sayısal loto uygulamasını C# programı kullanarak yapınız. Bu uygulama da 1 ile 49
arasındaki sayılardan rastgele olacak şekilde 7 adet sayı
üretilsin ancak bu sayıların hiçbiri birbiri ile aynı olmasın.
Kullanıcı bu sayıları tahmin edebilsin ve kaç tane sayıyı doğru bildiğini görebilsin.
Bu senaryoyu gerçekleştirecek C# programını yazınız. */

namespace LotoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int sayi1, sayi2, sayac = 0;

            // RASTGELE SAYI OLUŞTURMA
            int[] uretilen_sayilar = new int[7];

            Random rnd = new Random();

            for (int i = 0; i < 7; i++)
            {
                sayi1 = rnd.Next(1, 50);

                if (uretilen_sayilar.Contains(sayi1))
                {
                    i--; // ife girersek burası atlanacak ve dizimize değer atanmayacak dizimizin eleman 
                         // sayısının az olmaması için ve hakkımızın gitmemesi için i yi azaltıyoruz.
                    continue;
                }
                uretilen_sayilar[i] = sayi1;
            }

            // KULLANICI SAYI GİRİŞLERİ 
            int[] tahmin_sayilar = new int[7];

            Console.WriteLine("Lütfen tahmin ettiğiniz 7 adet sayıyı giriniz (0 ile 50 arası):");

            for (int j = 0; j < 7; j++)
            {
                Console.Write($"{j + 1}. sayı: ");
                sayi2 = Convert.ToInt32(Console.ReadLine());

                if (sayi2 <= 0 || sayi2 > 49)
                {
                    Console.WriteLine("Lütfen 0-50 arasında bir sayi giriniz:");
                    j--;
                    continue;
                }
                if (tahmin_sayilar.Contains(sayi2))
                {
                    Console.WriteLine("Bu sayıyı daha önce seçmiştiniz. Farklı bir sayı giriniz:");
                    j--; // bir sayıdan iki kere yazdırmamak, hakkımızın boşa gitmemesi için azalttık.
                    continue;
                }
                tahmin_sayilar[j] = sayi2;
            }

            // TAHMİNLERİN KONTROLÜ
            for (int j = 0; j < uretilen_sayilar.Length; j++)
            {
                for (int i = 0; i < tahmin_sayilar.Length; i++)
                {
                    if (tahmin_sayilar[j] == uretilen_sayilar[i])
                    {
                        sayac++;
                    }
                }
            }

            // SONUÇLARI GÖSTERME 
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("Rastgele üretilen dizinin {0}. indexi = {1}", i, uretilen_sayilar[i]);
            }
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("Tahmin ettiğiniz sayılar dizisinin {0}. indexi = {1}", i, tahmin_sayilar[i]);
            }
            Console.WriteLine("Yaptığınız tahminlerden {0} adet sayı doğru çıktı.", sayac);

            Console.ReadKey();
        }
    }
}


/*
            ----- CHAT-GPT 's code -----

            // Rastgele sayı üretmek için Random sınıfını kullanıyoruz
            Random rnd = new Random();

            // 1 ile 49 arasındaki sayıların tutulduğu dizi
            int[] numbers = Enumerable.Range(1, 49).ToArray();

            // Kullanıcının tahmin ettiği sayıların tutulduğu dizi
            int[] userNumbers = new int[7];

            // Üretilen sayıların tutulduğu dizi
            int[] generatedNumbers = new int[7];

            // Kullanıcıdan sayıları alıyoruz
            Console.WriteLine("Lütfen tahmin ettiğiniz 7 adet sayıyı giriniz (1 ile 49 arası):");
            for (int i = 0; i < 7; i++)
            {
                Console.Write($"{i + 1}. sayı: ");
                userNumbers[i] = int.Parse(Console.ReadLine());
            }

            // Rastgele 7 adet sayı üretiyoruz
            for (int i = 0; i < 7; i++)
            {
                // Rastgele bir indeks seçiyoruz
                int index = rnd.Next(numbers.Length);

                // Seçilen indeksteki sayıyı üretilen sayılar dizisine ekliyoruz
                generatedNumbers[i] = numbers[index];

                // Seçilen sayıyı diziden çıkarıyoruz, böylece aynı sayı ikinci kez üretilmez
                numbers = numbers.Where(n => n != numbers[index]).ToArray();
            }

            // Kullanıcının kaç tane sayıyı doğru bildiğini buluyoruz
            int correctCount = generatedNumbers.Intersect(userNumbers).Count();

            // Sonuçları ekrana yazdırıyoruz
            Console.WriteLine("Üretilen sayılar: " + string.Join(", ", generatedNumbers));
            Console.WriteLine("Tahmin edilen sayılar: " + string.Join(", ", userNumbers));
            Console.WriteLine($"Doğru sayı tahmini: {correctCount}");

*/