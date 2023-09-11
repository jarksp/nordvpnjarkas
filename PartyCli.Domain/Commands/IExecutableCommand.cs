using PartyCli.Api.Requests;

namespace PartyCli.Domain.Commands;

public interface IExecutableCommand
{
    Task<IEnumerable<Server>> Execute();
}
