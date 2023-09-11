using LiteDB;
using PartyCli.Domain.Entity;
using PartyCli.Domain.Infrastructure;

namespace PartyCli.Infrastucture.LiteDB;

public class LiteDBRepository : IStorage
{
    private readonly LiteDatabase _db;

    public LiteDBRepository(ILiteDBConfiguration liteDBConfiguration)
    {
        var directory = Path.GetDirectoryName(liteDBConfiguration.DbFilePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory!);
        }

        _db = new LiteDatabase(new ConnectionString
        {
            Filename = liteDBConfiguration.DbFilePath,
            Upgrade = true,
            Connection = ConnectionType.Shared
        });
    }

    public async Task<IEnumerable<ServerDetails>> GetServers()
        => await Task.Run(() => _db.GetCollection<ServerDetails>().FindAll()).ConfigureAwait(false);

    public async Task SaveServers(IEnumerable<ServerDetails> list)
    {
        await Task.Run(() =>
        {
            var collection = _db.GetCollection<ServerDetails>();
            collection.Upsert(list);
        }).ConfigureAwait(false);
    }
}

