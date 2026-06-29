using BoletoAppSol.Data.Core;
using BoletoAppSol.Data.Entitiies;
using BoletoAppSol.Data.Interfaces;
using BoletoAppSol.Data.Repositories;

namespace BoletoAppSol.Test
{
    public class BusTest
    {
        private readonly IBusRepository busRepository;

        public BusTest()
        {
            this.busRepository = new BusRepository(new Data.Context.BoletoContext());
        }
        [Fact]
        public void AddBus_Bus_IsNull()
        {
            // Arrange //
            Bus bus = null;
            
            // Act //
            var resultAddBus = this.busRepository.AddBus(bus);
            string message = "El objeto bus es requerido.";
         
            // Assert //
            Assert.IsType<OperationResult>(resultAddBus);
            Assert.False(resultAddBus.Success);
            Assert.Equal(message, resultAddBus.Message);
            Assert.Null(resultAddBus.Data);
        }
        [Fact]
        public void RemoveBus_Bus_IsNull() 
        {
            // Arrange //
            Bus bus = null;

            // Act //
            var resultRemoveBus = this.busRepository.RemoveBus(bus);
            string message = "El objeto bus es requerido.";

            // Assert //
            Assert.IsType<OperationResult>(resultRemoveBus);
            Assert.False(resultRemoveBus.Success);
            Assert.Equal(message, resultRemoveBus.Message);
        }
    }
}
