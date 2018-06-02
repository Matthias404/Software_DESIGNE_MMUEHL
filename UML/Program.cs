using System;
using System.Collections.Generic;

namespace Aufgabe_UML
{
    class Program
    {
        Kurs KursA = new Program.Kurs();

        
        public void KursATeilnehmer(int a) {
            KursA.Zuhoehrer(a);
        }
    }
        class Person
        {
            public string Name;
            public int Alter;
        }

        class Teilnehmer : Person
        {
            public int Matrikelnummer;

            public void Teilnehmen()
            {
                KursATeilnehmer(Matrikelnummer);
            }


        }

        class Dozent : Person
        {
            public string Büro;



        }

        class Kurs : Dozent
        {
            public string Titel;
            public string Uhrzeit;
            public string Wochentag;
            public string Raum;
            public int Teilnehmer;
            public List<int> AllTeilnehmer = new List<int>();

            public void Zuhoehrer(int a)
            {
                Teilnehmer = Teilnehmer + 1;
                AllTeilnehmer.Add(a);
            }

        }
        class Sprechstunde : Kurs
        {

            public void SprechstundeInfo()
            {
                Console.WriteLine("Die Sprechstunde " + Uhrzeit + " findet am " + Wochentag + " in Raum " + Raum + " statt.");
            }

        }

    }
}