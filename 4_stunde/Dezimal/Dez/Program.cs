using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dez
{
    class Program
    {
        static void Main(string[] args)//Wahl der verschiedenen umsezungen
        {
            Console.WriteLine("Bitte 1 eingeben für Dezi zu Hexa, 2 für hexa zu Dezi oder 3 um frei zu wälen");
            String a = Console.ReadLine();
            int.TryParse(a, out int choise);

            if (choise > 4 || choise < 1)
            {
                Console.WriteLine("Bitte Zahl eingeben zwischen 1 und 4");
                Console.ReadLine();

            }
            else{
                Console.WriteLine("Bitte ihre Einganszahl eingeben Zahl eingeben zwischen 0 und 1023");
                String b = Console.ReadLine();
                int.TryParse(b, out int value);

                if (value > 1023 || value <= 0)
                {
                    Console.WriteLine("Leider keine Passende Zahl");
                    Console.ReadLine();
                }
                else
                {
                    if (choise == 1)
                    {
                        ConvertDecimalToHexal(value);
                    }

                    if (choise == 2)
                    {
                        ConvertHexalToDezimal(value);
                    }
                    if (choise == 3)
                    {
                        ChoiseConversion(value);
                    }                  
                }

            }
        }   

        public static void ConvertDecimalToHexal(int dec)
        {
            int dezi = dec;
            for (int i = 1; dezi >= 6; i++)
            {
                dezi = dezi - 6;

                if (dezi <= 6)
                {
                    Console.WriteLine("" + dec + "=" + i + "" + dezi);
                    Console.ReadLine();
                }
            }
        }

        public static void ConvertHexalToDezimal(int hexal)
        {
            int hexi = hexal;
            for (int i = 1; hexi >= 10; i++)
            {
                hexi = hexi - 10;

                if (hexi < 6)
                {
                    Console.WriteLine("" + hexal + "=" + (i* 6+hexi));
                    Console.ReadLine();
                }
                if (hexi >= 6 && hexi < 10){
                    Console.WriteLine("Bitte Passende Hexa zahl eingeben");
                    Console.ReadLine();
                }
            }
        }
        // Auswahl der 3 verschieden Mix Systeme
        public static void ChoiseConversion(int value)
        {
            Console.WriteLine("Bitte Wählen sie aus Folgenden Möglichkeiten:");
            Console.WriteLine("Umwandlung eine Dezimal zu einer Belibigen Basis 1");
            Console.WriteLine("Umwandlung einer belibigen basis zu Dezimal 2");
            Console.WriteLine("Für die umwandlung Irgendeiner Basis in ein anderes zahlensystem 3");
            String aBase = Console.ReadLine();
            int.TryParse(aBase, out int aChoise);
            if (aChoise > 4 || aChoise < 1)
            {
                Console.WriteLine("Bitte Zahl eingeben zwischen 1 und 4");
                Console.ReadLine();
                ChoiseConversion(value);
            }
            //Übergabe der Daten 
            else
            {
                if (aChoise == 1)
                {
                    Console.WriteLine("Bitte Zahlensystem Wählen");
                    String baseSys =Console.ReadLine();
                    int.TryParse(baseSys, out int numSys);

                    ConvertToBaseFromDecimal(numSys,value);
                }

                if (aChoise == 2)
                {
                    Console.WriteLine("Bitte Zahlensystem Wählen");
                    String baseSys = Console.ReadLine();
                    int.TryParse(baseSys, out int numSys);

                    ConvertToDecimalFromBase(numSys, value);
                }
                if (aChoise == 3)
                {
                    Console.WriteLine("Bitte End Zahlensystem Wählen");
                    String baseSys = Console.ReadLine();
                    int.TryParse(baseSys, out int numSys);

                    Console.WriteLine("Bitte Anfangs Zahlensystem Wählen");
                    String frombaseSys = Console.ReadLine();
                    int.TryParse(frombaseSys, out int fromNumSys);

                    ConvertNumberToBaseFromBase(value, numSys, fromNumSys);
                }
            }
        }

        public static void ConvertToBaseFromDecimal(int toBase, int dec)
        {
            int dezi = dec;
            for (int i = 1; dezi >= toBase; i++)
            {
                dezi = dezi - toBase;

                if (dezi <= toBase)
                {
                    Console.WriteLine("" + dec + "=" + i + "" + dezi+"im"+dec+" System");
                    Console.ReadLine();
                }
            }
        }

        public static void ConvertToDecimalFromBase(int fromBase, int number)
        {
            int hexi = number;

            for (int i = 1; hexi >= 10; i++)
            {
                hexi = hexi - 10;

                if (hexi < fromBase)
                {
                    Console.WriteLine("" + number + "=" + (i * fromBase + hexi));
                    Console.ReadLine();
                }

                if (hexi >= fromBase && hexi < 10)
                {
                    Console.WriteLine("Bitte passende Zahl im Zahlen System eingeben");
                    Console.ReadLine();
                    ChoiseConversion(number);
                }
            }
        }

        public static void ConvertNumberToBaseFromBase(int number, int toBase, int fromBase)
        {
            int fromBaseDezi = number;
            for (int i = 1; fromBaseDezi >= 10; i++)
            {
                fromBaseDezi = fromBaseDezi - 10;

                if (fromBaseDezi < fromBase)
                {
                    int dezi = i * fromBase + fromBaseDezi;    //übergang zu dezimal               


                    for (int j = 1; dezi >= toBase; j++)
                    {
                        dezi = dezi - toBase;

                        if (dezi <= toBase)
                        {
                            Console.WriteLine("" + number + "=" + j + "" + dezi);
                            Console.ReadLine();
                        }

                        if (fromBaseDezi >= fromBase && fromBaseDezi < toBase)
                        {
                            Console.WriteLine("Bitte passende Zahlen eingeben");
                            Console.ReadLine();
                            ChoiseConversion(number);
                        }
                    }
                }
            }
        }
    }
    
}