using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

/* 10x10 luk olacak şekilde 2 boyutlu dizi içinde rastgele harfler olacak */

namespace CiftDizi
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] onlukdizi = new char[10,10];
            Random rnd = new Random();

            // onlukdizi.Length komutunu kullanınca 100 veriyor total büyüklüğü veriyor. satır veya sütun değil.
            //GetLength(0); = satır , GetLength(1); = sütunu temsil eder. GetLength(2); = 3. boyutu temsil eder.


            for (int i=0; i<onlukdizi.GetLength(0); i++)
            {
                for (int j = 0; j < onlukdizi.GetLength(0); j++)
                {
                    int kod = rnd.Next(65, 91);
                    char karakter = Convert.ToChar(kod);

                    onlukdizi[i, j]= karakter;
                }
            }

            for (int i = 0; i < onlukdizi.GetLength(0); i++)
            {
                for (int j = 0; j < onlukdizi.GetLength(0); j++)
                {
                    Console.Write("{0} ", onlukdizi[i, j]);
                }
                Console.Write("\n");
            }

            Console.ReadKey();
        }
    }
}

