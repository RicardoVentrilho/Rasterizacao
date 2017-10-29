using System.Windows;

namespace PUC.Rasterizacao.Model.Interfaces
{
    public interface ITelaRasterizacao
    {
        void AdicionePixelNaGrade(Point coordenada);

        void Limpe();

        void AdicioneLinha(Point inicio, Point fim);

        void Atualize();

        double CalculeDistanciaEntreDoisPontos(Point centro, Point extremo);
    }
}
