
namespace CountMyWords.Domain.Common
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
