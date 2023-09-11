
namespace PartyCli.Domain.Infrastructure;

public interface IServerApiConfiguration
{
    string AllServersApiUrl { get; }
    string ServersByCountryApiUrl { get; }
    string ServersByProtocolApiUrl { get; }
}