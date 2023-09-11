using Microsoft.Extensions.DependencyInjection;
using PartyCli.Application.Commands.ServerCommands;
using PartyCli.Domain.Commands.CommandsFactory;
using PartyCli.Domain.Commands;

namespace PartyCli.Application;

public class CommandsFactory : ICommandsFactory
{
    public IExecutableCommand GetCommand(string commandText)
    {
        var parseableCommands = new[]
        {
            (IParseableCommand)ApplicationServices.ServicesProvider.GetRequiredService<GetAllServersCommand>(),
            ApplicationServices.ServicesProvider.GetRequiredService<GetServersByCountryCommand>(),
            ApplicationServices.ServicesProvider.GetRequiredService<GetServersByProtocolCommand>(),
            ApplicationServices.ServicesProvider.GetRequiredService<GetLocalServersCommand>()
        };

        foreach (var parseableCommand in parseableCommands)
        {
            var command = parseableCommand.Parse(commandText);
            if (command != null)
            {
                return command;
            }
        }

        throw new ArgumentException($"Command '{commandText ?? "NULL"}' not supported!");
    }
}
