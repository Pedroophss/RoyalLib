using FluentAssertions;
using RoyalLib.Domain.Models;

namespace RoyalLib.Units.Domain.Models;

public class PageOutputCase
{
    [Fact]
    public void PageOutput_CreateEmpty_ShoudlBeEmpty()
    {
        // Act
        var page = PageOutput<string>.Empty();

        // Assert
        page.Items.Should().BeEmpty();
        page.Total.Should().Be(0);
    }
}
