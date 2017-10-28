using PUC.Rasterizacao.Controller;
using PUC.Rasterizacao.Model.Interfaces;
using System.Windows;
using System.Windows.Input;

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

        public void AdicioneLinha(Point inicio, Point fim)
        {
            Grade.PinteLinha(inicio, fim);
        }

        public void AdicionePixelNaGradeSemConverter(Point pontoCalculado)
        {
            Grade.PintePixelSemCorverter(pontoCalculado);
        }

        public void Atualize()
        {
            Grade.Atualize();
        }

        private void CliqueBotaoEsquerdo(object sender, MouseButtonEventArgs e)
        {
            var coordenada = e.GetPosition(Grade);

            Controlador.AdicionePixelParaLinha(coordenada);
        }

        public void ConvertaPontoParaGrade(Point ponto)
        {
            Grade.ConvertaPonto(ponto);
        }
    }
}
