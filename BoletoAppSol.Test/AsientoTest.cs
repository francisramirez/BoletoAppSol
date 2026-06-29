using BoletoAppSol.Data.Core;
using BoletoAppSol.Data.Entitiies;
using BoletoAppSol.Data.Interfaces;
using BoletoAppSol.Data.Repositories;

namespace BoletoAppSol.Test
{
    public class AsientoTest
    {
        private readonly IAsientoRepository asientoRepository;

        public AsientoTest()
        {
            this.asientoRepository = new AsientoRepository(new Data.Context.BoletoContext());

            this.asientoRepository.AddAsiento(
                  new Data.Entitiies.Asiento()
                  {
                      FechaCreacion = DateTime.Now,
                      IdAsiento = 1,
                      IdBus = 1,
                      NumeroPiso = 2
                  }

                );
        }
        [Fact]
        public void AddAsiento_Asiento_IsNull()
        {
            // Arrange //
            Asiento asiento = null;

            // Act //
            var resultAddAsiento = this.asientoRepository.AddAsiento(asiento);
            string message = "El objeto asiento es requerido.";

            // Assert //
            Assert.IsType<OperationResult>(resultAddAsiento);
            Assert.False(resultAddAsiento.Success);
            Assert.Equal(message, resultAddAsiento.Message);
        }
       
        [Fact]
        public void AddAsiento_Asiento_NumeroPiso_IsNull()
        {
            // Arrange //
            Asiento asiento = new Asiento()
            {
                NumeroPiso = null,
                IdAsiento = 1,
                FechaCreacion = DateTime.Now,
                IdBus = 1,
            };

            // Act //
            var resultAddAsiento = this.asientoRepository.AddAsiento(asiento);
            string message = "El numero de piso es requerido.";

            // Assert //
            Assert.NotNull(resultAddAsiento);
            Assert.IsType<OperationResult>(resultAddAsiento);
            Assert.False(resultAddAsiento.Success);
            Assert.Equal(message, resultAddAsiento.Message);

        }
        [Fact]
        public void AddAsiento_Asiento_NumeroPiso_Menor_Cero()
        {
            // Arrange //
            Asiento asiento = new Asiento()
            {
                NumeroPiso = -1,
                IdAsiento = 1,
                FechaCreacion = DateTime.Now,
                IdBus = 1,
            };

            // Act //
            var resultAddAsiento = this.asientoRepository.AddAsiento(asiento);
            string message = "El numero de piso no puede ser menor que cero o igual a cero";

            // Assert //
            Assert.NotNull(resultAddAsiento);
            Assert.IsType<OperationResult>(resultAddAsiento);
            Assert.False(resultAddAsiento.Success);
            Assert.Equal(message, resultAddAsiento.Message);

        }


        [Fact]
        public void AddAsiento_Asiento_Success()
        {
            // Arrange //
            Asiento asiento = new Asiento()
            {
                NumeroPiso = 2,
                IdAsiento = 2,
                FechaCreacion = DateTime.Now,
                IdBus = 1,
            };

            // Act //
            var resultAddAsiento = this.asientoRepository.AddAsiento(asiento);
            string message = "El asiento fue creado correctamente.";

            // Assert //
            Assert.NotNull(resultAddAsiento);
            var operationResult = Assert.IsType<OperationResult>(resultAddAsiento);
            Asiento asientoAdded = (Asiento)operationResult.Data;
            Assert.NotNull(asientoAdded);
            Assert.True(resultAddAsiento.Success);
            Assert.Equal(message, resultAddAsiento.Message);
            Assert.Equal(asiento.IdAsiento, asientoAdded.IdAsiento);

        }

    }
}