using PUC.Rasterizacao.Controller;
using PUC.Rasterizacao.Model.Interfaces;
using PUC.Rasterizacao.View.Infraestrutura;
using System;
using System.Windows;
using System.Windows.Input;

namespace PUC.Rasterizacao.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ITelaRasterizacao
    {
        #region "INICIALIZA TELA"

        public MainWindow()
        {
            InitializeComponent();

            Controlador = new RasterizacaoControlador(this);
        }

        #endregion

        #region "PROPRIEDADES"

        public RasterizacaoControlador Controlador { get; private set; }

        #endregion

        #region "MÉTODOS PÚBLICOS"

        public void AdicionePixelNaGrade(Point coordenada)
        {
            Proxy.Execute(() =>
            {
                Grade.PintePixel(coordenada);
            });
        }

        public void Limpe()
        {
            Proxy.Execute(() =>
            {
                Grade.Limpe();
            });
        }

        public void AdicioneLinha(Point inicio, Point fim)
        {
            Proxy.Execute(() =>
            {
                Grade.PinteLinha(inicio, fim);
            });
        }

        public void AdicionePixelNaGradeSemConverter(Point pontoCalculado)
        {
            Proxy.Execute(() =>
            {
                Grade.PintePixelSemCorverter(pontoCalculado);
            });
        }

        public void Atualize()
        {
            Proxy.Execute(() =>
            {
                Grade.Atualize();
            });
        }

        public void ConvertaPontoParaGrade(Point ponto)
        {
            Proxy.Execute(() =>
            {
                Grade.ConvertaPonto(ponto);
            });
        }

        public double CalculeDistanciaEntreDoisPontos(Point centro, Point extremo)
        {
            throw new NotImplementedException();
        }

        #endregion

        private void AoClicarNaGrade(object sender, MouseButtonEventArgs e)
        {
            Proxy.Execute(() =>
            {
                var coordenada = e.GetPosition(Grade);

                Controlador.AdicionePixelParaLinha(coordenada);
            });
        }

        private void AoCarregarWindow(object sender, RoutedEventArgs e)
        {
            Proxy.Execute(() =>
            {

            });
        }
    }
}
