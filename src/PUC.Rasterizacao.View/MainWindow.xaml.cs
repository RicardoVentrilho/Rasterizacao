using System.Windows;
using PUC.Rasterizacao.Controller;
using PUC.Rasterizacao.Model.Interfaces;

namespace PUC.Rasterizacao.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ITelaRasterizacao
    {
        public MainWindow()
        {
            InitializeComponent();

            Controlador = new RasterizacaoControlador(this);

            Grade.PintePixel(2, 2);
        }

        public RasterizacaoControlador Controlador { get; private set; }
    }
}
