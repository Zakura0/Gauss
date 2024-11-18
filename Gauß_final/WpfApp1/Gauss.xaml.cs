using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gauss_UI
{
    public partial class MainWindow : Window
    {
        int i = 0, j = 0, z, s, testint;
        double a;
        double[,] M;


        public MainWindow()
        {
            InitializeComponent();
        }

        //Buttons
        private void TButton_Click(object sender, RoutedEventArgs e)
        {
            string az = tbZeilen.Text;
            string asp = tbSpalten.Text;
            

            bool iszDouble = int.TryParse(az, out testint);
            bool issDouble = int.TryParse(asp, out testint);
            if (az == "" || asp == "" || !issDouble || !iszDouble) //Bool ob Eingabe = Zahl
            {
                z = 0;
                s = 0;
                lInfo4.Visibility = Visibility.Visible;
                lInfo4.Content = "Bitte nur (ganze) Zahlen eintragen!";
                bNeu.Visibility = Visibility.Visible;
            }
            else
            {
                z = int.Parse(az);
                lInfo.Visibility = Visibility.Hidden;
                s = int.Parse(asp);
                lInfo4.Visibility = Visibility.Hidden;
            }

            if (s < z)
            {
                lInfo3.Content = "Das Gleichungssystem ist nicht eindeutig lösbar!";
                bNeu.Visibility = Visibility.Visible;
                lInfo3.Visibility = Visibility.Visible;
            }
            else if (lInfo4.Visibility == Visibility.Hidden) //Wenn keine Fehler vorhanden sind
            {
                bEintrag.Visibility = Visibility.Visible;
                tbEintrag.Visibility = Visibility.Visible;
                lEintrag.Visibility = Visibility.Visible;
                lEintrag.Content = "Eintrag (" + (i + 1) + "," + (j + 1) + ") eingeben";
                lEing.Visibility = Visibility.Visible;
                tblbsp.Visibility = Visibility.Visible;
            }

            M = new double[z, s];
        }

        private void Neu_Click(object sender, RoutedEventArgs e)
        {
            bEintrag.Visibility = Visibility.Hidden;
            tbEintrag.Visibility = Visibility.Hidden;
            bBerechnen.Visibility = Visibility.Hidden;
            lEintrag.Visibility = Visibility.Hidden;
            lInfo.Visibility = Visibility.Hidden;
            lEing.Visibility = Visibility.Hidden;
            llösg.Visibility = Visibility.Hidden;
            tblJordan.Visibility = Visibility.Hidden;
            tblMatrix.Visibility = Visibility.Hidden;
            bNeu.Visibility = Visibility.Hidden;
            lInfo3.Visibility = Visibility.Hidden;
            lInfo2.Visibility = Visibility.Hidden;
            lInfo4.Visibility = Visibility.Hidden;
            llmenge.Visibility = Visibility.Hidden;
            tblbsp.Visibility = Visibility.Hidden;
            tbZeilen.Text = "";
            tbSpalten.Text = "";
            i = 0;
            j = 0;
            tblJordan.Text = "";
            tblMatrix.Text = "";
        }

        private void BEintrag_Click(object sender, RoutedEventArgs e)
        {
            tblMatrix.Visibility = Visibility.Visible;
            string tblstring;
            string astr = tbEintrag.Text;
            bool isDouble = int.TryParse(astr, out testint);
            if (astr == "" || !isDouble)
            {
                lInfo.Visibility = Visibility.Visible;
                lInfo.Content = "Bitte eine Zahl eintragen!" + Environment.NewLine + "(Eingabe wiederholen)";
                tbEintrag.Text = "";
            }
            else
            {
                a = Double.Parse(astr);
                lInfo.Visibility = Visibility.Hidden;
                if (i < M.GetLength(0))
                {
                    M[i, j] = a;

                    if (j == s - 1 & a >= 0)
                    {
                        tblstring = tblMatrix.Text + " |  " + a + Environment.NewLine;
                        tblMatrix.Text = tblstring;
                    }
                    else if (j == s - 1)
                    {
                        tblstring = tblMatrix.Text + " | " + a + Environment.NewLine;
                        tblMatrix.Text = tblstring;
                    }
                    else if (a >= 0)
                    {
                        tblstring = tblMatrix.Text + "  " + a;
                        tblMatrix.Text = tblstring;
                    }
                    else
                    {
                        tblstring = tblMatrix.Text + " " + a;
                        tblMatrix.Text = tblstring;
                    }

                    if (j == M.GetLength(1) - 1)
                    {
                        j = 0;
                        i++;
                    }
                    else
                    {
                        j++;
                    }

                    if (i == (M.GetLength(0)) & j == 0)
                    {
                        bBerechnen.Visibility = Visibility.Visible;
                        bNeu.Visibility = Visibility.Visible;
                        lEintrag.Visibility = Visibility.Hidden;
                        bEintrag.Visibility = Visibility.Hidden;
                        tbEintrag.Visibility = Visibility.Hidden;
                        tblbsp.Visibility = Visibility.Hidden;
                    }

                    lEintrag.Content = "Eintrag (" + (i + 1) + "," + (j + 1) + ") der Matrix eingeben";

                }
            }           
            tbEintrag.Text = "";            
        }

        private void Berechnen_Click(object sender, RoutedEventArgs e)
        {
            double[,] Y = Gauss(M);
            double[,] Z = Loesen(Y);
            string strjordan;
            double b;
            lEing.Visibility = Visibility.Hidden;
            llösg.Visibility = Visibility.Visible;
            tblJordan.Visibility = Visibility.Visible;
            tblMatrix.Visibility = Visibility.Hidden;
            bNeu.Visibility = Visibility.Visible;          
            for (int i = 0; i < z; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    b = M[i, j];
                    b =  Math.Round(b, 2);
                    if (j == s - 1 & b >= 0)
                    {
                        strjordan = tblJordan.Text + " |  " + b + Environment.NewLine;
                        tblJordan.Text = strjordan;
                    }
                    else if (j == s - 1)
                    {
                        strjordan = tblJordan.Text + " | " + b + Environment.NewLine;
                        tblJordan.Text = strjordan;
                    }
                    else if (b >= 0)
                    {
                        strjordan = tblJordan.Text + "  " + b;
                        tblJordan.Text = strjordan;
                    }
                    else
                    {
                        strjordan = tblJordan.Text + " " + b;
                        tblJordan.Text = strjordan;
                    }
                }
            }
            string strloesung = "";
            llmenge.Content = "L = {";
            for (int k = 0; k < z; k++)
            {
                
                int l = M.GetLength(1) - 1;
                double g = M[k, l];
                g = Math.Round(g, 2);
                if (k == z - 1)
                {
                    strloesung = llmenge.Content + "" + g;
                }
                else
                {
                    strloesung = llmenge.Content + "" + g + ", ";
                }
                llmenge.Content = strloesung;
            }
            llmenge.Content = strloesung + "}";
            llmenge.Visibility = Visibility.Visible;
        }

        //Rechnung
        private double[,] Gauss(double[,] M)
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
                        lInfo2.Visibility = Visibility.Visible;
                        bNeu.Visibility = Visibility.Visible;
                        break;
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
