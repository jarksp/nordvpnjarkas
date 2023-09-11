using MediatR;

namespace PartyCli.Api.Requests;

public record GetAllServers() : IRequest<IEnumerable<Server>>;

public record GetServersByCountry(CountryId CountryId) : IRequest<IEnumerable<Server>>;

public record GetServersByProtocol(ProtocolId ProtocolId) : IRequest<IEnumerable<Server>>;

public record GetAllServersLocal() : IRequest<IEnumerable<Server>>;

public record Server(string Name, string Load, string Status);

public enum CountryId
{
    Unknown = -1,
    france = 74,
    Albania = 2,
    Argentina = 10
}

public enum ProtocolId
{
    Unknown = -1,
    UDP = 3,
    Tcp = 5,
    Nordlynx = 35
}
