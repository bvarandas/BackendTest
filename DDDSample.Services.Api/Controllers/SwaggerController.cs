using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DDDSample.Services.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DDDSample.Domain.Core.Notifications;
using DDDSample.Application.Interfaces;
using MediatR;

namespace DDDSample.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwaggerController : BaseController
    {
        private string urlSwagger = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/";

        public SwaggerController(INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("marcas")]
        public IActionResult GetMarcas(int id)
        {
            IEnumerable<MarcaViewModel> marcas = null;

            using (var client = new HttpClient())
            {
                string marca = "Make";
                client.BaseAddress = new Uri($"{urlSwagger}{marca}");

                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<MarcaViewModel>>();
                    readTask.Wait();

                    marcas = readTask.Result;
                }
                else
                {
                    marcas = Enumerable.Empty<MarcaViewModel>();
                }

            }

            return Response(marcas);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("modelo/{id:int}")]
        public IActionResult GetModelo(int id)
        {
            IEnumerable<ModeloViewModel> members = null;

            using (var client = new HttpClient())
            {
                string api = "MakeID=" + id;
                client.BaseAddress = new Uri($"{urlSwagger}{api}");

                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ModeloViewModel>>();
                    readTask.Wait();

                    members = readTask.Result;
                }
                else
                {
                    members = Enumerable.Empty<ModeloViewModel>();
                }

            }

            return Response(members);
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("veiculo/{id:int}")]
        public IActionResult GetVeiculos(int id)
        {
            IEnumerable<VeiculoViewModel> members = null;

            using (var client = new HttpClient())
            {
                string api = "Vehicles?Page=" + id;
                client.BaseAddress = new Uri($"{urlSwagger}{api}");

                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<VeiculoViewModel>>();
                    readTask.Wait();

                    members = readTask.Result;
                }
                else
                {
                    members = Enumerable.Empty<VeiculoViewModel>();
                }

            }

            return Response(members);
        }

        
    }
}