

using BoletoAppSol.Data.Core;
using BoletoAppSol.Data.Entitiies;

namespace BoletoAppSol.Data.Interfaces
{
    public interface IRutaRepository
    {
        OperationResult AddRuta(Ruta Ruta);
        OperationResult UpdateRuta(Ruta Ruta);
        OperationResult RemoveRuta(Ruta Ruta);
        OperationResult GetRutaById(int id);
        OperationResult GetAll();
    }
}
