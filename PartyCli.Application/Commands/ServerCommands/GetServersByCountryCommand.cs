using MediatR;
using PartyCli.Api.Requests;
using PartyCli.Domain.Commands;
using System.Text.RegularExpressions;

namespace PartyCli.Application.Commands.ServerCommands;

public class GetServersByCountryCommand : IExecutableCommand, IParseableCommand
{
    private readonly IMediator _mediator;
    private CountryId _countryId = CountryId.Unknown;

    public GetServersByCountryCommand(IMediator mediator) => _mediator = mediator;

    public async Task<IEnumerable<Server>> Execute() => await _mediator.Send(new GetServersByCountry(_countryId));

    public IExecutableCommand? Parse(string command)
    {
        var commandPattern = $"server_list --({string.Join("|", Enum.GetNames(typeof(CountryId)))})".ToLower().Trim();
        var regex = new Regex(commandPattern);
        if (regex.IsMatch(command.ToLower().Trim()))
        {
            _countryId = ParseCountryId(regex.Match(command.ToLower().Trim()).Groups[1].Value);
            return this;
        }

        return null;
    }

    private static CountryId ParseCountryId(string countryId)
    {
        if (Enum.TryParse(countryId, true, out CountryId enumValue))
        {
            return enumValue;
        }

        return CountryId.Unknown;
    }
}

