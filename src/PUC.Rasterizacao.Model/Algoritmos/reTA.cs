using System;
using System.Collections.Generic;
using System.Windows;

namespace PUC.Rasterizacao.Model.Algoritmos
{
    public static class Reta
    {
        ///TODO: Melhorar método, por favor!
        public static List<Point> CalculePontos(int x1, int y1, int x2, int y2)
        {
            var pontos = new List<Point>();

            int y = y1;
            int x = x1;

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            int p = 2 * dy - dx;

            if (x1 > x2)
            {
                return CalculePontos(x2, y2, x1, y1);
            }

            while (x < x2)
            {
                if (p >= 0)
                {
                    y++;
                    p = p + 2 * dy - 2 * dx;
                }
                else
                {
                    p = p + 2 * dy;
                }
                x++;

                pontos.Add(new Point(x, y));
            }

            return pontos;
        }

        ///TODO: Método provisório
        public static List<Point> Calcule(Point inicio, Point fim)
        {
            return CalculePontos((int)inicio.X, (int)inicio.Y, (int)fim.X, (int)fim.Y);
        }
    }
}
