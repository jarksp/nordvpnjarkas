
using PartyCli.Domain.Entity;

namespace PartyCli.Domain.Infrastructure;

public interface IStorage
{
    Task SaveServers(IEnumerable<ServerDetails> list);
    Task<IEnumerable<ServerDetails>> GetServers();
}