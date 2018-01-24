namespace PairingTest.Web.Services.Contracts
{
    public interface ITypeMapper
    {
        TTarget Convert<TSource, TTarget>(TSource source);
    }
}