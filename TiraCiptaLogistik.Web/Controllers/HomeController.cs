using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TiraCiptaLogistik.ViewModel.Request;
using TiraCiptaLogistik.Web.Interface;
using TiraCiptaLogistik.Web.Models;

namespace TiraCiptaLogistik.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetDataService _getDataSvc;
        private readonly ISendDataService _sendDataSvc;

        public HomeController(ILogger<HomeController> logger, IGetDataService getDataSvc, ISendDataService sendDataSvc)
        {
            _logger = logger;
            _getDataSvc = getDataSvc;
            _sendDataSvc = sendDataSvc;
        }
        public async Task<IActionResult> Index()
        {
            var dtCustomer = _getDataSvc.GetAllCustomersAsync();
            var dtProdukPrice = _getDataSvc.GetAllProductPriceAsync();
            Task.WaitAll(dtCustomer, dtProdukPrice);
            ViewBag.dtCustomer = dtCustomer.Result;
            ViewBag.dtProdukPrice = dtProdukPrice.Result;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("save")]
        public async Task<IActionResult> save([FromForm] string postData) {
            try
            {
                RequestInputOrderDTO param = JsonConvert.DeserializeObject<RequestInputOrderDTO>(postData);

                var saveData = await _sendDataSvc.SendDataAsync(param);

                return Ok(saveData);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, new
                {
                    success = false,
                    message = e.Message
                });
            }
        }
    }
}
