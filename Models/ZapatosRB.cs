using System.ComponentModel.DataAnnotations;

namespace RebecaBarrezueta_Examen1P.Models
{
    public class ZapatosRB
    {
        [Key]
        public int ZapatosID_RB { get; set; }

        [Required]
        public string Nombre_RB { get; set; }
        public bool EdicionEspecial_RB { get; set; }

        [Range(0.01, 9999.99)]
        public decimal Precio_RB { get; set; }
        public List<PromocionRB>? PromocionRB { get; set; }
    }
}
