using System;
using System.Collections.Generic;
using System.Linq;
using DDDSample.Application.Interfaces;
using DDDSample.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using DDDSample.Application.ViewModels;

namespace DDDSample.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Route("adv-management/list-all")]
        public IActionResult GetAll()
        {
            return Response(_clienteAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("adv-management/adv-detail/{Id:int}")]
        public IActionResult Details(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var clienteViewModel = _clienteAppService.GetById(Id.Value);

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return Response(clienteViewModel);
        }

        /// <summary>
        /// Insere um Cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("adv-management/")]
        public IActionResult Create(ClienteViewModel model)
        {
            if (!ModelState.IsValid) return Response(model);
            _clienteAppService.Register(model);

            /*
            if (IsValidOperation())
                ViewBag.Sucesso = "Anúncio Registrado!";*/

            return Response(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("adv-management/{id:int}")]
        public IActionResult Edit(ClienteViewModel model)
        {
            if (!ModelState.IsValid) return Response(model);

            _clienteAppService.Update(model);
            /*
            if (IsValidOperation())
                ViewBag.Sucesso = "Anúncio atualizado!";*/

            return Response(model);
        }

        [HttpDelete]
        [Route("adv-management/{id:int}")]
        public IActionResult Delete(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var model = _clienteAppService.GetById(Id.Value);

            if (model == null)
            {
                return NotFound();
            }

            return Response(model);
        }

    }
}