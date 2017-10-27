using System.Windows;
using System.Windows.Input;
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
        }

        public RasterizacaoControlador Controlador { get; private set; }

        private void CliqueBotaoEsquerdo(object sender, MouseButtonEventArgs e)
        {
            var coordenada = e.GetPosition(Grade);

            Grade.PintePixel(coordenada);
        }
    }
}
