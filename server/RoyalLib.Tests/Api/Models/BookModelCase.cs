using FluentAssertions;
using RoyalLib.Api.Models;
using RoyalLib.Domain.Entities;

namespace RoyalLib.Units.Api.Models;

public class BookModelCase
{
    [Theory, AutoArrange]
    public void BookModel_ConvertingBookEntity_ShouldBeOk(BookEntity entity)
    {
        // Act
        var bookModel = (BookModel)entity;

        // Assert
        bookModel.Author.Should().Be($"{entity.FirstName} {entity.LastName}");
        bookModel.Category.Should().Be(entity.Category);
        bookModel.Type.Should().Be(entity.Type);
        bookModel.Id.Should().Be(entity.Id);
        bookModel.Isbn.Should().Be(entity.Isbn);
        bookModel.Title.Should().Be(entity.Title);
        bookModel.TotalCopies.Should().Be(entity.TotalCopies);
    }
}