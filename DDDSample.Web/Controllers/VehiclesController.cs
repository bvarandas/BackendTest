using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DDDSample.Domain.Core.Notifications;
using DDDSample.Web.ViewModels;
using MediatR;

namespace DDDSample.Web.Controllers
{
    [Route("Vehicle")]
    public class VehiclesController : BaseController
    {
        private string urlSwagger = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/";

        public VehiclesController(INotificationHandler<DomainNotification> notifications) : base(notifications)
        {

        }

        [HttpGet]
        [AllowAnonymous]
        //[Route("")]
        [Route("veiculo-list/1")]
        [Route("veiculo/{id:int}")]
        public IActionResult GetVeiculos(int id)
        {
            IEnumerable<VeiculoViewModel> members = null;

            using (var client = new HttpClient())
            {
                id = (id == 0) ? 1 : id;
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

            return View(members);
        }

        [HttpPost]
        [Route("veiculo-new/{id:int}")]
        public ActionResult CriaAnuncio(VeiculoViewModel pModel)
        {
            return RedirectToAction("Create", "Adv", new { veiculoModel = pModel });
        }
    }
}