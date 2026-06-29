using BoletoAppSol.Data.Context;
using BoletoAppSol.Data.Core;
using BoletoAppSol.Data.Entitiies;
using BoletoAppSol.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace BoletoAppSol.Data.Repositories
{
    public class RutaRepository : IRutaRepository
    {
        private readonly BoletoContext context;
        private readonly ILogger<RutaRepository> logger;

        public RutaRepository(BoletoContext context, ILogger<RutaRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public OperationResult AddRuta(Ruta Ruta)
        {
            OperationResult result = new OperationResult();

            try
            {
                if (Ruta is null)
                {
                    throw new ArgumentNullException(nameof(Ruta));  
                    result.Success = false;
                    result.Message = "El objeto ruta es requerido.";
                    return result;

                }
                if (string.IsNullOrEmpty(Ruta.Origen))
                {
                    result.Success = false;
                    result.Message = "El origen de la ruta es requerido.";
                    return result;
                }
                if (Ruta.Origen.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El origen de la ruta no puede ser mayor a 50 caracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(Ruta.Destino))
                {
                    result.Success = false;
                    result.Message = "El destino de la ruta es requerido.";
                    return result;
                }
                if (Ruta.Destino.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El destino de la ruta no puede ser mayor a 50 caracteres.";
                    return result;
                }
                if (this.context.Rutas.Any(ruta => ruta.Origen == Ruta.Origen && ruta.Destino == Ruta.Destino))
                {
                    result.Success = false;
                    result.Message = "El origen y la ruta del bus se encuentra registrado.";
                    return result;
                }

                this.context.Rutas.Add(Ruta);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ocurrió un error agregando la ruta.";
                this.logger.LogError(result.Message, ex.ToString());
            }


            return result;
        }
        public OperationResult UpdateRuta(Ruta Ruta)
        {
            OperationResult result = new OperationResult();

            try
            {
                if (Ruta is null)
                {
                    result.Success = false;
                    result.Message = "El objeto ruta es requerido.";
                    return result;

                }
                if (string.IsNullOrEmpty(Ruta.Origen))
                {
                    result.Success = false;
                    result.Message = "El origen de la ruta es requerido.";
                    return result;
                }
                if (Ruta.Origen.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El origen de la ruta no puede ser mayor a 50 caracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(Ruta.Destino))
                {
                    result.Success = false;
                    result.Message = "El destino de la ruta es requerido.";
                    return result;
                }
                if (Ruta.Destino.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El destino de la ruta no puede ser mayor a 50 caracteres.";
                    return result;
                }
              
                this.context.Rutas.Update(Ruta);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ocurrió un error agregando la ruta.";
                this.logger.LogError(result.Message, ex.ToString());
            }


            return result;
        }
        public OperationResult RemoveRuta(Ruta Ruta)
        {
            OperationResult result = new OperationResult();

            try
            {
                if (Ruta is null)
                {
                    result.Success = false;
                    result.Message = "El objeto ruta es requerido.";
                    return result;

                }

                this.context.Remove(Ruta);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ocurrió un error agregando la ruta.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
        public OperationResult GetAll()
        {
            OperationResult result = new OperationResult();
            result.Data = this.context.Rutas.ToList();
            return result;
        }

        public OperationResult GetRutaById(int id)
        {
            OperationResult result = new OperationResult();

            result.Data = this.context.Rutas.Find(id);

            return result;
        }




    }
}
