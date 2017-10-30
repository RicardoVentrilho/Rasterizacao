using System.Collections.Generic;
using System.Windows;

namespace PUC.Rasterizacao.Model.Algoritmos
{
    public static class Circunferencia
    {
        public static List<Point> CalculePontos(Point centro, double raio)
        {
            var pontos = new List<Point>();

            int x = (int)raio - 1;
            int y = 0;
            int dx = 1;
            int dy = 1;
            int err = dx - ((int)raio << 1);

            while (x >= y)
            {
                pontos.Add(new Point(centro.X + x, centro.Y + y));
                pontos.Add(new Point(centro.X + y, centro.Y + x));
                pontos.Add(new Point(centro.X - y, centro.Y + x));
                pontos.Add(new Point(centro.X - x, centro.Y + y));
                pontos.Add(new Point(centro.X - x, centro.Y - y));
                pontos.Add(new Point(centro.X - y, centro.Y - x));
                pontos.Add(new Point(centro.X + y, centro.Y - x));
                pontos.Add(new Point(centro.X + x, centro.Y - y));

                if (err <= 0)
                {
                    y++;
                    err += dy;
                    dy += 2;
                }
                if (err > 0)
                {
                    x--;
                    dx += 2;
                    err += (-(int)raio << 1) + dx;
                }
            }

            return pontos;
        }
    }
}
