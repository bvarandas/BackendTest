using System;
using DDDSample.Application.Interfaces;
using DDDSample.Application.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using DDDSample.Domain.Core.Notifications;
using DDDSample.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDDSample.Web.Controllers
{
    [Route("Cliente")]
    public class ClienteController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("")]
        [Route("/")]
        [Route("adv-management/list-all")]
        public IActionResult Index()
        {
            return View(_clienteAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("adv-management/adv-details/{id:Guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _clienteAppService.GetById(id.Value);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        [Route("adv-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("adv-management/register-new")]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(ClienteViewModel advViewModel)
        {
            if (!ModelState.IsValid) return View(advViewModel);
            _clienteAppService.Register(advViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Cliente Registrado com sucesso!";

            return View(advViewModel);
        }

        //[HttpGet]
        //[Route("adv-management/register-new-vehicle", Name ="cria_anuncio")]
        //public IActionResult Create(VeiculoViewModel veiculoModel )
        //{
        //    var model = new ClienteViewModel();
        //    model.Ano = Convert.ToInt32( veiculoModel.YearFab);
        //    model.Marca = veiculoModel.Make;
        //    model.Modelo = veiculoModel.Model;
        //    model.Quilometragem = Convert.ToInt32(veiculoModel.KM);
        //    model.Versao = veiculoModel.Version;
            
        //    return View(model);
        //}

        [HttpGet]
        [Route("adv-management/edit-adv/{id:Guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advViewModel = _clienteAppService.GetById(id.Value);

            if (advViewModel == null)
            {
                return NotFound();
            }

            return View(advViewModel);
        }

        [HttpPost]
        [Route("adv-management/edit-adv/{id:Guid}")]
        public IActionResult Edit(ClienteViewModel advViewModel)
        {
            if (!ModelState.IsValid) return View(advViewModel);

            _clienteAppService.Update(advViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Cliente Atualizado!";

            return View(advViewModel);
        }

        [HttpGet]
        [Route("adv-management/remove-adv/{id:Guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advViewModel = _clienteAppService.GetById(id.Value);

            if (advViewModel == null)
            {
                return NotFound();
            }

            return View(advViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Route("adv-management/remove-adv/{id:Guid}")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remove(id);

            if (!IsValidOperation()) return View(_clienteAppService.GetById(id));

            ViewBag.Sucesso = "Cliente removido!";
            return RedirectToAction("Index");
        }

        

        [AllowAnonymous]
        [Route("adv-management/cliente-history/{id:Guid" +
            "" +
            "}")]
        public JsonResult History(Guid id)
        {
            var advHistoryData = _clienteAppService.GetAllHistory(id);
            return Json(advHistoryData);
        }
    }
}
