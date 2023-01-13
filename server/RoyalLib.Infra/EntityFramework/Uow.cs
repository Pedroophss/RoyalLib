namespace RoyalLib.Infra.EntityFramework;

using Microsoft.EntityFrameworkCore;
using RoyalLib.Domain.Abstractions;
using RoyalLib.Infra.EntityFramework.Repositories;

#nullable disable
internal class Uow : IUow
{
    RoyalLibContext Ctx { get; }

    public Uow(RoyalLibContext ctx)
    {
        Ctx = ctx;
    }

    private IBookRepository _bookRepository;
    public IBookRepository BookRepository
    {
        get 
        {
            _bookRepository ??= new BookRepository(Ctx);
            return _bookRepository;
        }
    }


    public async Task CommitAsync(CancellationToken token) =>
        await Ctx.SaveChangesAsync(token);

    public Task RollbackAsync(CancellationToken _)
    {
        foreach (var entry in Ctx.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                case EntityState.Deleted:
                    entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
            }
        }

        return Task.CompletedTask;
    }
}
