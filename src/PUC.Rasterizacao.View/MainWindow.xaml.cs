using PUC.Rasterizacao.Controller;
using PUC.Rasterizacao.Model.Interfaces;
using System.Windows;

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
        }

        public RasterizacaoControlador Controlador { get; private set; }
    }
}
