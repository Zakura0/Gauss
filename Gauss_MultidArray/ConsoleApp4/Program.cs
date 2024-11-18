using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaussmethode
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Zeilananzahl eingeben");
            int z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(z);

            Console.WriteLine("Anzahl der Unbekannten eingeben");
            int s = Convert.ToInt32(Console.ReadLine());

            if (s < z)
            {
                Console.WriteLine("Das Gleichungssystem ist nicht eindeutig loesbar");
                Console.ReadLine();
                Environment.Exit(0);
            }

            double[,] M = new double[z, s];            

            //Eingabe der Koeffizienten
            for (int i = 0; i < z; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    Console.Clear();
                    Console.WriteLine("Eintrag ({0},{1}) eingeben" , (i + 1), (j + 1));
                    M[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            //Ausgabe der Matrix
            Console.Clear();
            Console.WriteLine("Eingegebene Matrix:");
            Console.WriteLine();
            for (int i = 0; i < z; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    M[i, j] = Math.Round(M[i, j], 2);
                    if (M[i, j] >= 0)
                    {
                        Console.Write(" " + M[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(M[i, j] + " ");
                    }
                    if (j == M.GetLength(1) - 2)
                    {
                        Console.Write("| ");
                    }
                    if (j == s - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();

            double[,] Y = Gauss(M);

            Console.WriteLine();
            Console.WriteLine("Gelöste Matrix:");
            Console.WriteLine();

            double[,] Z = Loesen(Y);

            Console.WriteLine();

            for (int i = 0; i < z; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    if (M[i, j] >= 0)
                    {
                        Console.Write(" " + Z[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(Z[i, j] + " ");
                    }
                    if (j == M.GetLength(1) - 2)
                    {
                        Console.Write("| ");
                    }
                    if (j == s - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();

            //    Console.WriteLine();
            //    Console.WriteLine("Lösungsmenge:");
            //    Console.WriteLine();
            //    for (int i = 0; i < M.GetLength(0); i++)
            //    {
            //        Console.WriteLine(M[i, M.GetLength(1) - 1]);
            //        Console.WriteLine();
            //    }
            //    Console.ReadKey();

        }
        
        private static double[,] Gauss(double[,] M)
        {
            for (int i = 0; i < M.GetLength(0); i++)
            {

                //Austauschen der Zeilen falls 0 an 1. Stelle
                int k = i;
                while (M[i, i] == 0)
                {
                    k++;
                    if (k == M.GetLength(0))
                    {
                        Console.Clear();
                        Console.WriteLine("Das Gleichungssystem hat keine Lösung!");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    else if (M[k, i] != 0)
                    {
                        for (int n = i; n < M.GetLength(1); n++)
                        {
                            double a = M[i, n];
                            double b = M[k, n];
                            M[i, n] = b;
                            M[k, n] = a;
                        }
                    }


                }
                //Teilen durch Zahl an 1. Stelle der Zeile
                for (int l = i; l < M.GetLength(1); l++)
                {
                    double o = M[i, i];
                    for (int n = i; n < M.GetLength(1); n++)
                    {
                        M[i, n] = M[i, n] / o;
                    }
                }
                //Multiplikation mit der Zahl der nächsten Zeile und anschließende Subtraktion
                for (int z = i + 1; z < M.GetLength(0); z++)
                {
                    double c = M[z, i];
                    for (int n = i; n < M.GetLength(1); n++)
                    {
                        M[z, n] -= (c * M[i, n]);
                    }
                }


            }
            return M;
        }

        private static double[,] Loesen(double[,] M)
        {
            int g = M.GetLength(0) - 1;
            int h = 1;
            for (int i = (M.GetLength(0) - 2); i >= 0; i--)
            {
                int t = M.GetLength(1) - 2;
                for (int m = 0; m < h; m++)
                {
                    double c = M[i, t];
                    for (int n = 0; n < M.GetLength(1); n++)
                    {
                        M[i, n] -= (c * M[g, n]);
                    }
                    t -= 1;
                    g -= 1;
                }
                h += 1;
                g = M.GetLength(0) - 1;
            }
            return M;
        }
    }
}