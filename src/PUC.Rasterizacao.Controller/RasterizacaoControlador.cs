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

        private EnumTipoDeTraco _TipoDeTraco = EnumTipoDeTraco.NENHUM;

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
            get => _TipoDeTraco;
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

        public void AdicionePonto(Point ponto)
        {
            switch (TipoDeTraco)
            {
                case EnumTipoDeTraco.RETA:
                    AdicionePixelParaReta(ponto);
                    break;
                case EnumTipoDeTraco.CIRCUNFERENCIA:
                    AdicionePixelParaCircunferencia(ponto);
                    break;
                case EnumTipoDeTraco.ELIPSE:
                    AdicionePixelParaElipse(ponto);
                    break;
                default:
                    throw new ArgumentException("Tipo de traço inválido, selecione tipo de traço na lista abaixo!");
            }
        }

        #endregion

        private void AdicionePixelParaCircunferencia(Point ponto)
        {
            if (PontosDaCircunferencia.Count < QUANTIDADE_MAXIMA_DE_PONTOS_PARA_CIRCUNFERENCIA)
            {
                if (!PontosDaCircunferencia.Any())
                {
                    Tela.Limpe();
                }

                PontosDaCircunferencia.Add(ponto);
                Tela.AdicionePixelNaGrade(ponto);
            }

            if (PontosDaCircunferencia.Count == QUANTIDADE_MAXIMA_DE_PONTOS_PARA_CIRCUNFERENCIA)
            {
                var centro = PontosDaCircunferencia[(int)EnumPosicao.PRIMEIRO];
                var extremo = PontosDaCircunferencia[(int)EnumPosicao.SEGUNDO];

                var raio = Tela.CalculeDistanciaEntreDoisPontos(centro, extremo);

                throw new NotImplementedException();
            }
        }

        private void AdicionePixelParaElipse(Point ponto)
        {
            throw new NotImplementedException();
        }

        //// TODO: Método grande, refatorar!
        private void AdicionePixelParaReta(Point ponto)
        {
            if (PontosDaLinha.Count < QUANTIDADE_MAXIMA_DE_PONTOS_PARA_LINHA)
            {
                if (!PontosDaLinha.Any())
                {
                    Tela.Limpe();
                }

                PontosDaLinha.Add(ponto);

                Tela.AdicionePixelNaGrade(ponto);
            }

            if (PontosDaLinha.Count == QUANTIDADE_MAXIMA_DE_PONTOS_PARA_LINHA)
            {
                var inicio = PontosDaLinha[(int)EnumPosicao.PRIMEIRO];
                var fim = PontosDaLinha[(int)EnumPosicao.SEGUNDO];

                var trajeto = Reta.Calcule(inicio, fim);

                DesenheTrajeto(trajeto);

                Tela.AdicioneLinha(inicio, fim);

                PontosDaLinha.Clear();
            }
        }

        private void DesenheTrajeto(List<Point> trajeto)
        {
            foreach (var ponto in trajeto)
            {
                Tela.AdicionePixelNaGrade(ponto);
            }
        }
    }
}