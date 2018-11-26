using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Całka
{
    class Program
    {
        static void Main(string[] args)
        {
            mainProgram();
        }

        private static void mainProgram() {
            double epsilon = 0;
            double dokladnosc;
            double[] zakres = new double[2];
            double wynik;
            int wybranaFunkcja;

            Console.WriteLine("Liczenie całki");
            //tu dodać wybór funkcji
            wybranaFunkcja = wybierzFunkcje();
            epsilon = wczytaj("Podaj epsilon: ", 0.01);
            dokladnosc = wczytaj("liczba kroków w pierwszym liczeniu: ", 4);
            zakres[0] = wczytaj("zakres od: " , -1);
            zakres[1] = wczytaj("zakres do: ", 1);

            wynik = liczCaleke(epsilon, dokladnosc, zakres, wybranaFunkcja);
            Console.WriteLine("Wynik to = " + wynik);
            Console.Read();

        }

        private static int wybierzFunkcje() {
            int wybor = 0;
            do
            {
                Console.WriteLine("Wybierz funkcje do liczenia: " +
                "\n1-funkcja kwadratowa" +
                "\n2-funkcja sinus" +
                "\n3-funkcja cosinus");
                string wyb = Console.ReadLine();
                if (wyb != "")
                {
                    try
                    {
                        wybor = Convert.ToInt16(wyb);
                    }
                    catch
                    {
                        Console.WriteLine("podana wartość nie jest liczbą");
                    }
                }
                else
                {
                    Console.WriteLine("Podaj liczbe");
                }
            }
            while (wybor == 0);
            return wybor;
        }

        private static double wczytaj(string text, double wartoscDomyslna) {
            double wynik = 0;
            do
            {
                Console.WriteLine(text);
                string eps = Console.ReadLine();
                if (eps != "")
                {
                    try
                    {
                        wynik = Convert.ToDouble(eps);
                    }
                    catch
                    {
                        Console.WriteLine("podana wartość nie jest liczbą");
                    }
                }
                else
                {
                    wynik = wartoscDomyslna;
                }
            }
            while (wynik == 0);
            return wynik;
        }

        private static double liczCaleke(double epsilon, double dokladnosc, double[] zakres, int numerFunkcji) {
            double[] pole = new double[2];
            do
            {
                pole[0] = 0;
                pole[1] = 0;
                for (int i = 0; i < 2; i++)
                {
                    for (double kroki = 0; (zakres[0] + kroki) < zakres[1]; kroki += (zakres[1] - zakres[0]) / dokladnosc)
                    {
                        pole[i] = pole[i] + (double)(Math.Abs(wybranaFunkcja(numerFunkcji, zakres[0] + kroki))* (zakres[1] - zakres[0]) / dokladnosc);
                    }
                    dokladnosc = dokladnosc * 2;
                }
            }
            while ((pole[0] - pole[1]) > epsilon);
            return pole[1];
        }

        private static double wybranaFunkcja(int funkcja, double parametr)
        {
            switch (funkcja) {
                case (1):
                    return (parametr * parametr);
                case (2):
                    return (Math.Sin(parametr));
                case (3):
                    return (Math.Cos(parametr));
                default:
                    return 0;
            }
        }
    }
}
