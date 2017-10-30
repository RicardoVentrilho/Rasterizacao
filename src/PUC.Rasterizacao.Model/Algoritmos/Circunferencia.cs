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
            int deltaX = 1;
            int deltaY = 1;
            int err = deltaX - ((int)raio << 1);

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
                    err += deltaY;
                    deltaY += 2;
                }
                if (err > 0)
                {
                    x--;
                    deltaX += 2;
                    err += (-(int)raio << 1) + deltaX;
                }
            }

            return pontos;
        }
    }
}
