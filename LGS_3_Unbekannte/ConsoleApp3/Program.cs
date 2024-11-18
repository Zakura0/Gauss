using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string eingabe = "Eingegebene Koeffizientenmatrix:";
            string x = "x = ";
            string y = "y = ";
            string z = "z = ";

            double Q;

            double R;
            double S;
            double[] Z1 = new double[4];
            Console.WriteLine("Eingabe eines LGS mit 3 Unbekannten und 3 Zeilen");
            Console.WriteLine("Bitte die Koeffizienten A B C D der 1. Zeile nacheinander eintragen:");
            Console.WriteLine();

            for (int i = 0; i < Z1.Length; i++)
            {
                Z1[i] = Double.Parse(Console.ReadLine());
                Console.Clear();
            }

            double[] Z2 = new double[4];
            Console.WriteLine("Bitte A B C D der 2. Zeile eingeben:");

            for (int i = 0; i < Z1.Length; i++)
            {
                Z2[i] = Double.Parse(Console.ReadLine());
                Console.Clear();
            }

            double[] Z3 = new double[4];
            Console.WriteLine("Bitte A B C D der 3. Zeile eingeben:");

            for (int i = 0; i < Z1.Length; i++)
            {
                Z3[i] = Double.Parse(Console.ReadLine());
                Console.WriteLine(Z1[i]);
                Console.Clear();
            }

            Console.Clear();
            Console.WriteLine(eingabe);
            Console.WriteLine();


            //Zeile 1
            Console.Write(Z1[0] + " " + Z1[1] + " " + Z1[2] + " " + "|" + " " + Z1[3]);
            Console.WriteLine();
            //Zeile 2
            Console.Write(Z2[0] + " " + Z2[1] + " " + Z2[2] + " " + "|" + " " + Z2[3]);
            Console.WriteLine();
            //Zeile 3
            Console.Write(Z3[0] + " " + Z3[1] + " " + Z3[2] + " " + "|" + " " + Z3[3]);
            Console.WriteLine();
            Console.ReadKey();

            //Eliminierung der 1. Stelle
            R = Z1[0];
            Q = Z2[0];
            Z1 = ModifyArray(Z1, Z1, false, false, false, true, 1, Z1[0]);
            Z1 = ModifyArray(Z1, Z1, false, false, true, false, Z2[0], 1);
            Z2 = ModifyArray(Z2, Z1, false, true, false, false, 1, 1);
            Z1 = ModifyArray(Z1, Z1, false, false, false, true, 1, Q);

            //Eliminierung der 2. Stelle
            Q = Z3[0];
            Z1 = ModifyArray(Z1, Z1, false, false, true, false, Z3[0], 1);
            Z3 = ModifyArray(Z3, Z1, false, true, false, false, 1, 1);
            Z1 = ModifyArray(Z1, Z1, false, false, false, true, 1, Q);

            //Eliminierung der 3. Stelle
            Q = Z3[1];
            Z2 = ModifyArray(Z2, Z2, false, false, false, true, 1, Z2[1]);
            Z2 = ModifyArray(Z2, Z2, false, false, true, false, Z3[1], 1);
            Z3 = ModifyArray(Z3, Z2, false, true, false, false, 1, 1);
            Z2 = ModifyArray(Z2, Z2, false, false, false, true, 1, Q);
            //Z1 = ModifyArray(Z1, Z1, false, false, true, false, R, 1);
            
            Console.WriteLine();
            Console.WriteLine("Matrix vor dem Umformen:");
            Console.WriteLine();

            //Zeile 1
            Console.Write(Z1[0] + " " + Z1[1] + " " + Z1[2] + " " + "|" + " " + Z1[3]);
            Console.WriteLine();
            //Zeile 2
            Console.Write(Z2[0] + " " + Z2[1] + " " + Z2[2] + " " + "|" + " " + Z2[3]);
            Console.WriteLine();
            //Zeile 3
            Console.Write(Z3[0] + " " + Z3[1] + " " + Z3[2] + " " + "|" + " " + Z3[3]);
            Console.WriteLine();
            Console.ReadKey();

            //Berechnung von Z
            Z3 = ModifyArray(Z3, Z3, false, false, false, true, 1, Z3[2]);

            //Berechnung von Y
            Z2[2] *= Z3[3];
            R = Z2[2];

            Z2[2] -= R;
            Z2[3] -= R;

            Z2 = ModifyArray(Z2, Z2, false, false, false, true, 1, Z2[1]);

            //Berechnung von X
            Z1[2] *= Z3[3];
            Z1[1] *= Z2[3];
            S = Z1[2];

            Z1[2] -= S;
            Z1[3] -= S;

            S = Z1[1];

            Z1[1] -= S;
            Z1[3] -= S;

            Z1 = ModifyArray(Z1, Z1, false, false, false, true, 1, Z1[0]);

            //Ausgabe der Lösung
            Console.WriteLine();
            Console.WriteLine("Lösungsmenge:");
            Console.WriteLine();

            //Zeile 1
            Console.Write(Z1[0] + " " + Z1[1] + " " + Z1[2] + " " + "|" + " " + Z1[3]);
            Console.WriteLine();
            //Zeile 2
            Console.Write(Z2[0] + " " + Z2[1] + " " + Z2[2] + " " + "|" + " " + Z2[3]);
            Console.WriteLine();
            //Zeile 3
            Console.Write(Z3[0] + " " + Z3[1] + " " + Z3[2] + " " + "|" + " " + Z3[3]);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(x + Z1[3]);
            Console.WriteLine(y + Z2[3]);
            Console.WriteLine(z + Z3[3]);
            Console.ReadKey();

        }

        //Addition, Subtraktion, Multiplikation, Division

        private static double[] ModifyArray(double[] modifedArr, double[] dataArr, bool add, bool sub, bool multiply, bool divide, double mulitplyValue, double divideValue)
        {
            double[] result = new double[modifedArr.Length];


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
                
                if (sub)
                {
                    if (multiply || divide)
                    {
                        result[i] = SubArrayValue(result, dataArr, i);
                    }
                    else
                    {
                        result[i] = SubArrayValue(modifedArr, dataArr, i);
                    }

                }
                if (divide)
                {
                    result[i] = DivideArrayValue(modifedArr[i], divideValue);
                }
            }

            return result;
        }

        private static double AddArrayValue(double[] arr1, double[] arr2, int index)
        {
            return arr1[index] + arr2[index];
        }

        private static double SubArrayValue(double[] arr1, double[] arr2, int index)
        {
            return arr1[index] - arr2[index];
        }

        private static double MultiplyArrayValue(double arrayValue, double multiplyValue)
        {
            return arrayValue * multiplyValue;
        }

        private static double DivideArrayValue(double arrayValue, double divideValue)
        {
            return arrayValue / divideValue;
        }

        private static double GetMultiplyValue(double array1, double array2)
        {
            return ((array1 * array2) / array1);
        }
    }
}

