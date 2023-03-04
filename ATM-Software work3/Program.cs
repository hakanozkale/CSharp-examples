using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

/* Yönergeler  Bir banka ATM sine ait yazılımı kodlayınız.

Şifre: 1234 (Dört haneli nümerik ve doğru girilmeli üç kere yanlış girildiğinde kart bloke olacak)
1.Para Yatırma
2.Para Çekme
3.Bakiye Sorgulama
4.Fatura Ödeme
5.Çıkış

10 ve katları halinde para çekme ve yatırma işlemi yapılabilir. Fatura ödeme bölümünde bu kural geçerli değildir.

Örneğin:
1.  Yatırmak istediğiniz miktarı giriniz: 100
Para yatırma başarılı. Ana menüye dönmek için 0 ı tuşlayınız.
3. Hesap bakiyeniz: 1200 TL.Ana menüye dönmek için 0 ı tuşlayınız   */

namespace Program
{
    class Benn
    {
        static void Main(string[] args)
        {
            int sifre, giris, hak, bakiye = 0;
            hak = 3;
            sifre = 1234;
            Boolean dondur = true;

            girisedon:
            for (int i = 0; i < 3; i++)
            {
                Console.Write("{0} hakkınız var - Lütfen sifreyi giriniz : ", hak);
                giris = Convert.ToInt32(Console.ReadLine());

                if (giris == sifre)
                {
                    Console.Write("\n");
                    i = 3;
                    hak = 3;
                    Console.Write("Giris yaptınız. ");
                    int fatura = 1250; // her giriş yaptığında 1250tl borcu gözükecek.

                    while (dondur)
                    {
                    islemedon: Console.WriteLine("Yapmak istediginiz islemi seciniz : 1-Para Yatırma 2-Para Çekme 3-Bakiye Sorgulama 4-Fatura Ödeme 5-Çıkış ");
                        Console.Write(" İslem : ");
                        int islem = Convert.ToInt32(Console.ReadLine());

                        if(islem>=1 && islem <= 5)
                        {
                            dondur = false;
                            Console.Write(" \n ");
                            
                            switch (islem)
                            {
                                case 1: Console.WriteLine("1-Para Yatırma işlemini seçtiniz : Bakiyeniz = {0}" , bakiye);
                                    Console.Write("  Yatırmak istediğiniz miktarı giriniz. (Yatırma miktarınız 10'un katları şeklinde olmalıdır) : ");
                                    int yatır = Convert.ToInt32(Console.ReadLine());

                                    if(yatır % 10 == 0) { bakiye += yatır;
                                        Console.WriteLine("   Yeni bakiyeniz ={0} \n", bakiye);
                                        
                                    }

                                    else { Console.WriteLine("   10'un katında para girmediniz. \n "); }

                                    goto islemedon;

                                    // break; burada breake gerek yok breake gelmeden
                                    // zaten önce goto ile geriye yönlendirme yapıyoruz 2 yolda da.

                             
                                case 2: Console.WriteLine("2-Para Çekme işlemini seçtiniz. Bakiyeniz = {0} " , bakiye);
                                    Console.Write("  Kaç para çekmek istiyorsunuz? (Çekim miktarınız 10'un katları şeklinde olmalıdır) : ");
                                    int cekim = Convert.ToInt32(Console.ReadLine());

                                    if(cekim % 10 == 0 ) {

                                        if (cekim > bakiye)
                                        {
                                            Console.WriteLine("   Yeterli bakiyeniz yoktur. \n");
                                        }

                                        else
                                        {
                                            bakiye = bakiye - cekim;
                                            Console.WriteLine("   Yeni bakiyeniz = {0} \n", bakiye);
                                        }

                                        goto islemedon;

                                    }
                                    else { Console.WriteLine("   10'un katında para girmediniz. \n "); goto islemedon; }

                               
                                case 3:
                                    Console.WriteLine("3-Bakiye Sorgulama işlemini seçtiniz.");
                                    Console.WriteLine("  Hesabınızda " + bakiye + "TL bulunmaktadır. \n");

                                    goto islemedon;
                                    
                               
                                case 4:
                                    Console.WriteLine("4-Fatura Ödeme işlemini seçtiniz.");
                                    
                                    Console.WriteLine("  Fatura tutarınız " +fatura+ " TL.");

                                    string userInput; //null kontrol
                                    do
                                    {
                                        Console.Write("  Faturanızı ödemek için E tuşuna , Ana menüye dönmek için 0 tuşuna basınız : ");
                                        userInput = Console.ReadLine();

                                    } while (string.IsNullOrWhiteSpace(userInput) || ((userInput != "E") &&
                                    (userInput!= "e") && (userInput != "0"))); // added later.

                                    char karakter = Convert.ToChar(userInput);

                                    if (karakter == 'e' || karakter == 'E') 
                                    {
                                        if (bakiye >= fatura)
                                        {

                                            bakiye -= fatura;
                                            fatura = 0;
                                            Console.WriteLine("   Faturanız ödenmiştir :) \n");

                                        }
                                        else { Console.WriteLine("   Şu anda faturanızı ödemek için yeterli bakiyeniz yoktur. Ana menüye yönlendiriliyorsunuz... \n "); }
                                        goto islemedon;
                                    }

                                    else if (karakter == '0') { Console.WriteLine("   Ana menüye yönlendiriliyorsunuz.\n"); goto islemedon; }
                                    
                                    else {
                                        Console.WriteLine("   Yanlış tuşlama yaptınız. Çıkışınız yapılıyor...\n");
                                        dondur = true;
                                        goto girisedon;
                                    }
                                    
                                
                                case 5:
                                    Console.WriteLine("5-Çıkış işlemini seçtiniz.");
                                    Console.WriteLine("  Çıkışınız yapıldı. \n ");

                                    dondur = true; // buraya bu ifadeyi koymassan çıkış yaptıktan sonra tekrar giriş yaparsan
                                                   // yukarıda donduru false yaptırdıgımızdan while döngüsünü döndürmez.
                                                   // İslem menüsünü açmak için bunu true yaptık
                                    goto girisedon;
                                    
                            }
                        }

                        else { Console.WriteLine(" Yanlış işlem seçtiniz. "); }
                    }
                }

                else {
                    Console.WriteLine(" Hatalı şifre girdiniz. ");
                    hak--;

                    if(hak==0) { Console.WriteLine(" Kartınız bloke olmuştur. "); break; }
                }
            }

            Console.ReadKey();
        }
    }
}
