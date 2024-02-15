using TiraCiptaLogistik.Domain.Entities;
using TiraCiptaLogistik.ViewModel.Respond;
using TiraCiptaLogistik.Web.Interface;

namespace TiraCiptaLogistik.Web.Service
{
    public class GetDataService : IGetDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl;
        public IConfiguration Configuration { get; }
        private readonly ILogger<GetDataService> _logger;

        public GetDataService(HttpClient httpClient, IConfiguration configuration, ILogger<GetDataService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            Configuration = configuration;
            baseUrl = Configuration.GetSection("ApiSettings:BaseUrl").Value;
            _logger = logger;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            List<Customer> data = new();

            try
            {
                string fullUrl = baseUrl + "Logistik/GetAllCustomer";
                var response = await _httpClient.GetAsync(fullUrl);

                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadFromJsonAsync<List<Customer>>();
                    _logger.LogInformation($"Get data {fullUrl} sukses");
                }
                else
                {
                    // Handle unsuccessful response
                    // For example: Log the response status code
                    Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                    _logger.LogError($"Failed to fetch data. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                _logger.LogError($"An error occurred: {ex.Message}");
            }

            return data;
        }

        public async Task<List<ProdukPriceDTO>> GetAllProductPriceAsync()
        {
            List<ProdukPriceDTO> data = new();

            try
            {
                string fullUrl = baseUrl + "Logistik/GetAllProdukPrice";
                var response = await _httpClient.GetAsync(fullUrl);

                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadFromJsonAsync<List<ProdukPriceDTO>>();
                    _logger.LogInformation($"Get data {fullUrl} sukses");
                }
                else
                {
                    // Handle unsuccessful response
                    // For example: Log the response status code
                    Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                    _logger.LogError($"Failed to fetch data. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                _logger.LogError($"An error occurred: {ex.Message}");
            }

            return data;
        }

    }
}
