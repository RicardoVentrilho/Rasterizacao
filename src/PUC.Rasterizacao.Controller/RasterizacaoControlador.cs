using PUC.Rasterizacao.Model.Algoritmos;
using PUC.Rasterizacao.Model.Enumeradores;
using PUC.Rasterizacao.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PUC.Rasterizacao.Controller
{
    public class RasterizacaoControlador
    {
        #region "CONTANTES"

        private const int QUANTIDADE_MAXIMA_DE_PONTOS_PARA_LINHA = 2;
        private const int QUANTIDADE_MAXIMA_DE_PONTOS_PARA_CIRCUNFERENCIA = 2;
        private const int QUANTIDADE_MAXIMA_DE_PONTOS_PARA_ELIPSE = 3;

        #endregion

        #region "CAMPOS"

        private EnumTipoDeTraco _TipoDeTraco;

        #endregion

        #region "CONSTRUTOR"

        public RasterizacaoControlador(ITelaRasterizacao tela)
        {
            Tela = tela;

            PontosDaLinha = new List<Point>();
            PontosDaCircunferencia = new List<Point>();
            PontosDaElipse = new List<Point>();
        }

        #endregion

        #region "PROPRIEDADES"

        public List<Point> PontosDaLinha { get; set; }

        public ITelaRasterizacao Tela { get; private set; }

        public List<Point> PontosDaElipse { get; private set; }

        public List<Point> PontosDaCircunferencia { get; private set; }

        public EnumTipoDeTraco TipoDeTraco
        {
            get => TipoDeTraco;
            set
            {
                Limpe();
                _TipoDeTraco = value;
            }
        }

        #endregion

        #region "MÉTODOS PÚBLICOS"

        public void Limpe()
        {
            PontosDaLinha.Clear();
            PontosDaElipse.Clear();
            PontosDaCircunferencia.Clear();

            Tela.Limpe();
        }

        public void AdicionePixelParaCircunferencia(Point coordenada)
        {
            Tela.ConvertaPontoParaGrade(coordenada);

            if (PontosDaCircunferencia.Count < QUANTIDADE_MAXIMA_DE_PONTOS_PARA_CIRCUNFERENCIA)
            {
                if (!PontosDaCircunferencia.Any())
                {
                    Tela.Limpe();
                }

                PontosDaCircunferencia.Add(coordenada);
                Tela.AdicionePixelNaGrade(coordenada);
            }

            if (PontosDaCircunferencia.Count == QUANTIDADE_MAXIMA_DE_PONTOS_PARA_CIRCUNFERENCIA)
            {
                var centro = PontosDaCircunferencia[(int)EnumPosicao.PRIMEIRO];
                var extremo = PontosDaCircunferencia[(int)EnumPosicao.SEGUNDO];

                var raio = Tela.CalculeDistanciaEntreDoisPontos(centro, extremo);

                throw new NotImplementedException();
            }
        }

        public void AdicionePixelParaElipse(Point coordenada)
        {
            Tela.ConvertaPontoParaGrade(coordenada);

            throw new NotImplementedException();
        }

        public void AdicionePixelParaLinha(Point coordenada)
        {
            Tela.ConvertaPontoParaGrade(coordenada);

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
                var inicio = PontosDaLinha[(int)EnumPosicao.PRIMEIRO];
                var fim = PontosDaLinha[(int)EnumPosicao.SEGUNDO];

                var trajeto = Reta.Calcule(inicio, fim);

                DesenheTrajeto(trajeto);
            }
        }

        #endregion

        private void DesenheTrajeto(List<Point> trajeto)
        {
            var inicioCache = PontosDaLinha[(int)EnumPosicao.PRIMEIRO];
            var fimCache = PontosDaLinha[(int)EnumPosicao.SEGUNDO];

            foreach (var ponto in trajeto)
            {
                Tela.AdicionePixelNaGradeSemConverter(ponto);
            }

            Tela.AdicioneLinha(inicioCache, fimCache);

            PontosDaLinha.Clear();
        }
    }
}