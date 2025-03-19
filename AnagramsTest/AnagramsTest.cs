namespace Anagrams
{
    public class AnagramTests
    {
        [Theory]
        [InlineData("abba", 4)]
        [InlineData("abcd", 0)]
        [InlineData("kkkk", 10)]
        public void GetAnagrams_ValidInput_ReturnsCount(string input, int expected)
        {
            Assert.Equal(expected, Anagram.GetAnagrams(input));
        }

        [Fact]
        public void GetAnagrams_EmptyString_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Anagram.GetAnagrams(""));
        }

        [Fact]
        public void GetAnagrams_TooShort_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Anagram.GetAnagrams("ab"));
        }

        [Fact]
        public void GetAnagrams_TooLong_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Anagram.GetAnagrams(new string('z', 101)));
        }

        [Theory]
        [InlineData("zab1")]
        [InlineData("ZABV")]
        public void GetAnagrams_InvalidCharacters_ThrowsException(string input)
        {
            Assert.Throws<ArgumentException>(() => Anagram.GetAnagrams(input));
        }

        [Fact]
        public void GetAnagrams_SingleCharacter_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Anagram.GetAnagrams("z"));
        }
    }
}