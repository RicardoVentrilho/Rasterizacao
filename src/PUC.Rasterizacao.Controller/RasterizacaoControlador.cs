using PUC.Rasterizacao.Model.Interfaces;

namespace PUC.Rasterizacao.Controller
{
    public class RasterizacaoControlador
    {
        public RasterizacaoControlador(ITelaRasterizacao tela)
        {
            Tela = tela;
        }

        public ITelaRasterizacao Tela { get; private set; }
    }
}
