using PartyCli.Domain.Infrastructure;

namespace PartyCli.Application;

public class LogConfiguration : ILogConfiguration
{
    public string LogFilePath => "C:\\Tmp\\PartyCli.log";
}

