using PartyCli.Api.Requests;
using PartyCli.Domain.Infrastructure;

namespace PartyCli.Infrastucture.ServerApi;

public class ServerApiVirtualClient : IServerApiClient
{
    private readonly List<Server> _serversAll;
    private readonly List<Server> _serversByCountry;
    private readonly List<Server> _serversByProtocol;

    public ServerApiVirtualClient()
    {
        _serversAll = new()
        {
            new Server(Name: "Test server all 1", Status: "25", Load: "online"),
            new Server(Name: "Test server all 2", Status: "1", Load: "online"),
            new Server(Name: "Test server all 3", Status: "5", Load: "online"),
            new Server(Name: "Test server all 4", Status: "8", Load: "online"),
            new Server(Name: "Test server all 5", Status: "50", Load: "online"),
            new Server(Name: "Test server all 6", Status: "78", Load: "online"),
            new Server(Name: "Test server all 7", Status: "3", Load: "online")
        };

        _serversByCountry = new()
        {
            new Server(Name: "Test server by country 1", Status: "25", Load: "online"),
            new Server(Name: "Test server by country 2", Status: "1", Load: "online"),
            new Server(Name: "Test server by country 3", Status: "5", Load: "online"),
        };

        _serversByProtocol = new()
        {
            new Server(Name: "Test server by protocol 1", Status: "25", Load: "online"),
            new Server(Name: "Test server by protocol 2", Status: "1", Load: "online"),
        };
    }

    public Task<IEnumerable<Server>> GetAllServerByCountryListAsync(int countryId) => Task.FromResult(_serversByCountry.AsEnumerable());

    public Task<IEnumerable<Server>> GetAllServerByProtocolListAsync(int vpnProtocol) => Task.FromResult(_serversByProtocol.AsEnumerable());

    public Task<IEnumerable<Server>> GetAllServersListAsync() => Task.FromResult(_serversAll.AsEnumerable());
}

