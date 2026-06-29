using BoletoAppSol.Data.Entitiies;
using BoletoAppSol.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoletoAppSol.Web.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusRepository busRepository;

        public BusController(IBusRepository busRepository) 
        {
            this.busRepository = busRepository;
        }
        // GET: BusController
        public ActionResult Index()
        {
            var result = busRepository.GetAll();
            
            if (!result.Success)
            {
                return View();
            }

            List<Bus> buses = (List<Bus>)result.Data;
            return View(buses);
        }

        // GET: BusController/Details/5
        public ActionResult Details(int id)
        {
            var result = busRepository.GetBusById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            Bus bus = (Bus)result.Data;
            return View(bus);
        }

        // GET: BusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bus bus)
        {
            try
            {
               var result = this.busRepository.AddBus(bus);

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

        // GET: BusController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = busRepository.GetBusById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            Bus bus = (Bus)result.Data;
            return View(bus);
        }

        // POST: BusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bus bus)
        {
            try
            {
                var result = busRepository.UpdateBus(bus);

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
