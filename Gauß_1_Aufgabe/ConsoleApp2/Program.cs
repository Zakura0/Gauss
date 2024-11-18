using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aufgabe und Strings
            string A0 = "Die Aufgabe:";
            string L = "";
            string A1 = "3x + 4y -2z = 4";
            string A2 = "x + -2 + 3z = 9";
            string A3 = "-2x + y - z = -6";
            string X = "x = ";
            string Y = "y = ";
            string Z = "z = ";
            
            Console.WriteLine(A0);
            Console.WriteLine(L);
            Console.WriteLine(A1);
            Console.WriteLine(A2);
            Console.WriteLine(A3);
            Console.WriteLine(L);

            int[] Z1 = new int[] { 3, 4, -2, 4 };
            int[] Z2 = new int[] { 1, -2, 3, 9 };
            int[] Z3 = new int[] { -2, 1, -1, -6 };

            //Abschnitt 1

            Z2 = ModifyArray(Z2, Z1, true, true, false, -3, 1);
            Z1 = ModifyArray(Z1, Z1, false, true, false, 2, 1);
            Z3 = ModifyArray(Z3, Z1, true, true, false, 3, 1);

            //Z
            Z2 = ModifyArray(Z2, Z2, false, true, false, 11, 1);
            Z3 = ModifyArray(Z3, Z2, true, true, false, -10, 1);
            Z3 = ModifyArray(Z3, Z2, true, true, true, -10, -51);
            Z2 = ModifyArray(Z2, Z2, false, false, true, 1, 11);
            Z1 = ModifyArray(Z1, Z1, false, false, true, 1, 2);

            //Y

            Z2[2] *= 3;
            Z2[2] += 33; Z2[3] += 33;
            Z2[1] /= Z2[3]; Z2[3] /= Z2[3];
            
            //X

            Z1[2] *= 3;
            Z1[1] -= Z1[1];
            Z1[2] -= Z1[2];
            Z1[3] += 2;
            Z1[0] /= Z1[0];
            Z1[3] /= 3;

            //Ausgabe der Lösungsmenge
            Console.Write(Z); Console.Write(Z3[3]);
            Console.WriteLine(L);
            Console.Write(Y); Console.Write(Z2[3]);
            Console.WriteLine(L);
            Console.Write(X); Console.Write(Z1[3]);

            Console.ReadKey();



        }

        private static int[] ModifyArray(int[] modifedArr, int[] dataArr, bool add, bool multiply, bool divide, int mulitplyValue, int divideValue)
        {
            int[] result = new int[modifedArr.Length];


            for (int i = 0; i < modifedArr.Length; i++)
            {
                if (multiply)
                {
                    result[i] = MultiplyArrayValue(modifedArr[i], mulitplyValue);
                }

                if (add)
                {
                    if (multiply || divide)
                    {
                        result[i] = AddArrayValue(result, dataArr, i);
                    }
                    else
                    {
                        result[i] = AddArrayValue(modifedArr, dataArr, i);
                    }

                }
                if (divide)
                {
                    result[i] = DivideArrayValue(modifedArr[i], divideValue);
                }
            }

            return result;
        }

        private static int AddArrayValue(int[] arr1, int[] arr2, int index)
        {
            return arr1[index] + arr2[index];
        }

        private static int MultiplyArrayValue(int arrayValue, int multiplyValue)
        {
            return arrayValue * multiplyValue;
        }

        private static int DivideArrayValue(int arrayValue, int divideValue)
        {
            return arrayValue / divideValue;
        }

    }
}
