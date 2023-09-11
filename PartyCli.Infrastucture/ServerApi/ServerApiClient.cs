using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PartyCli.Api.Requests;
using PartyCli.Domain.Infrastructure;

namespace PartyCli.Infrastucture.ServerApi;

public class ServerApiClient : IServerApiClient
{
    private const string REQUEST_LOGGING_MESSAGE_PREFIX = "Request: ";
    private const string RESPONSE_LOGGING_MESSAGE_PREFIX = "Response: ";
    private readonly IServerApiConfiguration _configuration;
    private readonly HttpClient _client = new();
    private readonly ILogger _logger;
     
    public ServerApiClient(IServerApiConfiguration configuration, ILogger<IServerApiClient> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<IEnumerable<Server>> GetAllServersListAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, _configuration.AllServersApiUrl);
        _logger.LogInformation($"{REQUEST_LOGGING_MESSAGE_PREFIX}{request.RequestUri}");
        var response = await _client.SendAsync(request);
        var responseString = response.Content.ReadAsStringAsync().Result;
        _logger.LogInformation($"{RESPONSE_LOGGING_MESSAGE_PREFIX}{responseString}");
        return JsonConvert.DeserializeObject<List<Server>>(responseString) ?? new();
    }

    public async Task<IEnumerable<Server>> GetAllServerByCountryListAsync(int countryId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, _configuration.ServersByCountryApiUrl + countryId);
        _logger.LogInformation($"{REQUEST_LOGGING_MESSAGE_PREFIX}{request.RequestUri}");
        var response = await _client.SendAsync(request);
        var responseString = response.Content.ReadAsStringAsync().Result;
        _logger.LogInformation($"{RESPONSE_LOGGING_MESSAGE_PREFIX}{responseString}");
        return JsonConvert.DeserializeObject<List<Server>>(responseString) ?? new();
    }

    public async Task<IEnumerable<Server>> GetAllServerByProtocolListAsync(int vpnProtocol)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, _configuration.ServersByProtocolApiUrl + vpnProtocol);
        _logger.LogInformation($"{REQUEST_LOGGING_MESSAGE_PREFIX}{request.RequestUri}");
        var response = await _client.SendAsync(request);
        var responseString = response.Content.ReadAsStringAsync().Result;
        _logger.LogInformation($"{RESPONSE_LOGGING_MESSAGE_PREFIX}{responseString}");
        return JsonConvert.DeserializeObject<List<Server>>(responseString) ?? new();
    }
}
