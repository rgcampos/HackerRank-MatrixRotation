using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Program
    {
        private static int _m = 0;
        private static int _n = 0;
        private static int _r = 0;

        public static void Main(string[] args)
        {
            var dataInformation = Console.ReadLine();
            if (!string.IsNullOrEmpty(dataInformation))
            {
                var arrDataInformation = dataInformation.Split(' ');
                if (arrDataInformation.Length == 3)
                {

                    _m = int.Parse(arrDataInformation[0]);
                    _n = int.Parse(arrDataInformation[1]);
                    _r = int.Parse(arrDataInformation[2]);

                    if (Enumerable.Range(2, 300).Contains(_m) && Enumerable.Range(2, 300).Contains(_n))
                    {
                        var matAux = new List<string>();
                        for (var i = 0; i < _m; i++)
                        {
                            matAux.Add(Console.ReadLine());
                        }

                        var mat = InitializeMatrix(matAux);
                        var layers = Math.Min(_m, _n) / 2;
                        var value = 0;

                        for (var i = 0; i < layers; i++)
                        {
                            var rotations = _r % (2 * (_m + _n - 4 * i) - 4);
                            for (var rot = 0; rot < rotations; rot++)
                            {
                                mat = Rotate(mat, i);
                            }
                        }

                        Show(mat);
                    }
                }
            }

            Console.ReadKey();
        }

        private static int[][] Rotate(int[][] mat, int layer)
        {
            var value = 0;
            for (var j = layer; j < _n - layer - 1; j++)
            {
                value = mat[layer][j];
                mat[layer][j] = mat[layer][j + 1];
                mat[layer][j + 1] = value;
            }
            for (var j = layer; j < _m - layer - 1; j++)
            {
                value = mat[j][_n - layer - 1];
                mat[j][_n - layer - 1] = mat[j + 1][_n - layer - 1];
                mat[j + 1][_n - layer - 1] = value;
            }
            for (var j = _n - layer - 1; j > layer; j--)
            {
                value = mat[_m - layer - 1][j];
                mat[_m - layer - 1][j] = mat[_m - layer - 1][j - 1];
                mat[_m - layer - 1][j - 1] = value;
            }
            for (var j = _m - layer - 1; j > layer + 1; j--)
            {
                value = mat[j][layer];
                mat[j][layer] = mat[j - 1][layer];
                mat[j - 1][layer] = value;
            }

            return mat;
        }

        private static void Show(int[][] mat)
        {
            Console.WriteLine(string.Empty);
            for (var i = 0; i < _m; i++)
            {
                var s = string.Empty;
                for (var j = 0; j < _n; j++)
                {
                    s += mat[i][j] + " ";
                }
                Console.WriteLine(s.Trim());
            }
        }

        private static int[][] InitializeMatrix(IEnumerable<string> aux)
        {
            var mat = new int[_m][];
            for (var i = 0; i < _m; i++)
            {
                mat[i] = new int[_n];

                var itens = aux.ElementAt(i).Split(' ');

                for (var j = 0; j < _n; j++)
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
