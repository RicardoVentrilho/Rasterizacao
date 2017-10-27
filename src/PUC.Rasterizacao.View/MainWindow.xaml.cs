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

        public void AdicionePixelNaGrade(Point coordenada)
        {
            Grade.PintePixel(coordenada);
        }

        public void Limpe()
        {
            Grade.Limpe();
        }

        public void AdicioneLinha(Point p1, Point p2)
        {
            Grade.PinteLinha(p1, p2);
        }

        private void CliqueBotaoEsquerdo(object sender, MouseButtonEventArgs e)
        {
            var coordenada = e.GetPosition(Grade);

            Controlador.AdicionePixel(coordenada);
        }
    }
}
