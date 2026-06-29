
using System.ComponentModel.DataAnnotations;

namespace BoletoAppSol.Data.Entitiies
{
    public class Asiento
    {
        [Key]
        public int IdAsiento { get; set; }
        public int? IdBus { get; set; }
        public int? NumeroPiso { get; set; }

        public DateTime FechaCreacion { get; set; }
    }

}
