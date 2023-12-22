namespace Domain.Contract.Repositories
{
    public interface  IUnitOfWork
    {
        void SaveChanges();
    }
}
