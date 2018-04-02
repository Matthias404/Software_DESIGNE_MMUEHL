using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe1._2
{
    class Program
    {
            static string[] subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };
            static string[] verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
            static string[] objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };
            
        static void Main(string[] args)
        {

           

                zufalls("");
            
            Console.ReadLine();
        }

        static void zufalls(string ausgabe)
        {

            for (int i = 0; i <= 4; i++)
            {
                Console.WriteLine("" + subjects[erste()] + " " + verbs[zweite()] + " " + objects[drei()]);

            }
        }
      

            static int erste() { 
                Random rnd1 = new Random();
                int sublength = subjects.Length;
                int sub = rnd1.Next(0, sublength);
                return sub;
             }

            static int zweite() {
                Random rnd2 = new Random();
                int verblength = verbs.Length;
                int verb = rnd2.Next(0, verblength);
                return verb;
             }
            static int drei(){
            Random rnd3 = new Random();
                int objlength = objects.Length;
                int obj = rnd3.Next(0, objlength);
                return obj;

            }
        }
    }

