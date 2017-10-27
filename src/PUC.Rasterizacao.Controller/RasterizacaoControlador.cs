using PUC.Rasterizacao.Model.Algoritmos;
using PUC.Rasterizacao.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
                if (!PontosDaLinha.Any())
                {
                    Tela.Limpe();
                }

                PontosDaLinha.Add(coordenada);
                Tela.AdicionePixelNaGrade(coordenada);
            }

            if (PontosDaLinha.Count == QUANTIDADE_MAXIMA_DE_PONTOS_PARA_LINHA)
            {
                var p1Cache = PontosDaLinha[0];
                var p2Cache = PontosDaLinha[1];

                var pontosCalculados = Bresenham.Calcule(PontosDaLinha[0], PontosDaLinha[1]);

                foreach (var pontoCalculado in pontosCalculados)
                {
                    Tela.AdicionePixelNaGradeSemConverter(pontoCalculado);
                }

                Tela.AdicioneLinha(p1Cache, p2Cache);

                PontosDaLinha.Clear();
            }
        }
    }
}