using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppsAssig2
{
    class PascalTriangle
    {
        private const int DEFAULT_NO_ROWS = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Pascal Triangle:");

            int[][] ragged = PascalTriangle.InitialiseRaggedArray(DEFAULT_NO_ROWS);
            PascalTriangle.FillRaggedArray(ragged);
            PascalTriangle.PrintRaggedArray(ragged);
        }

        public static void FillRaggedArray(int[][] ragged)
        {
            for (int i = ragged.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < ragged[i].Length; j++)
                {
                    if ((i == (ragged.Length - 1)) || j == 0)
                    {
                        ragged[i][j] = 1;
                    }
                    else
                    {
                        ragged[i][j] = ragged[i + 1][j] + ragged[i][j - 1];
                    }
                }
            }
        }

        public static void PrintRaggedArray(int[][] ragged)
        {
            for (int i = ragged.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < ragged[i].Length; j++)
                {
                    System.Console.Write("{0}{1}", ragged[i][j], j == (ragged[i].Length - 1) ? "" : "\t");
                }
                System.Console.WriteLine();
            }
        }

        private static int[][] InitialiseRaggedArray(int noRows)
        {
            int[][] ragged = new int[noRows][];

            for (int i = 0; i < ragged.Length; i++)
            {
                ragged[i] = new int[i + 1];
            }

            return ragged;
        }
    }
}