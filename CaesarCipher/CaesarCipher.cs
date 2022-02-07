using System.Linq;
using CaesarCipher.Helpers;

namespace CaesarCipher
{
    public class CaesarCipher
    {
        private readonly string _text;
        private readonly int _chipperKey;

        public CaesarCipher(string text, int chipperKey)
        {
            _text = text;
            _chipperKey = chipperKey;
        }

        public string Encrypt()
        {
            var encryptedCharacters = _text.Select(c => ProcessEncryption(c)).ToArray();

            return new string(encryptedCharacters);
        }

        public string Decrypt()
        {
            var decryptedCharacters = _text.Select(c => ProcessDecryption(c)).ToArray();

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
            var numberOfAllLetters = AsciiLettersHelper.GetNumberOfAllLetters();
            var firstLetter = plainLetter.GetAssociatedFirstLetter();

            var shiftOfNumber = (plainLetter - firstLetter + _chipperKey) % numberOfAllLetters;
            
            if (shiftOfNumber < 0)
            {
                shiftOfNumber += numberOfAllLetters;
            }

            return (char)(firstLetter + shiftOfNumber);
        }

        private char DecryptLetter(char encryptedLetter)
        {
            var numberOfAllLetters = AsciiLettersHelper.GetNumberOfAllLetters();
            var firstLetter = encryptedLetter.GetAssociatedFirstLetter();

            var shiftOfNumber = (encryptedLetter - firstLetter - _chipperKey) % numberOfAllLetters;

            if (shiftOfNumber < 0)
            {
                shiftOfNumber += numberOfAllLetters;
            }

            return (char)(firstLetter + shiftOfNumber);
        }
    }
}