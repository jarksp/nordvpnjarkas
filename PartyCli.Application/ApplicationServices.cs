using Microsoft.Extensions.DependencyInjection;
using PartyCli.Application.Commands.ServerCommands;
using PartyCli.Domain.Commands.CommandsFactory;
using PartyCli.Domain.Infrastructure;
using PartyCli.Infrastucture.LiteDB;
using PartyCli.Infrastucture.Logging;
using PartyCli.Infrastucture.ServerApi;
using System.Reflection;

namespace PartyCli.Application;

public static class ApplicationServices
{
    private static readonly ILiteDBConfiguration _liteDBConfiguration = new LiteDBConfiguration();
    private static readonly ILogConfiguration _logConfiguration = new LogConfiguration();
    private static readonly IServerApiConfiguration _serverApiConfiguration = new ServerApiConfiguration();


    public static readonly IServiceCollection services = new ServiceCollection()
            .AddSingleton(_liteDBConfiguration)
            .AddSingleton(_logConfiguration)
            .AddSingleton(_serverApiConfiguration)
            .AddSingleton<IStorage, LiteDBRepository>()
            .AddSingleton<IServerApiClient, ServerApiClient>()
            .AddSingleton(Mapper.Configure())
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddLogging(builder => FileLogger.BuildLogger(_logConfiguration.LogFilePath, builder))
            .AddScoped<GetAllServersCommand>()
            .AddScoped<GetServersByCountryCommand>()
            .AddScoped<GetServersByProtocolCommand>() 
            .AddScoped<GetLocalServersCommand>()
            .AddSingleton<ICommandsFactory, CommandsFactory>();

    public static IServiceCollection Services => services;
    public static IServiceProvider ServicesProvider => Services.BuildServiceProvider();
}

