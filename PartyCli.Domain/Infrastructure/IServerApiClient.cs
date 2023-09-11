using PartyCli.Api.Requests;

namespace PartyCli.Domain.Infrastructure;

public interface IServerApiClient
{
    Task<IEnumerable<Server>> GetAllServersListAsync();
    Task<IEnumerable<Server>> GetAllServerByCountryListAsync(int countryId);
    Task<IEnumerable<Server>> GetAllServerByProtocolListAsync(int vpnProtocol);
}
