using System;
using System.Windows.Controls;

namespace PUC.Rasterizacao.View.Componentes
{
    public class Grade : Canvas
    {
        private bool _ComLinhas;

        #region "PROPRIEDADES"

        public int Tamanho
        {
            get => (int)Height;
            set => Height = Width = value;
        }

        public bool PinteLinhas
        {
            get => _ComLinhas;
            set
            {
                _ComLinhas = value;

                if (_ComLinhas)
                {
                    int quantidadeDeLinhas = Tamanho / 10;

                    for (int i = 0; i < quantidadeDeLinhas; i++)
                    {
                        AdicionaLinhaVertical(i);
                        AdicionaLinhaHorizontal(i);
                    }
                }
            }
        }

        #endregion

        private void AdicionaLinhaHorizontal(int posicao)
        {
            throw new NotImplementedException();
        }

        private void AdicionaLinhaVertical(int posicao)
        {
            throw new NotImplementedException();
        }
    }
}
