using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using PUC.Rasterizacao.Model.Algoritmos;
using PUC.Rasterizacao.Model.Enumeradores;
using PUC.Rasterizacao.Model.Interfaces;

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
            get
            {
                return _TipoDeTraco;
            }
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

        //// TODO: Método grande, refatorar!
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

                var raio = CalculeDistanciaEntreDoisPontos(centro, extremo) + 1; ////TODO: Verificar existência do + 1

                var trajeto = Circunferencia.CalculePontos(centro, raio);

                DesenheTrajeto(trajeto);

                //// TODO: Adicione circunferencia na tela.

                PontosDaCircunferencia.Clear();
            }
        }

        private void AdicionePixelParaElipse(Point ponto)
        {
            if (PontosDaElipse.Count < QUANTIDADE_MAXIMA_DE_PONTOS_PARA_ELIPSE)
            {
                if (!PontosDaElipse.Any())
                {
                    Tela.Limpe();
                }

                PontosDaElipse.Add(ponto);
                Tela.AdicionePixelNaGrade(ponto);
            }

            if (PontosDaElipse.Count == QUANTIDADE_MAXIMA_DE_PONTOS_PARA_ELIPSE)
            {
                var primeiroPonto = PontosDaElipse[(int)EnumPosicao.PRIMEIRO];
                var segundoPonto = PontosDaElipse[(int)EnumPosicao.SEGUNDO];
                var terceiroPonto = PontosDaElipse[(int)EnumPosicao.TERCEIRO];

                var altura = CalculeDistanciaEntreDoisPontos(primeiroPonto, segundoPonto);
                var largura = CalculeDistanciaEntreDoisPontos(primeiroPonto, terceiroPonto);

                var trajeto = Elipse.CalculePontos(primeiroPonto, (int)altura, (int)largura);

                DesenheTrajeto(trajeto);

                //// TODO: Adicione elipse na tela.

                PontosDaElipse.Clear();
            }
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

                var trajeto = Reta.CalculePontos(inicio, fim);

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

        private double CalculeDistanciaEntreDoisPontos(Point centro, Point extremo)
        {
            var x1 = centro.X;
            var x2 = extremo.X;
            var y1 = centro.Y;
            var y2 = extremo.Y;

            var x = Math.Pow(x1 - x2, 2);
            var y = Math.Pow(y1 - y2, 2);

            var distancia = Math.Sqrt(x + y);

            return distancia;
        }
    }
}