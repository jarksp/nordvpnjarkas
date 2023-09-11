using MediatR;
using PartyCli.Api.Requests;
using PartyCli.Domain.Commands;
using System.Text.RegularExpressions;

namespace PartyCli.Application.Commands.ServerCommands;

public class GetServersByProtocolCommand : IExecutableCommand, IParseableCommand
{
    private readonly IMediator _mediator;
    private ProtocolId _protocolId = ProtocolId.Unknown;

    public GetServersByProtocolCommand(IMediator mediator) => _mediator = mediator;

    public async Task<IEnumerable<Server>> Execute() => await _mediator.Send(new GetServersByProtocol(_protocolId));

    public IExecutableCommand? Parse(string command)
    {
        var commandPattern = $"server_list --({string.Join("|", Enum.GetNames(typeof(ProtocolId)))})".ToLower().Trim();
        var regex = new Regex(commandPattern);
        if (regex.IsMatch(command.ToLower().Trim()))
        {
            _protocolId = ParseProtocolId(regex.Match(command.ToLower().Trim()).Groups[1].Value);
            return this;
        }

        return null;
    }

    private static ProtocolId ParseProtocolId(string protocolId)
    {
        if (Enum.TryParse(protocolId, true, out ProtocolId enumValue))
        {
            return enumValue;
        }

        return ProtocolId.Unknown;
    }
}

