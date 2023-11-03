using System.ComponentModel.DataAnnotations;

namespace PROJETO.IHC.Domain.Enum
{
    public enum EStatusProposta
    {
        [Display(Name = "Aceita")]
        Aceito = 1,
        [Display(Name = "Recusada")]
        Recusada = 2,
        [Display(Name = "Cancelada")]
        Cancelada = 3,
        [Display(Name = "Vencida")]
        Vencida = 4
    }
}
