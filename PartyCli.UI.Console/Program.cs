using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PartyCli.Application;
using PartyCli.Domain.Commands.CommandsFactory; 

var serverCommandsFactory = ApplicationServices.ServicesProvider.GetRequiredService<ICommandsFactory>();
var logger = ApplicationServices.ServicesProvider.GetRequiredService<ILogger<Program>>();
var message = "Type command or 'q' to exist";

Console.WriteLine(message);
while(Console.ReadLine() is string commandText)
{
    try
    {
        var command = serverCommandsFactory.GetCommand(commandText);
        var servers = await command.Execute();
        Console.WriteLine($"Result founded {servers?.Count() ?? 0}");
        if (servers != null)
        {
            foreach (var server in servers)
            {
                Console.WriteLine($"{server.Name} | {server.Load} | {server.Status}");
            }
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.ToString());
        logger.LogError(ex.ToString());
    }

    Console.WriteLine(message);
}


Console.WriteLine("Press any key to exit...");
Console.ReadKey();