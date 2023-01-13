using FluentAssertions;
using RoyalLib.Api.ValueObjects;

namespace RoyalLib.Units.Api.ValueObjects;

public class SearchByCase
{
    [Theory, AutoArrange]
    public void SearchBy_InvalidString_ShouldBeInvalid(string invalidString)
    {
        // Act
        var searchBy = (SearchBy)invalidString;

        // Assert
        searchBy.IsValid().Should().BeFalse();
    }

    [Theory]
    [InlineData(SearchBy.AUTHOR)]
    [InlineData(SearchBy.TITLE)]
    [InlineData(SearchBy.ISBN)]
    public void SearchBy_ValidString_ShouldBeValid(string validStr)
    {
        // Act
        var searchBy = (SearchBy)validStr;

        // Assert
        searchBy.IsValid().Should().BeTrue();
    }
}
