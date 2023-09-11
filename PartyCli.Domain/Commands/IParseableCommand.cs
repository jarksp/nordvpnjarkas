namespace PartyCli.Domain.Commands;

public interface IParseableCommand
{
    IExecutableCommand? Parse(string command);
}
