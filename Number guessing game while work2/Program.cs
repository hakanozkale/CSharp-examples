using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//  Kendi tasarladığınız bir while döngüsü içeren örnek. 
//  Bilgisayar tarafından rasgele tutulan sayıyı (1 dahil 100 değil) tahmin eden ve
//  kaçıncı hakta bildiğini kullanıcıya gösteren programa ait örnek

namespace Program
{
    class Benn

    {
        static void Main(string[] args)
        {
            int tahmin = 0, tutulan, sayac = 0;
            Random rasgele = new Random();
            tutulan = rasgele.Next(1, 100);
            while (tahmin != tutulan)
            {
                sayac++;
                Console.Write("Sayı giriniz : ");
                tahmin = Convert.ToInt32(Console.ReadLine());

                if (tahmin > tutulan)
                {
                    Console.WriteLine("Sayıyı küçült");
                }
                else if (tahmin < tutulan)
                {
                    Console.WriteLine("Sayıyı büyüt");
                }
            }
            Console.WriteLine("Tebrikler.");
            Console.WriteLine("{0}.hakkınızda bildiniz", sayac);
            Console.ReadKey();
        }
    }
}
