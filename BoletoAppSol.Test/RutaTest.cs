using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using BoletoAppSol.Data.Context;
using BoletoAppSol.Data.Repositories;
using BoletoAppSol.Data.Entitiies;
using BoletoAppSol.Data.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoletoAppSol.Test
{
    public class RutaTest
    {
        private static RutaRepository CreateRepository(BoletoContext context)
        {
            return new RutaRepository(context, new NullLogger<RutaRepository>());
        }

        private class NullLogger<T> : ILogger<T>
        {
            public IDisposable BeginScope<TState>(TState state) => null!;
            public bool IsEnabled(LogLevel logLevel) => false;
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) { }
        }

        [Fact]
        public void AddRuta_Valid_Should_AddAndReturnSuccess()
        {
            // Arrange
            using var context = new BoletoContext();
            context.Database.EnsureDeleted();

            // Act
            var repo = CreateRepository(context);

            var ruta = new Ruta
            {
                Origen = "Ciudad A",
                Destino = "Ciudad B",
                FechaCreacion = DateTime.UtcNow
            };

            OperationResult result = repo.AddRuta(ruta);


            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
            Assert.True(context.Rutas.Any(r => r.Origen == "Ciudad A" && r.Destino == "Ciudad B"));
        }

        [Fact]
        public void AddRuta_Null_Should_ReturnError()
        {
            using var context = new BoletoContext();
            context.Database.EnsureDeleted();

            var repo = CreateRepository(context);

            OperationResult result = repo.AddRuta(null!);

            Assert.False(result.Success);
            Assert.Contains("requerido", result.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void AddRuta_Duplicate_Should_ReturnError()
        {
            using var context = new BoletoContext();
            context.Database.EnsureDeleted();

            var repo = CreateRepository(context);

            var ruta = new Ruta { Origen = "X", Destino = "Y", FechaCreacion = DateTime.UtcNow };
            context.Rutas.Add(ruta);
            context.SaveChanges();

            var duplicate = new Ruta { Origen = "X", Destino = "Y", FechaCreacion = DateTime.UtcNow };

            OperationResult result = repo.AddRuta(duplicate);

            Assert.False(result.Success);
            Assert.Contains("registrado", result.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void UpdateRuta_Valid_Should_UpdateAndReturnSuccess()
        {
            using var context = new BoletoContext();
            context.Database.EnsureDeleted();

            var repo = CreateRepository(context);

            var ruta = new Ruta { Origen = "Old", Destino = "D", FechaCreacion = DateTime.UtcNow };
            context.Rutas.Add(ruta);
            context.SaveChanges();

            ruta.Origen = "New";
            OperationResult result = repo.UpdateRuta(ruta);

            Assert.True(result.Success);

            var updated = context.Rutas.Find(ruta.IdRuta);
            Assert.NotNull(updated);
            Assert.Equal("New", updated!.Origen);
        }

        [Fact]
        public void RemoveRuta_Should_RemoveAndReturnSuccess()
        {
            using var context = new BoletoContext();
            context.Database.EnsureDeleted();

            var repo = CreateRepository(context);

            var ruta = new Ruta { Origen = "Rem", Destino = "D", FechaCreacion = DateTime.UtcNow };
            context.Rutas.Add(ruta);
            context.SaveChanges();

            OperationResult result = repo.RemoveRuta(ruta);

            Assert.True(result.Success);
            Assert.False(context.Rutas.Any(r => r.IdRuta == ruta.IdRuta));
        }

        [Fact]
        public void GetAll_Should_ReturnAllRoutes()
        {
            using var context = new BoletoContext();
            context.Database.EnsureDeleted();

            var repo = CreateRepository(context);

            context.Rutas.AddRange(new[]
            {
                new Ruta { Origen = "A", Destino = "B", FechaCreacion = DateTime.UtcNow },
                new Ruta { Origen = "C", Destino = "D", FechaCreacion = DateTime.UtcNow }
            });
            context.SaveChanges();

            OperationResult result = repo.GetAll();

            Assert.True(result.Success);
            var list = result.Data as List<Ruta>;
            Assert.NotNull(list);
            Assert.Equal(2, list!.Count);
        }

        [Fact]
        public void GetRutaById_Should_ReturnRoute()
        {
            using var context = new BoletoContext();
            context.Database.EnsureDeleted();

            var repo = CreateRepository(context);

            var ruta = new Ruta { Origen = "IdO", Destino = "IdD", FechaCreacion = DateTime.UtcNow };
            context.Rutas.Add(ruta);
            context.SaveChanges();

            OperationResult result = repo.GetRutaById(ruta.IdRuta);

            Assert.True(result.Success);
            var fetched = result.Data as Ruta;
            Assert.NotNull(fetched);
            Assert.Equal(ruta.IdRuta, fetched!.IdRuta);
        }
    }
}
