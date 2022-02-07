namespace CaesarCipher.Helpers
{
    public static class AsciiLettersHelper
    {
        private const int FirstLowercaseLetter = 'a';
        
        private const int LastLowercaseLetter = 'z';
        
        private const int FirstUppercaseLetter = 'A';
        
        private const int LastUppercaseLetter = 'Z';

        public static int GetNumberOfAllLetters()
        {
            return (LastLowercaseLetter - FirstLowercaseLetter) + 1;
        }
        
        public static bool IsLetter(this char character)
        {
            return IsLowercaseLetter(character) || IsUppercaseLetter(character);
        }

        public static int GetAssociatedFirstLetter(this char letter)
        {
            return IsLowercaseLetter(letter) ? FirstLowercaseLetter : FirstUppercaseLetter;
        }

        private static bool IsLowercaseLetter(int letter)
        {
            return letter >= FirstLowercaseLetter && letter <= LastLowercaseLetter;
        }
        
        private static bool IsUppercaseLetter(int letter)
        {
            return letter >= FirstUppercaseLetter && letter <= LastUppercaseLetter;
        }
    }
}