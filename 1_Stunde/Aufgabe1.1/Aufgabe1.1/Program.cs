using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe1._1
{
    class Program
    {   public static String w1;
        public static String k1;
        public static String o1;
        static void Main(string[] args)
        {
            
           
            int a;
            
            Console.WriteLine("Bitte w für Würfel, k, Kugel oder o für Oktaeder eingeben");                     
            string zeile =Console.ReadLine();
            Console.WriteLine("bitte Wert eingeben");
            string wert = Console.ReadLine();

            a = int.Parse(wert);
            double pi = 3.14;

            string w1 = "w";
            string k1 = "k";
            string o1 = "o";

            if (zeile == w1)
            {
                Console.WriteLine("die Oberfläche des Würfels ist "+ a*a*6);
                Console.WriteLine("das Volumen des Würfels ist " + a * a * a);
                Console.ReadLine();
            }

            if (zeile == k1)
            {
                Console.WriteLine("die Oberfläche der Kugel ist " + pi*a*a);
                Console.WriteLine("das Volumen der Kugel ist " + (pi*a*a*a)/6);
                Console.ReadLine();
            }

            if (zeile == o1)
            {
                double sqrt3 = Math.Sqrt(3);
                double sqrt2 = Math.Sqrt(2);
                Console.WriteLine("die Oberfläche des Oktaeders ist "+ 2*sqrt3*a*a);
                Console.WriteLine("das Volumen des Würfels ist " + (sqrt2*a*a*a)/3);
                Console.ReadLine();
            }

        }
    }
}
