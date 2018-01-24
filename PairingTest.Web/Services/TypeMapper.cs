using System.Diagnostics.CodeAnalysis;
using PairingTest.Web.Services.Contracts;

namespace PairingTest.Web.Services
{
    [ExcludeFromCodeCoverage]
    public class TypeMapper : ITypeMapper
    {
        public TTarget Convert<TSource, TTarget>(TSource source)
        {
            return AutoMapper.Mapper.Map<TSource, TTarget>(source);
        }
    }
}