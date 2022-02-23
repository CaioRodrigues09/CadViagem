using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadViagem.Repositories;
using CadViagem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadViagem.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDriverRepository _driverRepository;
        

        public DriverController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public IActionResult Index()
        {
            List<DriverViewModel> drivers = _driverRepository.SearchAll();
            return View(drivers);
        }

        public IActionResult CreateDriver()
        {
            return View();
        }

        public IActionResult EditDriver(Guid id)
        {
            DriverViewModel drivers = _driverRepository.GetById(id);
            return View(drivers);
        }

        public IActionResult DeleteDriver(Guid id)
        {
            DriverViewModel drivers = _driverRepository.GetById(id);
            return View(drivers);
        }

        public IActionResult Delete(Guid id)
        {
            try
            {
                bool delete = _driverRepository.Delete(id);
                if (delete)
                {
                    TempData["MensagemSucesso"] = "Motorista apagado com sucesso.";
                }
                else
                {
                    TempData["MensagemErro"] = $"Que pena, não foi possivel apagar o motorista, tente novamente";
                }
                return RedirectToAction("index");
            }
            catch (System.Exception error)
            {
                TempData["MensagemErro"] = $"Que pena, não foi possivel cadastrar o motorista, tente novamente, ERRO: {error.Message}";
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public IActionResult CreateDriver(DriverViewModel driver)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _driverRepository.AddDriver(driver);
                    TempData["MensagemSucesso"] = "Motorista cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(driver);
            }
            catch (System.Exception error)
            {
                TempData["MensagemErro"] = $"Que pena, não foi possivel cadastrar o motorista, tente novamente, ERRO: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult UpdateDriver(DriverViewModel driver)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _driverRepository.UpdateDriver(driver);
                    TempData["MensagemSucesso"] = "Motorista atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("EditDriver",driver);
            }
            catch (System.Exception error)
            {
                TempData["MensagemErro"] = $"Que pena, não foi possivel atualizar o cadastro, tente novamente, ERRO: {error.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}
