using MediatR;
using PartyCli.Api.Requests;
using PartyCli.Domain.Commands;

namespace PartyCli.Application.Commands.ServerCommands;

public class GetAllServersCommand : IExecutableCommand, IParseableCommand
{
    private readonly IMediator _mediator;

    public GetAllServersCommand(IMediator mediator) => _mediator = mediator;

    public async Task<IEnumerable<Server>> Execute() => await _mediator.Send(new GetAllServers());

    public IExecutableCommand? Parse(string command)
    {
        if (string.IsNullOrEmpty(command))
        {
            return null;
        }

        if (command.ToLower().Trim().Equals("server_list"))
        {
            return this;
        }

        return null;
    }
}

