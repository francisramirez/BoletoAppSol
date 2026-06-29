using BoletoAppSol.Data.Core;
using BoletoAppSol.Data.Entitiies;

namespace BoletoAppSol.Data.Interfaces
{
    public interface IAsientoRepository
    {
        OperationResult AddAsiento(Asiento Asiento);
        OperationResult UpdateAsiento(Asiento Asiento);
        OperationResult RemoveAsiento(Asiento Asiento);
        OperationResult GetAsientoById(int id);
        OperationResult GetAll();
    }
}
