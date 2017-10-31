using System.Collections.Generic;
using System.Windows;

namespace PUC.Rasterizacao.Model.Algoritmos
{
    public static class Elipse
    {
        public static List<Point> CalculePontos(Point centro, int altura, int largura)
        {
            var pontos = new List<Point>();

            int x = 0, y = altura, erro = (altura * altura) - (largura * largura * altura) + ((largura * largura) / 4);

            while ((2 * x * altura * altura) < (2 * y * largura * largura))
            {
                pontos.Add(new Point(centro.X + x, centro.Y - y));
                pontos.Add(new Point(centro.X - x, centro.Y + y));
                pontos.Add(new Point(centro.X + x, centro.Y + y));
                pontos.Add(new Point(centro.X - x, centro.Y - y));

                if (erro < 0)
                {
                    x = x + 1;
                    erro = erro + (2 * altura * altura * x) + (altura * altura);
                }
                else
                {
                    x = x + 1;
                    y = y - 1;
                    erro = erro + (2 * altura * altura * x + altura * altura) - (2 * largura * largura * y);
                }
            }

            erro = (int)((x + 0.5) * (x + 0.5) * altura * altura + (y - 1) * (y - 1) * largura * largura - largura * largura * altura * altura);

            while (y >= 0)
            {
                pontos.Add(new Point(centro.X + x, centro.Y - y));
                pontos.Add(new Point(centro.X - x, centro.Y + y));
                pontos.Add(new Point(centro.X + x, centro.Y + y));
                pontos.Add(new Point(centro.X - x, centro.Y - y));

                if (erro > 0)
                {
                    y = y - 1;
                    erro = erro - (2 * largura * largura * y) + (largura * largura);

                }
                else
                {
                    y = y - 1;
                    x = x + 1;
                    erro = erro + (2 * altura * altura * x) - (2 * largura * largura * y) - (largura * largura);
                }
            }

            return pontos;
        }
    }
}
