

using BoletoAppSol.Data.Context;
using BoletoAppSol.Data.Core;
using BoletoAppSol.Data.Entitiies;
using BoletoAppSol.Data.Interfaces;
using Microsoft.Extensions.Logging;

namespace BoletoAppSol.Data.Repositories
{
    public class AsientoRepository : IAsientoRepository
    {
        private readonly BoletoContext context;
        private readonly ILogger<AsientoRepository> logger;

        public AsientoRepository(BoletoContext context
                                )
        {
            this.context = context;
            //this.logger = logger;
        }
        public OperationResult AddAsiento(Asiento Asiento)
        {
            OperationResult result = new OperationResult();

            try
            {
                if (Asiento is null)
                {
                    result.Message = "El objeto asiento es requerido.";
                    result.Success = false;
                    return result;
                }
                if (!Asiento.NumeroPiso.HasValue)
                {
                    result.Message = "El numero de piso es requerido.";
                    result.Success = false;
                    return result;
                }

                if (Asiento.NumeroPiso < 0 || Asiento.NumeroPiso == 0) 
                {
                    result.Message = "El numero de piso no puede ser menor que cero o igual a cero";
                    result.Success = false;
                    return result;
                }
                if (Asiento.NumeroPiso < 0 || Asiento.NumeroPiso == 0)
                {
                    result.Message = "El numero de piso no puede ser menor que cero o igual a cero";
                    result.Success = false;
                    return result;
                }

                if (!Asiento.IdBus.HasValue)
                {
                    result.Message = "El bus es requerido.";
                    result.Success = false;
                    return result;
                }
                if (Asiento.IdBus < 0 || Asiento.IdBus == 0)
                {
                    result.Message = "El id del bus no puede ser menor que cero o igual a cero";
                    result.Success = false;
                    return result;
                }



                this.context.Asientos.Add(Asiento);
                this.context.SaveChanges();
                 
                result.Success = true;
                result.Message = "El asiento fue creado correctamente.";
                result.Data = Asiento;

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error agregando el asiento.";
                //this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public OperationResult UpdateAsiento(Asiento asiento)
        {
            OperationResult result = new OperationResult();

            try
            {
                if (asiento is null)
                {
                    result.Message = "El objeto asiento es requerido.";
                    result.Success = false;
                    return result;

                }
                if (!asiento.NumeroPiso.HasValue)
                {
                    result.Message = "El numero de piso es requerido.";
                    result.Success = false;
                    return result;
                }

                if (asiento.NumeroPiso < 0 || asiento.NumeroPiso == 0)
                {
                    result.Message = "El numero de piso no puede ser menor que cero o igual a cero";
                    result.Success = false;
                    return result;
                }
                if (asiento.NumeroPiso < 0 || asiento.NumeroPiso == 0)
                {
                    result.Message = "El numero de piso no puede ser menor que cero o igual a cero";
                    result.Success = false;
                    return result;
                }

                if (!asiento.IdBus.HasValue)
                {
                    result.Message = "El bus es requerido.";
                    result.Success = false;
                    return result;
                }
                if (asiento.IdBus < 0 || asiento.IdBus == 0)
                {
                    result.Message = "El id del bus no puede ser menor que cero o igual a cero";
                    result.Success = false;
                    return result;
                }

                this.context.Asientos.Update(asiento);
                this.context.SaveChanges();


            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error actualizando el asiento.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public OperationResult RemoveAsiento(Asiento Asiento)
        {
            OperationResult result = new OperationResult();
            try
            {

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error eliminando el asiento.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public OperationResult GetAsientoById(int id)
        {
            OperationResult result = new OperationResult();

            result.Data = this.context.Asientos.Find(id);

            return result;
        }
        public OperationResult GetAll()
        {
            OperationResult result = new OperationResult();

            result.Data = this.context.Asientos.ToList();

            return result;
        }
    }
}
