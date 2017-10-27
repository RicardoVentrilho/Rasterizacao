using System.Collections.Generic;
using System.Windows;
using PUC.Rasterizacao.Model.Interfaces;

namespace PUC.Rasterizacao.Controller
{
    public class RasterizacaoControlador
    {
        private const int QUANTIDADE_MAXIMA_DE_PONTOS_PARA_LINHA = 2;

        public RasterizacaoControlador(ITelaRasterizacao tela)
        {
            Tela = tela;

            PontosDaLinha = new List<Point>();
        }

        public List<Point> PontosDaLinha { get; set; }

        public ITelaRasterizacao Tela { get; private set; }

        public void Limpe()
        {
            Tela.Limpe();
        }

        public void AdicionePixel(Point coordenada)
        {
            if (PontosDaLinha.Count < QUANTIDADE_MAXIMA_DE_PONTOS_PARA_LINHA)
            {
                PontosDaLinha.Add(coordenada);
                Tela.AdicionePixelNaGrade(coordenada);
            }

            if (PontosDaLinha.Count == QUANTIDADE_MAXIMA_DE_PONTOS_PARA_LINHA)
            {
                var p1 = PontosDaLinha[0];
                var p2 = PontosDaLinha[1];

                Tela.AdicioneLinha(p1, p2);
            }
        }
    }
}
