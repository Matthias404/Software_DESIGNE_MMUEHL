using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe1._1
{
    class Program
    {
       
        static void Main(string[] args)
        {


            double a;

            Console.WriteLine("Bitte w für Würfel, k, Kugel oder o für Oktaeder eingeben");
            string zeile = Console.ReadLine();
            Console.WriteLine("bitte Wert eingeben");
            string wert = Console.ReadLine();

            a = double.Parse(wert);


            string w1 = "w";
            string k1 = "k";
            string o1 = "o";

            if (zeile == w1)
            {
                double ob = getCubeSurface(a);
                Console.WriteLine("die Oberfläche des Würfels ist " + ob);

                double vo = getCubeVolume(a);
                Console.WriteLine("das Volumen des Würfels ist " + vo);
                Console.ReadLine();
            }

            if (zeile == k1)
            {
                double ob = getBallSurface(a);
                Console.WriteLine("die Oberfläche des Würfels ist " + ob);

                double vo = getBallVolume(a);
                Console.WriteLine("das Volumen des Würfels ist " + vo);
                Console.ReadLine();

            }

            if (zeile == o1)
            {

                double ob = getOctSurface(a);
                Console.WriteLine("die Oberfläche des Würfels ist " + ob);

                double vo = getOctVolume(a);
                Console.WriteLine("das Volumen des Würfels ist " + vo);
                Console.ReadLine();
            }
        }
        static double getCubeSurface(double a)
        {

            double c = a * a * 6;

            return (c);

        }
        static double getCubeVolume(double a)
        {
            
            double c = a * a * a;

            return (c);
        }

        static double getBallSurface(double a)
        {
            double pi = 3.14;
            double c = pi * a * a;

            return (c);

        }

        static double getBallVolume(double a)
        {
            double pi = 3.14;
            double c = (pi * a * a * a) / 6;

            return (c);
        }

        static double getOctSurface(double a)
        {
            double sqrt3 = Math.Sqrt(3);
            
            double c = 2 * sqrt3 * a * a;

            return (c);

        }

        static double getOctVolume(double a)
        {
            double sqrt2 = Math.Sqrt(2);
            double c = (sqrt2 * a * a * a) / 3;

            return (c);
        }
    }
}