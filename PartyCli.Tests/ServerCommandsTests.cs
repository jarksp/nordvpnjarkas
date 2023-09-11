using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PartyCli.Application;
using PartyCli.Application.Commands.ServerCommands;
using PartyCli.Domain.Commands.CommandsFactory;
using PartyCli.Domain.Infrastructure;
using PartyCli.Infrastucture.LiteDB;
using PartyCli.Infrastucture.ServerApi;
using System.Reflection;
using Xunit;

namespace PartyCli.Tests;

public class ServerCommandsTests
{ 
    private readonly ICommandsFactory _commandsFactory;

    private const string GET_ALL_SERVERS_COMMAND = "server_list";
    private const string GET_ALL_LOCAL_SERVERS_COMMAND = "server_list --local";
    private const string GET_SERVERS_BY_COUNTRY_COMMAND = "server_list --france";
    private const string GET_SERVERS_BY_PROTOCOL_COMMAND = "server_list --TCP";

    public ServerCommandsTests()
    {
        ApplicationServices.Services.AddSingleton<IStorage, LiteDBRepositoryVirtual>();
        ApplicationServices.Services.AddSingleton<IServerApiClient, ServerApiVirtualClient>();

        _commandsFactory = ApplicationServices.ServicesProvider.GetRequiredService<ICommandsFactory>();
    }

    [Fact]
    public void GetCommand_GetAllServersCommand_ReturnsValidCommand()
    {
        // Arrange & Act
        var expected = _commandsFactory.GetCommand(GET_ALL_SERVERS_COMMAND);

        // Assert
        expected.GetType().Should().Be(typeof(GetAllServersCommand));
    }

    [Fact]
    public void GetCommand_GetAllLocalServersCommand_ReturnsValidCommand()
    {
        // Arrange & Act
        var expected = _commandsFactory.GetCommand(GET_ALL_LOCAL_SERVERS_COMMAND);

        // Assert
        expected.GetType().Should().Be(typeof(GetLocalServersCommand));
    }

    [Fact]
    public void GetCommand_GetServersByCountryCommand_ReturnsValidCommand()
    {
        // Arrange & Act
        var expected = _commandsFactory.GetCommand(GET_SERVERS_BY_COUNTRY_COMMAND);

        // Assert
        expected.GetType().Should().Be(typeof(GetServersByCountryCommand));
    }

    [Fact]
    public void GetCommand_GetServersByProtocolCommand_ReturnsValidCommand()
    {
        // Arrange & Act
        var expected = _commandsFactory.GetCommand(GET_SERVERS_BY_PROTOCOL_COMMAND);

        // Assert
        expected.GetType().Should().Be(typeof(GetServersByProtocolCommand));
    }

    [Fact]
    public async void GetCommand_GetAllServersCommand_ReturnsValidCommandResponse()
    {
        // Arrange
        var command = _commandsFactory.GetCommand(GET_ALL_SERVERS_COMMAND);

        // Act
        var expected = await command.Execute();

        // Assert
        expected.Count().Should().Be(7);
    }

    [Fact]
    public async void GetCommand_GetAllLocalServersCommand_ReturnsValidCommandResponse()
    {
        // Arrange
        var command = _commandsFactory.GetCommand(GET_ALL_LOCAL_SERVERS_COMMAND);

        // Act
        var expected = await command.Execute();

        // Assert
        expected.Count().Should().Be(3);
    }

    [Fact]
    public async void GetCommand_GetServersByCountryCommand_ReturnsValidCommandResponse()
    {
        // Arrange
        var command = _commandsFactory.GetCommand(GET_SERVERS_BY_COUNTRY_COMMAND);

        // Act
        var expected = await command.Execute();

        // Assert
        expected.Count().Should().Be(3);
    }

    [Fact]
    public async void GetCommand_GetServersByProtocolCommand_ReturnsValidCommandResponse()
    {
        // Arrange
        var command = _commandsFactory.GetCommand(GET_SERVERS_BY_PROTOCOL_COMMAND);

        // Act
        var expected = await command.Execute();

        // Assert
        expected.Count().Should().Be(2);
    }
}
