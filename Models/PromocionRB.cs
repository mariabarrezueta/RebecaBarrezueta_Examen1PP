using System.ComponentModel.DataAnnotations;

namespace RebecaBarrezueta_Examen1P.Models
{
    public class PromocionRB
    {

        [Key]
        public int PromocionID_RB { get; set; }
        public string? Descripcion_RB { get; set; }
        public DateTime FechaPromo_RB { get; set; }
        public int  ZapatosID_RB { get; set; }
        public  ZapatosRB? ZapatosRB { get; set; }

    }
}
