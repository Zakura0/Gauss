using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaußobjekt
{
    public class Matrix
    {
        public int ZeilenAnz, SpaltenAnz;

        public double[,] LGS;

        public double[,] LGSeingabe(int ZeilenAnz,int SpaltenAnz)
        {
            for (int i = 0; i < ZeilenAnz; i++)
            {
                for (int j = 0; j < SpaltenAnz; j++)
                {
                    Console.Clear();
                    Console.WriteLine("Eintrag ({0},{1}) eingeben", (i + 1), (j + 1));
                    LGS[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            return LGS;
        }

        public void LGSausgabe(double[,] LGS, int ZeilenAnz, int SpaltenAnz, string satz)
        {
            Console.Clear();
            Console.WriteLine(satz);
            Console.WriteLine();
            for (int i = 0; i < ZeilenAnz; i++)
            {
                for (int j = 0; j < SpaltenAnz; j++)
                {
                    LGS[i, j] = Math.Round(LGS[i, j], 2);
                    if (LGS[i, j] >= 0)
                    {
                        Console.Write(" " + LGS[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(LGS[i, j] + " ");
                    }
                    if (j == LGS.GetLength(1) - 2)
                    {
                        Console.Write("| ");
                    }
                    if (j == SpaltenAnz - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();
        }

        public double[,] Gauss(double[,] M)
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

        public double[,] Jordan(double[,] M)
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
