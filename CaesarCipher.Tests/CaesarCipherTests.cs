using FluentAssertions;
using Xunit;

namespace CaesarCipher.Tests
{
    public class CaesarCipherTests
    {
        [Theory]
        [InlineData("a", "b", 1)]
        [InlineData("z", "a", 1)]
        [InlineData("a", "z", -1)]
        [InlineData("z", "y", -1)]
        [InlineData("a", "z", 25)]
        [InlineData("z", "y", 25)]
        [InlineData("a", "b", -25)]
        [InlineData("z", "a", -25)]
        [InlineData("a", "b", 27)]
        [InlineData("z", "a", 27)]
        [InlineData("a", "z", -27)]
        [InlineData("z", "y", -27)]
        [InlineData("treasure", "dbokcebo", 10)]
        public void Encrypt_ForTextInLowerCaseLetters_ReturnsEncryptedText(
            string plainText, string encryptedText, int encryptionKey)
        {
            var caesarCipher = new CaesarCipher(plainText, encryptionKey);

            var result = caesarCipher.Encrypt();

            result.Should().BeEquivalentTo(encryptedText);
        }

        [Theory]
        [InlineData("A", "B", 1)]
        [InlineData("Z", "A", 1)]
        [InlineData("A", "Z", -1)]
        [InlineData("Z", "Y", -1)]
        [InlineData("A", "Z", 25)]
        [InlineData("Z", "Y", 25)]
        [InlineData("A", "B", -25)]
        [InlineData("Z", "A", -25)]
        [InlineData("A", "B", 27)]
        [InlineData("Z", "A", 27)]
        [InlineData("A", "Z", -27)]
        [InlineData("Z", "Y", -27)]
        [InlineData("TREASURE", "DBOKCEBO", 10)]
        public void Encrypt_ForTextInUpperCaseLetters_ReturnsEncryptedText(
            string plainText, string encryptedText, int encryptionKey)
        {
            var caesarCipher = new CaesarCipher(plainText, encryptionKey);

            var result = caesarCipher.Encrypt();

            result.Should().BeEquivalentTo(encryptedText);
        }

        [Fact]
        public void Encrypt_ForTextWithLettersAndNonLetterCharacters_ReturnsTextWithEncryptedLetters()
        {
            const string plainText = "Hello .NET world 2022!";
            const string encryptedText = "Ebiil .KBQ tloia 2022!";
            const int encryptionKey = 127;

            var caesarCipher = new CaesarCipher(plainText, encryptionKey);

            var result = caesarCipher.Encrypt();

            result.Should().BeEquivalentTo(encryptedText);
        }

        [Theory]
        [InlineData("b", "a", 1)]
        [InlineData("a", "z", 1)]
        [InlineData("z", "a", -1)]
        [InlineData("y", "z", -1)]
        [InlineData("z", "a", 25)]
        [InlineData("y", "z", 25)]
        [InlineData("b", "a", -25)]
        [InlineData("a", "z", -25)]
        [InlineData("b", "a", 27)]
        [InlineData("a", "z", 27)]
        [InlineData("z", "a", -27)]
        [InlineData("y", "z", -27)]
        [InlineData("dbokcebo!", "treasure!", 10)]
        public void Decrypt_ForTextInLowerCaseLetters_ReturnsDecryptedText(
            string encryptedText, string decryptedText, int decryptionKey)
        {
            var caesarCipher = new CaesarCipher(encryptedText, decryptionKey);

            var result = caesarCipher.Decrypt();

            result.Should().BeEquivalentTo(decryptedText);
        }

        [Theory]
        [InlineData("B", "A", 1)]
        [InlineData("A", "Z", 1)]
        [InlineData("Z", "A", -1)]
        [InlineData("Y", "Z", -1)]
        [InlineData("Z", "A", 25)]
        [InlineData("Y", "Z", 25)]
        [InlineData("B", "A", -25)]
        [InlineData("A", "Z", -25)]
        [InlineData("B", "A", 27)]
        [InlineData("A", "Z", 27)]
        [InlineData("Z", "A", -27)]
        [InlineData("Y", "Z", -27)]
        [InlineData("DBOKCEBO", "TREASURE", 10)]
        public void Decrypt_ForTextInUpperCaseLetters_ReturnsDecryptedText(
            string encryptedText, string decryptedText, int decryptionKey)
        {
            var caesarCipher = new CaesarCipher(encryptedText, decryptionKey);

            var result = caesarCipher.Decrypt();

            result.Should().BeEquivalentTo(decryptedText);
        }

        [Fact]
        public void Decrypt_ForTextWithLettersAndNonLetterCharacters_ReturnsTextWithDecryptedLetters()
        {
            const string encryptedText = "Ebiil .KBQ tloia 2022!";
            const string decryptedText = "Hello .NET world 2022!";
            const int decryptionKey = 127;

            var caesarCipher = new CaesarCipher(encryptedText, decryptionKey);

            var result = caesarCipher.Decrypt();

            result.Should().BeEquivalentTo(decryptedText);
        }
    }
}