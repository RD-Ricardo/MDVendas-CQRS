namespace MDVendas.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}