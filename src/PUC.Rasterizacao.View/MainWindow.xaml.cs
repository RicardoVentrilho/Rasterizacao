using PUC.Rasterizacao.Controller;
using PUC.Rasterizacao.Model.Enumeradores;
using PUC.Rasterizacao.Model.Interfaces;
using PUC.Rasterizacao.View.Infraestrutura;
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
            Controlador = new RasterizacaoControlador(this);

            InitializeComponent();

            AtualizeTela();
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

        public void Atualize()
        {
            Proxy.Execute(() =>
            {
                Grade.Atualize();
            });
        }

        #endregion

        #region "EVENTOS"

        private void AoClicarNaGrade(object sender, MouseButtonEventArgs e)
        {
            Proxy.Execute(() =>
            {
                var coordenada = e.GetPosition(Grade);

                var ponto = Grade.ConvertaCoordenada(coordenada);

                Controlador.AdicionePonto(ponto);
            });
        }

        private void AoSelecionarTipoDeTracos(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Proxy.Execute(() =>
            {
                var tipoDeTraco = (EnumTipoDeTraco)TipoDeTracos.SelectedItem;

                Controlador.TipoDeTraco = tipoDeTraco;
            });
        }

        #endregion

        #region "MÉTODOS PRIVADOS"

        private void AtualizeTela()
        {
            TipoDeTracos.ItemsSource = new[] { EnumTipoDeTraco.RETA, EnumTipoDeTraco.ELIPSE, EnumTipoDeTraco.CIRCUNFERENCIA };
        }

        #endregion
    }
}
