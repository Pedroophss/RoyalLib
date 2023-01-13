namespace RoyalLib.Infra.EntityFramework.Repositories;

using Microsoft.EntityFrameworkCore;
using RoyalLib.Domain.Abstractions;
using RoyalLib.Domain.Entities;
using RoyalLib.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

internal class BookRepository : IBookRepository
{
    private static PageOutput<BookEntity> EmptyResult = PageOutput<BookEntity>.Empty();

    RoyalLibContext Ctx { get; }

    public BookRepository(RoyalLibContext ctx)
    {
        Ctx = ctx;
    }

    public async Task<PageOutput<BookEntity>> QueryByAuthorAysnc(string author, PageArgs pageArgs, CancellationToken token)
    {
        if (string.IsNullOrEmpty(author))
            return EmptyResult;

        author = author.ToLower();

        var query = Ctx.Books.Where(w => w.FirstName.ToLower() == author
                                      || w.LastName.ToLower() == author
                                      || w.FirstName.ToLower() + " " + w.LastName.ToLower() == author);

        return await CreatePageResult(query, pageArgs, token);
    }
        

    public async Task<PageOutput<BookEntity>> QueryByISBNAysnc(string isbn, PageArgs pageArgs, CancellationToken token)
    {
        if (string.IsNullOrEmpty(isbn))
            return EmptyResult;

        var query = Ctx.Books.Where(w => w.Isbn == isbn);

        return await CreatePageResult(query, pageArgs, token);
    }

    public async Task<PageOutput<BookEntity>> QueryByTitleAysnc(string title, PageArgs pageArgs, CancellationToken token)
    {
        if (string.IsNullOrEmpty(title))
            return EmptyResult;

        title = title.ToLower();

        var query = Ctx.Books.Where(w => w.Title.ToLower() == title);

        return await CreatePageResult(query, pageArgs, token);
    }

    private async static Task<PageOutput<BookEntity>> CreatePageResult
        (IQueryable<BookEntity> query, PageArgs page, CancellationToken token)
    {
        var count = await query.CountAsync(token);
        var items = await query.Skip((int)(page.Number * page.Size))
                               .Take((int)page.Size)
                               .AsNoTracking()
                               .ToArrayAsync(token);

        return new PageOutput<BookEntity>(items, count);
    }
}
