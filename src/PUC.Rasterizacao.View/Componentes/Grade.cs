using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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

        #endregion

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
    }
}
