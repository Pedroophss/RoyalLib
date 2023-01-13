using FluentAssertions;
using RoyalLib.Domain.ValueObjects;

namespace RoyalLib.Units.Domain.ValueObjects;

public class IsbnCase
{
    [Theory, AutoArrange]
    public void ISBN_InvalidString_ShouldBeInvalid(string invalidString)
    {
        // Act
        var isbn = (Isbn)invalidString;

        // Assert
        isbn.IsValid().Should().BeFalse();
    }

    [Theory, AutoArrange]
    public void ISBN_ValidString_ShouldBeValid(int validInput)
    {
        // Act
        var isbn = (Isbn)validInput.ToString();

        // Assert
        isbn.IsValid().Should().BeTrue();
    }
}
