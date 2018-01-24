using System.Diagnostics.CodeAnalysis;
using PairingTest.Web.Models;
using PairingTest.Web.Services.Models;

namespace PairingTest.Web.Services
{
    [ExcludeFromCodeCoverage]
    public class MapperConfig
    {
        public static void Setup()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<QuestionnaireModel, QuestionnaireViewModel>()
                    .ForMember(x => x.QuestionnaireTitle, opts => opts.MapFrom(s => s.Title));
            });
        }
    }
}