using System.ComponentModel;

namespace PUC.Rasterizacao.Model.Enumeradores
{
    public enum EnumTipoDeTracos
    {
        [Description("Reta")]
        RETA,

        [Description("Circunferência")]
        CIRCUNFERENCIA,

        [Description("Elipse")]
        ELIPSE
    }
}
