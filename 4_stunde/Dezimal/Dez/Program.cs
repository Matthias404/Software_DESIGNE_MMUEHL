using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dez
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            Console.WriteLine("Bitte Zahl eingeben zwischen 0 und 1024");
            String a = Console.ReadLine();
            int.TryParse( a, out int value) ;
            Program.ConvertDecimalToHexal(value);
        }

            public static int ConvertDecimalToHexal(int dec){
            if (dec>=1024 || dec<= 0){
                Console.WriteLine("Leider keine Passende Zahl");
                Console.ReadLine();
              return 1;
            }
            else{
                
                int Dezi =dec;
                for (int i=0; Dezi >=6; i++){
                    Dezi =Dezi-6;   
                    
                if (Dezi<= 6){
                    Console.WriteLine(""+dec+""+i +"*6"+ Dezi);
                    return 2;

                }
               
            }

            
        }
        return 3; 
    
    }
    
}
}