using MediatR;
using PartyCli.Api.Requests;
using PartyCli.Domain.Commands;

namespace PartyCli.Application.Commands.ServerCommands;

public class GetLocalServersCommand : IExecutableCommand, IParseableCommand
{
    private readonly IMediator _mediator;

    public GetLocalServersCommand(IMediator mediator) => _mediator = mediator;

    public async Task<IEnumerable<Server>> Execute() => await _mediator.Send(new GetAllServersLocal());

    public IExecutableCommand? Parse(string command)
    {
        if (string.IsNullOrEmpty(command))
        {
            return null;
        }

        if (command.ToLower().Trim().Equals("server_list --local"))
        {
            return this;
        }

        return null;
    }
}

