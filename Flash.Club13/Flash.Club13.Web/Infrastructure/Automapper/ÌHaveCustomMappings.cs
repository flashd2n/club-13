using AutoMapper;

namespace Flash.Club13.Web.Infrastructure.Automapper
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
