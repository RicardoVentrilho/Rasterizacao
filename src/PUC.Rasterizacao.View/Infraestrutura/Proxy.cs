using System;
using System.Windows;

namespace PUC.Rasterizacao.View.Infraestrutura
{
    public static class Proxy
    {
        public static void Execute(Action acao)
        {
            try
            {
                acao.Invoke();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
