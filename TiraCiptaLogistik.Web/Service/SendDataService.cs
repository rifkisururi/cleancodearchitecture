using Newtonsoft.Json;
using System.Text;
using TiraCiptaLogistik.Domain.Entities;
using TiraCiptaLogistik.ViewModel.Request;
using TiraCiptaLogistik.ViewModel.Respond;
using TiraCiptaLogistik.Web.Interface;

namespace TiraCiptaLogistik.Web.Service
{
    public class SendDataService : ISendDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl;
        public IConfiguration Configuration { get; }
        private readonly ILogger<SendDataService> _logger;

        public SendDataService(HttpClient httpClient, IConfiguration configuration, ILogger<SendDataService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            Configuration = configuration;
            baseUrl = Configuration.GetSection("ApiSettings:BaseUrl").Value;
            _logger = logger;
        }

        public async Task<SalesOrderDTO> SendDataAsync(RequestInputOrderDTO data)
        {
            SalesOrderDTO output = new();
            try
            {
                _logger.LogInformation($"start SendDataAsync");
                var jsonData = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                _logger.LogInformation($"json data {jsonData}");
                var response = await _httpClient.PostAsync($"{baseUrl}Logistik/SaveOrder", content);

                if (response.IsSuccessStatusCode)
                {
                    output = await response.Content.ReadFromJsonAsync<SalesOrderDTO>();
                    _logger.LogInformation($"sukses SendDataAsync");
                    return output;
                }
                else
                {

                    _logger.LogError($"fail SendDataAsync");
                    return output;
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Error sending data: {ex.Message}");
                _logger.LogError($"Error sending data: {ex.Message}");
                return output;
            }
        }
    }
}
