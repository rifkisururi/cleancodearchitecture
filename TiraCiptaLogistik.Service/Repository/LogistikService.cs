using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TiraCiptaLogistik.Core.DatabaseContexts;
using TiraCiptaLogistik.Core.Interface;
using TiraCiptaLogistik.DataAccess.Interface;
using TiraCiptaLogistik.DataAccess.Repository;
using TiraCiptaLogistik.Domain.Entities;
using TiraCiptaLogistik.Service.Interface;
using TiraCiptaLogistik.ViewModel.General;
using TiraCiptaLogistik.ViewModel.Request;
using TiraCiptaLogistik.ViewModel.Respond;

namespace TiraCiptaLogistik.Service.Repository
{
    public class LogistikService : ILogistikService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly ISalesOrderRepository _salesOrderRepository;
        private readonly ISalesOrderDetailRepository _salesOrderDetailRepository;
        private readonly ISalesOrderInterfaceRepository _salesOrderInterfaceRepository;
        private readonly ILogger<LogistikService> _logger;
        private readonly LogistikContext _contex;

        public LogistikService(
            IMapper mapper,
            ICustomerRepository customerRepository, 
            IProductRepository productRepository, 
            IPriceRepository priceRepository, 
            ISalesOrderRepository salesOrderRepository,
            ISalesOrderDetailRepository orderDetailRepository,
            ISalesOrderInterfaceRepository salesOrderInterfaceRepository,
            ILogger<LogistikService> logger,
            LogistikContext contex
            )
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _priceRepository = priceRepository;
            _salesOrderRepository = salesOrderRepository;
            _salesOrderDetailRepository = orderDetailRepository;
            _salesOrderInterfaceRepository = salesOrderInterfaceRepository;
            _logger = logger;
            _contex = contex;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }
        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Price>> GetAllPriceAsync()
        {
            return await _priceRepository.GetAllAsync();
        }

        public async Task<IEnumerable<ProdukPriceDTO>> GetAllProdukPriceAsync()
        {
            var data = _contex.Product
                .SelectMany(c => _contex.Price.Where(a => a.ProductCode.Equals(c.ProductCode) && DateTime.Now.Date >= a.PriceValidateFrom && DateTime.Now.Date <= a.PriceValidateTo), (m, g) => new { Main = m, Price = g })
                .Select(sel => new ProdukPriceDTO
                {
                    ProductCode = sel.Main.ProductCode,
                    ProductName = sel.Main.ProductName,
                    PriceValue = sel.Price.PriceValue,
                });
            return data;
        }

        public async Task<SalesOrderDTO> SaveOrderAsync(RequestInputOrderDTO data)
        {
            SalesOrderDTO dataOutput = new();
            try {
                SalesOrder so = _mapper.Map<SalesOrder>(data);
                List<SalesOrderDetail> listSod = _mapper.Map<List<SalesOrderDetail>>(data.OrderDetail);

                // Save to Sales Order
                await _salesOrderRepository.AddAsync(so);
                _logger.LogInformation($"Add SalesOrder sukses");

                var savedData = await _salesOrderRepository.FindAsync(a => a.Id == so.Id);
                var savedDataSinggle = savedData.FirstOrDefault();
                savedDataSinggle.SalesOrderNo = "SO" + savedDataSinggle.Id.ToString("D4");
                so.SalesOrderNo = savedDataSinggle.SalesOrderNo;
                foreach (var item in listSod)
                {
                    item.SalesOrderNo = so.SalesOrderNo;
                }

                // Save to Sales Order Detail
                await _salesOrderDetailRepository.AddDataRangeAsync(listSod);
                _logger.LogInformation($"Add salesOrderDetail sukses");

                // Update Sales Order
                await _salesOrderRepository.UpdateDataAsync(savedDataSinggle);

                // Save to SalesOrderInterface
                SalesOrderInterface Soi = new();
                Soi.SalesOrderNo = savedDataSinggle.SalesOrderNo;

                PayloadDTO payload = new();
                payload.OrderDetail = _mapper.Map<List<ProdukRingkasDTO>>(data.OrderDetail);
                payload.SalesOrderNo = savedDataSinggle.SalesOrderNo;
                payload.CustId = so.CustCode;

                Soi.Payload = JsonSerializer.Serialize(payload);
                await _salesOrderInterfaceRepository.AddDataAsync(Soi);
                _logger.LogInformation($"Add _salesOrderInterface sukses");

                dataOutput = _mapper.Map<SalesOrderDTO>(savedDataSinggle); 

            }
            catch(Exception ex) {
                _logger.LogError($"{ex.Message}");
                _logger.LogError($"{ex.Source}");
                _logger.LogError($"{ex.InnerException}");
            }

            return dataOutput;

        }

    }
}
