using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PUC.Rasterizacao.View.Componentes
{
    public class Grade : Canvas
    {
        private int _Proporcao;
        private bool _ComLinhas;

        #region "PROPRIEDADES"

        public int Proporcao
        {
            get { return _Proporcao; }
            set { _Proporcao = value; }
        }

        public int Tamanho
        {
            get
            {
                return (int)Height;
            }
            set
            {
                Height = Width = value;
            }
        }

        public bool PinteLinhas
        {
            get { return _ComLinhas; }
            set
            {
                _ComLinhas = value;
                DesenheLinhas();
            }
        }

        #endregion

        public void Limpe()
        {
            Children.Clear();
            DesenheLinhas();
        }

        public void PintePixel(int x, int y)
        {
            var pixel = new Rectangle
            {
                Width = _Proporcao,
                Height = _Proporcao,
                Fill = Brushes.Black
            };

            SetLeft(pixel, x * _Proporcao);
            SetTop(pixel, y * _Proporcao);

            AdicionaElementoFilho(pixel);
        }

        public void ConvertaPonto(Point ponto)
        {
            ponto.X = ponto.X / _Proporcao;
            ponto.Y = ponto.Y / _Proporcao;
        }

        public void Atualize()
        {
            Dispatcher.Invoke(DispatcherPriority.Render, new Action(() => { }));
        }

        public void PintePixelSemCorverter(Point ponto)
        {
            PintePixel((int)ponto.X, (int)ponto.Y);
        }

        public void PintePixel(Point coordenada)
        {
            var x = coordenada.X / _Proporcao;
            var y = coordenada.Y / _Proporcao;

            PintePixel((int)x, (int)y);
        }

        public void PinteLinha(Point p1, Point p2)
        {
            var metadeDoPixel = _Proporcao / 2;
            var x1 = (int)p1.X / _Proporcao;
            var x2 = (int)p2.X / _Proporcao;
            var y1 = (int)p1.Y / _Proporcao;
            var y2 = (int)p2.Y / _Proporcao;

            var linha = new Line
            {
                X1 = (x1 * _Proporcao) + metadeDoPixel,
                X2 = (x2 * _Proporcao) + metadeDoPixel,
                Y1 = (y1 * _Proporcao) + metadeDoPixel,
                Y2 = (y2 * _Proporcao) + metadeDoPixel,
                Stroke = Brushes.Red
            };

            AdicionaElementoFilho(linha);
        }

        private void AdicionaLinhaHorizontal(int posicao)
        {
            var linha = new Line
            {
                Y1 = posicao,
                Y2 = posicao,
                X1 = 0,
                X2 = Tamanho,
                Stroke = Brushes.Gray
            };

            AdicionaElementoFilho(linha);
        }

        private void AdicionaLinhaVertical(int posicao)
        {
            var linha = new Line
            {
                Y1 = 0,
                Y2 = Tamanho,
                X1 = posicao,
                X2 = posicao,
                Stroke = Brushes.Gray
            };

            AdicionaElementoFilho(linha);
        }

        private void AdicionaElementoFilho(UIElement elemento)
        {
            Children.Add(elemento);
        }

        private void DesenheLinhas()
        {
            if (_ComLinhas)
            {
                int quantidadeDeLinhas = Tamanho / _Proporcao;


                for (int i = 0; i <= quantidadeDeLinhas; i++)
                {
                    AdicionaLinhaHorizontal(i * _Proporcao);
                    AdicionaLinhaVertical(i * _Proporcao);
                }
            }
        }
    }
}
