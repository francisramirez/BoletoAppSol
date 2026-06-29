using BoletoAppSol.Data.Core;
using BoletoAppSol.Data.Entitiies;

namespace BoletoAppSol.Data.Interfaces
{
    public interface IBusRepository
    {
        OperationResult AddBus(Bus bus);
        OperationResult UpdateBus(Bus bus);
        OperationResult RemoveBus(Bus bus);
        OperationResult GetBusById(int id);
        OperationResult GetAll();
    }
}
