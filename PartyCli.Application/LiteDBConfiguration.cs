using PartyCli.Domain.Infrastructure;

namespace PartyCli.Application;

public class LiteDBConfiguration : ILiteDBConfiguration
{
    public string DbFilePath => "C:\\Tmp\\PartyCliLocalDb.db";
}

