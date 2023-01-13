namespace RoyalLib.Domain.Abstractions;

using System.Threading.Tasks;

public interface IUow
{
    IBookRepository BookRepository { get; }

    Task CommitAsync(CancellationToken token);
    Task RollbackAsync(CancellationToken token);
}
