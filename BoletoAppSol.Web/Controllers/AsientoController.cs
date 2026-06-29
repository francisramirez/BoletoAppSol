using BoletoAppSol.Data.Entitiies;
using BoletoAppSol.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoletoAppSol.Web.Controllers
{
    public class AsientoController : Controller
    {
        private readonly IAsientoRepository asientoRepository;

        public AsientoController(IAsientoRepository asientoRepository)
        {
            this.asientoRepository = asientoRepository;
        }
        
        public ActionResult Index()
        {
            var result = asientoRepository.GetAll();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            List<Asiento> asientos = (List<Asiento>)result.Data;
            return View(asientos);
        }

       
        public ActionResult Details(int id)
        {
            var result = asientoRepository.GetAsientoById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            Asiento asiento = (Asiento)result.Data;

            return View(asiento);
        }

       
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Asiento asiento)
        {
            try
            {
                var result = this.asientoRepository.AddAsiento(asiento);

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
            var result = asientoRepository.GetAsientoById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            Asiento asiento = (Asiento)result.Data;

            return View(asiento);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Asiento asiento)
        {
            try
            {
                var result = this.asientoRepository.UpdateAsiento(asiento);

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
