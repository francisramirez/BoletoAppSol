using BoletoAppSol.Data.Entitiies;
using BoletoAppSol.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoletoAppSol.Web.Controllers
{
    public class RutaController : Controller
    {
        private readonly IRutaRepository rutaRepository;

        public RutaController(IRutaRepository rutaRepository)
        {
            this.rutaRepository = rutaRepository;
        }
     
        public ActionResult Index()
        {
            var result = this.rutaRepository.GetAll();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            List<Ruta> rutas = (List<Ruta>)result.Data;

            return View(rutas);
        }
     
        public ActionResult Details(int id)
        {
            var result = this.rutaRepository.GetRutaById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            Ruta ruta = (Ruta)result.Data;

            return View(ruta);
        }

        
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ruta ruta)
        {
            try
            {
                var result = this.rutaRepository.AddRuta(ruta);
               
                if (!result.Success) 
                { 
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Edit(int id)
        {
            var result = this.rutaRepository.GetRutaById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            Ruta ruta = (Ruta)result.Data;

            return View(ruta);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ruta ruta)
        {
            try
            {
                var result = this.rutaRepository.UpdateRuta(ruta);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

         
    }
}
