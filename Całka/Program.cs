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
            double epsilon;
            double dokladnosc;
            double[] zakres = new double[2];

            Console.WriteLine("Liczenie całki");
            //tu dodać wybór funkcji
            Console.WriteLine("podaj epsilon: ");
            epsilon = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("liczba kroków w pierwszym liczeniu: ");
            dokladnosc = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("zakres od: ");
            zakres[0] = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("zakres do: ");
            zakres[1] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Wynik to = " + liczCaleke(epsilon, dokladnosc, zakres));
            Console.Read();

        }

        private static double liczCaleke(double epsilon, double dokladnosc, double[] zakres) {
            double[] pole = new double[2];
            do
            {
                pole[0] = 0;
                pole[1] = 0;
                for (int i = 0; i < 2; i++)
                {
                    for (double kroki = 0; (zakres[0] + kroki) < zakres[1]; kroki += (zakres[1] - zakres[0]) / dokladnosc)
                    {
                        pole[i] = pole[i] + (double)(Math.Abs(funkcjaKwadratowa(zakres[0] + kroki))* (zakres[1] - zakres[0]) / dokladnosc);
                    }
                    dokladnosc = dokladnosc * 2;
                }
            }
            while ((pole[0] - pole[1]) > epsilon);
            return pole[1];
        }

        private static double funkcjaKwadratowa(double parametr)
        {
            // funkcja x^2
            return (parametr * parametr);
        }

        private static double sinus(double parametr)
        {
            // funkcja sin
            return (Math.Sin(parametr));
        }

        private static double cos(double parametr)
        {
            // funkcja cos
            return (Math.Cos(parametr));
        }
    }
}
