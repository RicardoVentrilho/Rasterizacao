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

            bool troca = false;
            int y = y1;
            int x = x1;

            int deltaX = Math.Abs(x2 - x1);
            int deltaY = Math.Abs(y2 - y1);
            int sinalX = ObtenhaSinal(x2 - x1);
            int sinalY = ObtenhaSinal(y2 - y1);

            if (deltaY > deltaX)
            {
                var tmp = deltaX;
                deltaX = deltaY;
                deltaY = tmp;
                troca = true;
            }

            int erro = 2 * deltaY - deltaX;

            for (int i = 0; i < deltaX; i++)
            {
                pontos.Add(new Point(x, y));

                while (erro >= 0)
                {
                    if (troca)
                    {
                        x += sinalX;
                    }
                    else
                    {
                        y += sinalY;
                    }

                    erro = erro - 2 * deltaX;
                }

                if (troca)
                {
                    y += sinalY;
                }
                else
                {
                    x += sinalX;
                }

                erro = erro + 2 * deltaY;
            }

            return pontos;
        }

        public static List<Point> Calcule(Point inicio, Point fim)
        {
            return CalculePontos((int)inicio.X, (int)inicio.Y, (int)fim.X, (int)fim.Y);
        }

        private static int ObtenhaSinal(int numero)
        {
            return numero < 0 ? -1 : 1;
        }
    }
}
