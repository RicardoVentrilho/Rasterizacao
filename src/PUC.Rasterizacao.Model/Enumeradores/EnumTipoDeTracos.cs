using System.ComponentModel;

namespace PUC.Rasterizacao.Model.Enumeradores
{
    public enum EnumTipoDeTraco
    {
        [Description("Reta")]
        RETA,

        [Description("Circunferência")]
        CIRCUNFERENCIA,

        [Description("Elipse")]
        ELIPSE
    }
}
