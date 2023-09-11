using PartyCli.Domain.Entity;
using PartyCli.Domain.Infrastructure;

namespace PartyCli.Infrastucture.LiteDB;

public class LiteDBRepositoryVirtual : IStorage
{
    public readonly List<ServerDetails> _localServers;
    public LiteDBRepositoryVirtual()
    {
        _localServers = new()
        {
            new ServerDetails(Name: "Server from LiteDb 1", Status: "25", Load: "online"),
            new ServerDetails(Name: "Server from LiteDb 2", Status: "25", Load: "online"),
            new ServerDetails(Name: "Server from LiteDb 3", Status: "25", Load: "online")
        };
    }
    public Task<IEnumerable<ServerDetails>> GetServers() => Task.FromResult(_localServers.AsEnumerable());

    public Task SaveServers(IEnumerable<ServerDetails> list) => Task.CompletedTask;
}

