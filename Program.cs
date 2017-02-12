using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dataInformation = Console.ReadLine();
            if (!string.IsNullOrEmpty(dataInformation))
            {
                var arrDataInformation = dataInformation.Split(' ');
                if (arrDataInformation.Length == 3)
                {

                    var m = int.Parse(arrDataInformation[0]);
                    var n = int.Parse(arrDataInformation[1]);
                    var r = int.Parse(arrDataInformation[2]);

                    if (Enumerable.Range(2, 300).Contains(m) && Enumerable.Range(2, 300).Contains(n))
                    {
                        var matAux = new List<string>();
                        for (var i = 0; i < m; i++)
                        {
                            matAux.Add(Console.ReadLine());
                        }

                        var mat = InitializeMatrix(m, n, matAux);
                        var layers = Math.Min(m, n) / 2;
                        var value = 0;

                        for (var i = 0; i < layers; i++)
                        {
                            var rotations = r % (2 * (m + n - 4 * i) - 4);
                            for (var rot = 0; rot < rotations; rot++)
                            {
                                for (var j = i; j < n - i - 1; j++)
                                {
                                    value = mat[i][j];
                                    mat[i][j] = mat[i][j + 1];
                                    mat[i][j + 1] = value;
                                }
                                for (var j = i; j < m - i - 1; j++)
                                {
                                    value = mat[j][n - i - 1];
                                    mat[j][n - i - 1] = mat[j + 1][n - i - 1];
                                    mat[j + 1][n - i - 1] = value;
                                }
                                for (var j = n - i - 1; j > i; j--)
                                {
                                    value = mat[m - i - 1][j];
                                    mat[m - i - 1][j] = mat[m - i - 1][j - 1];
                                    mat[m - i - 1][j - 1] = value;
                                }
                                for (var j = m - i - 1; j > i + 1; j--)
                                {
                                    value = mat[j][i];
                                    mat[j][i] = mat[j - 1][i];
                                    mat[j - 1][i] = value;
                                }
                            }
                        }

                        Show(mat, m, n);
                    }
                }
            }

            Console.ReadKey();
        }

        private static void Show(int[][] mat, int m, int n)
        {
            Console.WriteLine(string.Empty);
            for (var i = 0; i < m; i++)
            {
                var s = string.Empty;
                for (var j = 0; j < n; j++)
                {
                    s += mat[i][j] + " ";
                }
                Console.WriteLine(s.Trim());
            }
        }

        private static int[][] InitializeMatrix(int m, int n, IEnumerable<string> aux)
        {
            var mat = new int[m][];
            for (var i = 0; i < m; i++)
            {
                mat[i] = new int[n];

                var itens = aux.ElementAt(i).Split(' ');

                for (var j = 0; j < n; j++)
                {
                    if (j < itens.Length)
                    {
                        mat[i][j] = int.Parse(itens[j]);
                    }
                }
            }
            return mat;
        }
    }
}
