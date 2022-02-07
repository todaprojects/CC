using CaesarCipher.Helpers;
using FluentAssertions;
using Xunit;

namespace CaesarCipher.Tests.Helpers
{
    public class AsciiLettersHelperTests
    {
        [Fact]
        public void GetNumberOfAllLetters_ReturnsNumberOfAsciiLetters()
        {
            const int expectedNUmberOfAllLetters = 26;

            var result = AsciiLettersHelper.GetNumberOfAllLetters();

            result.Should().Be(expectedNUmberOfAllLetters);
        }
        
        [Theory]
        [InlineData('a')]
        [InlineData('b')]
        [InlineData('y')]
        [InlineData('z')]
        public void IsLetter_ForLowercaseAsciiLetters_ReturnsTrue(char inputChar)
        {
            var result = inputChar.IsLetter();

            result.Should().BeTrue();
        }
        
        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('Y')]
        [InlineData('Z')]
        public void IsLetter_ForUppercaseAsciiLetters_ReturnsTrue(char inputChar)
        {
            var result = inputChar.IsLetter();

            result.Should().BeTrue();
        }
        
        [Theory]
        [InlineData('`')]
        [InlineData('_')]
        [InlineData('{')]
        [InlineData('|')]
        public void IsLetter_ForCharactersOutsideLowercaseAsciiLetters_ReturnsFalse(char inputChar)
        {
            var result = inputChar.IsLetter();

            result.Should().BeFalse();
        }
        
        [Theory]
        [InlineData('@')]
        [InlineData('?')]
        [InlineData('[')]
        [InlineData('\\')]
        public void IsLetter_ForCharactersOutsideUppercaseAsciiLetters_ReturnsFalse(char inputChar)
        {
            var result = inputChar.IsLetter();

            result.Should().BeFalse();
        }

        [Fact]
        public void GetAssociatedFirstLetter_ForLowercaseAsciiLetter_ReturnsFirstUppercaseLetter()
        {
            const char argumentLetter = 'd';
            const char firstLowercaseLetter = 'a';

            var result = argumentLetter.GetAssociatedFirstLetter();

            result.Should().Be(firstLowercaseLetter);
        }
        
        [Fact]
        public void GetAssociatedFirstLetter_ForUppercaseAsciiLetter_ReturnsFirstUppercaseLetter()
        {
            const char argumentLetter = 'D';
            const char firstUppercaseLetter = 'A';

            var result = argumentLetter.GetAssociatedFirstLetter();

            result.Should().Be(firstUppercaseLetter);
        }
    }
}