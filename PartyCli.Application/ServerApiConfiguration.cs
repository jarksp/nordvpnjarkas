using PartyCli.Domain.Infrastructure;

namespace PartyCli.Application;

public class ServerApiConfiguration : IServerApiConfiguration
{
    public string AllServersApiUrl => "https://api.nordvpn.com/v1/servers";

    public string ServersByCountryApiUrl => "https://api.nordvpn.com/v1/servers?filters[servers_technologies][id]=35&filters[country_id]=";

    public string ServersByProtocolApiUrl => "https://api.nordvpn.com/v1/servers?filters[servers_technologies][id]=";
}

