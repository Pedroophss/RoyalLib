namespace RoyalLib.Domain.Abstractions;

using RoyalLib.Domain.Entities;
using RoyalLib.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBookRepository
{
    Task<PageOutput<BookEntity>> QueryByAuthorAysnc(string author, PageArgs pageArgs, CancellationToken token);

    Task<PageOutput<BookEntity>> QueryByISBNAysnc(string isbn, PageArgs pageArgs, CancellationToken token);

    Task<PageOutput<BookEntity>> QueryByTitleAysnc(string title, PageArgs pageArgs, CancellationToken token);
}