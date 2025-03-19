namespace Anagrams
{
    internal abstract class Program
    {
        private static void Main()
        {
            Console.WriteLine("Enter a string to find anagram pairs:");
            var input = Console.ReadLine();

                var result = Anagram.GetAnagrams(input);
                Console.WriteLine($"Number of anagram pairs: {result}");
        }
    }
}