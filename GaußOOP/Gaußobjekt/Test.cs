using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaußobjekt
{
    class Test
    {
        static void Main(string[] args)
        {
            //Erstellung der Matrix
            Matrix Test = new Matrix();
            Console.WriteLine("Bitte Anzahl der Zeilen eingeben:");
            Test.ZeilenAnz = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Bitte Anzahl der Spalten eingeben:");
            Test.SpaltenAnz = int.Parse(Console.ReadLine());
            Console.Clear();
            Test.LGS = new double[Test.ZeilenAnz, Test.SpaltenAnz];
            Test.LGSeingabe(Test.ZeilenAnz, Test.SpaltenAnz);
            string s = "Eingegebene Matrix:";

            //Berechnung der Matrix
            Test.LGSausgabe(Test.LGS, Test.ZeilenAnz, Test.SpaltenAnz, s);
            Test.LGS = Test.Gauss(Test.LGS);
            Test.LGS = Test.Jordan(Test.LGS);
            s = "Gelöste Matrix:";
            Test.LGSausgabe(Test.LGS, Test.ZeilenAnz, Test.SpaltenAnz, s);
        }
    }
}
