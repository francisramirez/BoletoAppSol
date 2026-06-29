

using System.ComponentModel.DataAnnotations;

namespace BoletoAppSol.Data.Entitiies
{
    public class Ruta
    {
        [Key]
        public int IdRuta { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
