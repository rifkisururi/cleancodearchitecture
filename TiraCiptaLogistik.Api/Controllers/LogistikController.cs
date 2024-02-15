using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiraCiptaLogistik.Core.DatabaseContexts;
using TiraCiptaLogistik.Domain.Entities;
using TiraCiptaLogistik.Service.Interface;
using TiraCiptaLogistik.ViewModel.Request;
using TiraCiptaLogistik.ViewModel.Respond;

namespace TiraCiptaLogistik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogistikController : ControllerBase
    {
        private readonly ILogger<LogistikController> _logger;
        private readonly ILogistikService _logistikSvc;

        public LogistikController(
            ILogger<LogistikController> logger
            ,LogistikContext dbContext
            , ILogistikService logistikSvc
        )
        {
            _logger = logger;
            _logistikSvc = logistikSvc;
        }

        [Route("GetAllCustomer")]
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            _logger.LogInformation("GetAllCustomer");
            return await _logistikSvc.GetAllCustomersAsync();
        }

        [Route("GetAllProduk")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProduk()
        {
            _logger.LogInformation("GetAllProduk");
            return await _logistikSvc.GetAllProductAsync();
        }

        [Route("GetAllPrice")]
        [HttpGet]
        public async Task<IEnumerable<Price>> GetAllPrice()
        {
            _logger.LogInformation("GetAllPrice");
            return await _logistikSvc.GetAllPriceAsync();
        }

        [Route("GetAllProdukPrice")]
        [HttpGet]
        public async Task<IEnumerable<ProdukPriceDTO>> GetAllProdukPrice()
        {
            _logger.LogInformation("GetAllProdukPrice");
            return await _logistikSvc.GetAllProdukPriceAsync();
        }

        [Route("SaveOrder")]
        [HttpPost]
        public async Task<SalesOrderDTO> SaveOrder(RequestInputOrderDTO data)
        {
            _logger.LogInformation("Start SaveOrder");
            var output = await _logistikSvc.SaveOrderAsync(data);
            _logger.LogInformation("End SaveOrder");
            return output;
        }
    }
}
