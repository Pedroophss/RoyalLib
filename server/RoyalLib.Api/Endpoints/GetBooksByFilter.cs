namespace RoyalLib.Api.Endpoints;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using RoyalLib.Api.Abstractions;
using RoyalLib.Api.Models;
using RoyalLib.Api.ValueObjects;
using RoyalLib.Domain.Abstractions;
using RoyalLib.Domain.Entities;
using RoyalLib.Domain.Models;
using RoyalLib.Domain.ValueObjects;

public class GetBooksByFilter : IEndpoint
{
    public static string GetBooksByFilterRoute = "/books/by/{searchBy}/{value}";

    public void MapSelf(WebApplication app)
    {
        app.MapGet(GetBooksByFilterRoute, Handler)
           .WithName("Get Books By Filter")
           .Produces<PageOutput<BookModel>>(200)
           .Produces<string>(400)
           .Produces<Exception>(500);
    }

    public static async Task<IResult> Handler(
        string? searchBy, string? value, uint pageSize, uint pageNumber, 
        [FromServices] IUow uow, CancellationToken token)
    {
        var sanitizedSearchBy = (SearchBy)searchBy;
        if (!sanitizedSearchBy.IsValid() || string.IsNullOrEmpty(value))
            return Results.BadRequest();

        var output = await GetBooks(uow, sanitizedSearchBy, value, new PageArgs(pageSize, pageNumber), token);

        return Results.Ok(output);
    }

    private async static Task<PageOutput<BookModel>> GetBooks
        (IUow uow, SearchBy searchBy, string value, PageArgs pageArgs, CancellationToken token)
    {
        PageOutput<BookEntity>? output = null;

        if (searchBy.IsAuthor)
            output = await uow.BookRepository.QueryByAuthorAysnc(value, pageArgs, token);

        if (searchBy.IsIsbn)
        {
            var sanitizedIsbn = (Isbn)value;
            if (!sanitizedIsbn.IsValid())
                return PageOutput<BookModel>.Empty();

            output = await uow.BookRepository.QueryByISBNAysnc(value, pageArgs, token);
        }

        if (searchBy.IsTitle)
            output = await uow.BookRepository.QueryByTitleAysnc(value, pageArgs, token);

        if (output is not null)
            return new PageOutput<BookModel>(output.Items.Select(s => (BookModel)s).ToArray(), output.Total);

        return PageOutput<BookModel>.Empty();
    }
}
