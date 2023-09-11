using AutoMapper;
using MediatR;
using PartyCli.Api.Requests;
using PartyCli.Domain.Entity;
using PartyCli.Domain.Infrastructure;

namespace PartyCli.Application.Handlers;

public class ServersHandler : IRequestHandler<GetAllServers, IEnumerable<Server>>,
    IRequestHandler<GetServersByCountry, IEnumerable<Server>>,
    IRequestHandler<GetServersByProtocol, IEnumerable<Server>>,
    IRequestHandler<GetAllServersLocal, IEnumerable<Server>>
{
    private readonly IServerApiClient _serverApiClient;
    private readonly IStorage _storage;
    private readonly IMapper _mapper;
       
    public ServersHandler(IServerApiClient serverApiClient, IStorage storage, IMapper mapper)
    {
        _serverApiClient = serverApiClient;
        _storage = storage;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Server>> Handle(GetAllServers request, CancellationToken cancellationToken)
    {
        var servers = await _serverApiClient.GetAllServersListAsync();
        await SaveServersAsync(servers).ConfigureAwait(false);

         return servers;
    }

    public async Task<IEnumerable<Server>> Handle(GetServersByCountry request, CancellationToken cancellationToken)
    {
        var servers = await _serverApiClient.GetAllServerByCountryListAsync((int)request.CountryId);
        await SaveServersAsync(servers).ConfigureAwait(false);

        return servers;
    }

    public async Task<IEnumerable<Server>> Handle(GetServersByProtocol request, CancellationToken cancellationToken)
    {
        var servers = await _serverApiClient.GetAllServerByProtocolListAsync((int)request.ProtocolId);
        await SaveServersAsync(servers).ConfigureAwait(false);

        return servers;
    }

    public async Task<IEnumerable<Server>> Handle(GetAllServersLocal request, CancellationToken cancellationToken)
    {
        var serversFromStorage = await _storage.GetServers();
        return _mapper.Map<IEnumerable<Server>>(serversFromStorage);
    }

    private async Task SaveServersAsync(IEnumerable<Server> servers)
    {
        var serversDetails = _mapper.Map<IEnumerable<ServerDetails>>(servers);
        await _storage.SaveServers(serversDetails);
    }
}

