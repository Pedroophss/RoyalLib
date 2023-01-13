using FluentAssertions;
using RoyalLib.Api.Endpoints;
using RoyalLib.Api.Models;
using RoyalLib.Api.ValueObjects;
using RoyalLib.Domain.Entities;
using RoyalLib.Domain.Models;
using RoyalLib.Infra.EntityFramework.Mappings;
using RoyalLib.Integrations.Setup;
using RoyalLib.Units.Fixtures;
using System.Net;
using System.Net.Http.Json;

namespace RoyalLib.Integrations.Api;

[Collection("api")]
public class GetBooksByFilterCase
{
    public ApiFixture Api { get; }
    public Random Random { get; }

    public GetBooksByFilterCase(ApiFixture api)
    {
        Api = api;
        Random = new Random(DateTime.Now.Millisecond);
    }

    private string GetUrl(string searchBy, string value, uint pageSize = 0, uint pageNumber = 0)
    {
        var url = GetBooksByFilter.GetBooksByFilterRoute
                                  .Replace("{searchBy}", searchBy)
                                  .Replace("{value}", value);

        return $"{url}?pageSize={pageSize}&pageNumber={pageNumber}";
    }

    private BookEntity GetRandomBook() =>
        BookMap.InitialBooks[Random.Next(BookMap.InitialBooks.GetUpperBound(0))];

    private async Task<PageOutput<BookModel>?> DeserealizeBody(HttpResponseMessage response) =>
        await response.Content.ReadFromJsonAsync<PageOutput<BookModel>>();


    [Theory, AutoArrange]                            
    public async Task InvalidParams_ShouldReturnBadRequest(string invalidSearch, string value)
    {
        // Arrange
        var url = GetUrl(invalidSearch, value);

        // Act
        var response = await Api.ApiClient.GetAsync(url);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task ValidParams_GetByAuthor_ShouldReturnOk()
    {
        // Arrange
        var book = GetRandomBook();
        var author = $"{book.FirstName} {book.LastName}";
        var url = GetUrl(SearchBy.AUTHOR, author, 1000, 0);

        // Act
        var response = await Api.ApiClient.GetAsync(url);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        await AssertResponse(response, book => $"{book.FirstName} {book.LastName}" == author);
    }

    [Fact]
    public async Task ValidParams_GetByISBN_ShouldReturnOk()
    {
        // Arrange
        var book = GetRandomBook();
        var url = GetUrl(SearchBy.ISBN, book.Isbn, 1000, 0);

        // Act
        var response = await Api.ApiClient.GetAsync(url);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        await AssertResponse(response, w => w.Isbn == book.Isbn);
    }

    [Fact]
    public async Task ValidParams_GetByTitle_ShouldReturnOk()
    {
        // Arrange
        var book = GetRandomBook();
        var url = GetUrl(SearchBy.TITLE, book.Title, 1000, 0);

        // Act
        var response = await Api.ApiClient.GetAsync(url);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        await AssertResponse(response, w => w.Title == book.Title);
    }

    private async Task AssertResponse(HttpResponseMessage response, Func<BookEntity, bool> filter)
    {
        var body = await DeserealizeBody(response);
        if (body is not null)
        {
            var expected = BookMap.InitialBooks
                                  .Where(filter)
                                  .Select(s => (BookModel)s);

            body.Total.Should().Be(expected.Count());
            body.Items.Should().BeEquivalentTo(expected);
        }
    }
}
