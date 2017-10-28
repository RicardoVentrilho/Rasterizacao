using System.Collections.Generic;
using System.Windows;

namespace PUC.Rasterizacao.Model.Interfaces.Negocio
{
    public interface IRasterizacao
    {
        List<Point> CalculePontosDeUmaReta(Point inicio, Point fim);

        List<Point> CalculePontosDeUmaCircunferencia(Point centro, double raio);
    }
}
