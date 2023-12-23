namespace Domain.Contract.Repositories
{
    public interface  IUnitOfWork
    {
        Task SaveChanges();
    }
}
