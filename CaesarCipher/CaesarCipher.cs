using System.Linq;
using CaesarCipher.Helpers;

namespace CaesarCipher
{
    public class CaesarCipher
    {
        private readonly int _numberOfAllLetters;
        private readonly int _chipperKey;

        public CaesarCipher(int chipperKey)
        {
            _numberOfAllLetters = AsciiLettersHelper.GetNumberOfAllLetters();

            chipperKey %= _numberOfAllLetters;
            if (chipperKey < 0)
            {
                chipperKey += _numberOfAllLetters;
            }

            _chipperKey = chipperKey;
        }

        public string Encrypt(string text)
        {
            var encryptedCharacters = text.Select(c => ProcessEncryption(c)).ToArray();

            return new string(encryptedCharacters);
        }

        public string Decrypt(string text)
        {
            var decryptedCharacters = text.Select(c => ProcessDecryption(c)).ToArray();

            return new string(decryptedCharacters);
        }

        private char ProcessEncryption(char character)
        {
            return character.IsLetter() ? EncryptLetter(character) : character;
        }

        private char ProcessDecryption(char character)
        {
            return character.IsLetter() ? DecryptLetter(character) : character;
        }

        private char EncryptLetter(char plainLetter)
        {
            var firstLetter = plainLetter.GetAssociatedFirstLetter();

            var shiftOfNumber = (plainLetter - firstLetter + _chipperKey) % _numberOfAllLetters;

            return (char)(firstLetter + shiftOfNumber);
        }

        private char DecryptLetter(char encryptedLetter)
        {
            var firstLetter = encryptedLetter.GetAssociatedFirstLetter();

            var shiftOfNumber = (encryptedLetter - firstLetter - _chipperKey + _numberOfAllLetters) % _numberOfAllLetters;

            return (char)(firstLetter + shiftOfNumber);
        }
    }
}