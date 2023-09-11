using AutoMapper;
using PartyCli.Api.Requests;
using PartyCli.Domain.Entity;

namespace PartyCli.Application;

public class Mapper
{
    public static IMapper Configure()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ServerDetails, Server>();
            cfg.CreateMap<Server, ServerDetails>();
        });

        return config.CreateMapper();
    }
}

