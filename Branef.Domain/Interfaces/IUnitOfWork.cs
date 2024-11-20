namespace Branef.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
