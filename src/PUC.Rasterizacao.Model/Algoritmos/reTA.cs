using System.Collections.Generic;
using System.Windows;

namespace PUC.Rasterizacao.Model.Algoritmos
{
    public static class Reta
    {
        ///TODO: Melhorar método, por favor!
        public static List<Point> CalculePontos(int x1, int x2, int y1, int y2)
        {
            var pontos = new List<Point>();

            int incE, incNE, d, slope;
            int y = y1;
            int x = x1;

            int dx = x2 - x1;
            int dy = y2 - y1;

            if (x1 > x2)
            {
                return CalculePontos(x2, x1, y2, y1);
            }

            if (dy < 0)
            {
                slope = -1;
                dy = -dy;
            }
            else
            {
                slope = 1;
            }

            incE = 2 * dy;
            incNE = 2 * dy - 2 * dx;
            d = 2 * dy - dx;
            y = y1;

            for (x = x1; x < x2; x++)
            {
                var ponto = new Point(x, y);
                pontos.Add(ponto);

                if (d <= 0)
                {
                    d += incE;
                }
                else
                {
                    d += incNE;
                    y += slope;
                }
            }

            return pontos;
        }

        ///TODO: Método provisório
        public static List<Point> Calcule(Point inicio, Point fim)
        {
            return CalculePontos((int)inicio.X, (int)fim.X, (int)inicio.Y, (int)fim.Y);
        }
    }
}
