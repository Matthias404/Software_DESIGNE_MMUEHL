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

            int i = 0;

            while ( i <= 4) {

                zufalls("");                
                i = i+1; }
            Console.ReadLine();
        }
        static void zufalls(string ausgabe)
        {
            int sublength = subjects.Length;
            int verblength = verbs.Length;
            int objlength = verbs.Length;

            
            Random rnd = new Random(); 

            int sub = rnd.Next(0, sublength);
            int verb = rnd.Next(0, verblength);
            int obj = rnd.Next(0, objlength);

            Console.WriteLine("" + subjects[sub] + " " + verbs[verb] + " " + objects[obj]);
        }
               }
        }