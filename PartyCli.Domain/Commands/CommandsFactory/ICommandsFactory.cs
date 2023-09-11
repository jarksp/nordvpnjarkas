
namespace PartyCli.Domain.Commands.CommandsFactory;

public interface ICommandsFactory
{
    IExecutableCommand GetCommand(string commandText);
}
