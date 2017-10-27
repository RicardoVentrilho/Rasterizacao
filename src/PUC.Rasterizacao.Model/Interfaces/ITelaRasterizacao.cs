using System.Windows;

namespace PUC.Rasterizacao.Model.Interfaces
{
    public interface ITelaRasterizacao
    {
        void AdicionePixelNaGrade(Point coordenada);

        void Limpe();

        void AdicioneLinha(Point p1, Point p2);
    }
}
