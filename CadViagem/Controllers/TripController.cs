using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadViagem.Data;
using CadViagem.Extensions;
using CadViagem.Models;
using CadViagem.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CadViagem.Controllers
{
    public class TripController : Controller
    {
        private readonly ITripRepository _tripRepository;
        private readonly DataBaseContext _dataBaseContext;

        public TripController(ITripRepository tripRepository, DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
            _tripRepository = tripRepository;
        }

        public IActionResult Index()
        {
            List<TripViewModel> trips = _tripRepository.SearchAll();
            return View(trips);
        }

        public IActionResult CreateTrip()
        {
            var driversBag = _dataBaseContext.Driver.Where(x => x.Id == x.Id).ToList();

            var tripVWM = new TripViewModel();
            tripVWM.Drivers = driversBag.ToSelectList("Id", "FirstName").AddDefaultOption();

            return View(tripVWM);
        }

        [HttpPost]
        public IActionResult CreateTrip(TripViewModel vm)
        {
            try
            {
                if (vm.validate().Any())
                {
                    foreach (var error in vm.validate())
                    {
                        ModelState.AddModelError(error.Key, error.Value);
                    }
                }
                var driversBag = _dataBaseContext.Driver.Where(x => x.Id == x.Id).ToList();
                var tripVWM = new TripViewModel();
                tripVWM.Drivers = driversBag.ToSelectList("Id", "FirstName").AddDefaultOption();

                if (ModelState.IsValid)
                {
                    _tripRepository.AddTrip(vm);
                    TempData["MensagemSucesso"] = "Viagem cadastrada com sucesso";
                    return RedirectToAction("Index");
                }
                return View(tripVWM);
            }
            catch (System.Exception error)
            {
                TempData["MensagemErro"] = $"Que pena, não foi possivel cadastrar a viagem, tente novamente, ERRO: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
