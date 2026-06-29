

using BoletoAppSol.Data.Context;
using BoletoAppSol.Data.Core;
using BoletoAppSol.Data.Entitiies;
using BoletoAppSol.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoletoAppSol.Data.Repositories
{
    public class BusRepository : IBusRepository
    {
        private readonly BoletoContext _context;
        public BusRepository(BoletoContext context)
        {
            _context = context;
        }
        public OperationResult AddBus(Bus bus)
        {
            OperationResult result = new OperationResult();

            try
            {
                if (bus == null)
                {
                    result.Message = "El objeto bus es requerido.";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(bus.Nombre))
                {
                    result.Message = "El nombre requerido";
                    result.Success = false;
                    return result;
                }

                if (bus.Nombre.Length > 50)
                {
                    result.Message = "La longitud del nombre es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(bus.NumeroPlaca))
                {
                    result.Message = "El numero de placa requerido";
                    result.Success = false;
                    return result;
                }

                if (bus.NumeroPlaca.Length > 10)
                {
                    result.Message = "La longitud de la placa es invalida";
                    result.Success = false;
                    return result;
                }


                if (_context.Buses.Any(cd => cd.NumeroPlaca == bus.NumeroPlaca))
                {
                    result.Message = "El numero de placa se encuentra registrado.";
                    result.Success = false;
                    return result;
                }

                _context.Buses.Add(bus);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error guardando la inforacion del bus.";
            }
            return result;
        }
        public OperationResult UpdateBus(Bus bus)
        {
            OperationResult result = new OperationResult();

            try
            {
                if (bus == null)
                {
                    result.Message = "El objeto bus no puede null";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(bus.Nombre))
                {
                    result.Message = "El nombre requerido";
                    result.Success = false;
                    return result;
                }

                if (bus.Nombre.Length > 50)
                {
                    result.Message = "La longitud del nombre es invalida";
                    result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(bus.NumeroPlaca))
                {
                    result.Message = "El numero de placa requerido";
                    result.Success = false;
                    return result;
                }

                if (bus.NumeroPlaca.Length > 10)
                {
                    result.Message = "La longitud de la placa es invalida";
                    result.Success = false;
                    return result;
                }

                Bus? busToUpdate = _context.Buses.Find(bus.IdBus);

                if (busToUpdate is null)
                {
                    result.Message = "El bus que desea actualizar no se encuentra registrado.";
                    result.Success = false;
                    return result;
                }

                busToUpdate.NumeroPlaca = bus.NumeroPlaca;
                busToUpdate.Nombre = bus.Nombre;
                busToUpdate.Disponible = bus.Disponible;
                busToUpdate.CapacidadPiso1 = bus.CapacidadPiso1;
                busToUpdate.CapacidadPiso2 = bus.CapacidadPiso2;

                _context.Buses.Update(busToUpdate);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error actualizando la inforacion del bus.";
            }
            return result;
        }
        public OperationResult RemoveBus(Bus bus)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (bus is null)
                {
                    result.Message = "El objeto bus es requerido.";
                    result.Success = false;
                    return result;
                }

                Bus? busToRemove = _context.Buses.Find(bus.IdBus);

                if (busToRemove is null)
                {
                    result.Message = "El bus que desea actualizar no se encuentra registrado.";
                    result.Success = false;
                    return result;
                }

                _context.Buses.Remove(busToRemove);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                result.Success = false;
                result.Message = "Ocurrio un error eliminando la inforacion del bus.";
            }
            return result;
        }
        public OperationResult GetBusById(int id)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = _context.Buses.Find(id);

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ocurrio un error obteniendo la inforacion del bus.";
            }
            return result;
        }
        public OperationResult GetAll()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = _context.Buses.ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo la inforacion del bus.";
            }
            return result;
        }
    }
}
