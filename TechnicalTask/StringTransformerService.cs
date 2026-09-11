namespace TechnicalTask;

public class StringTransformerService : IStringTransformer
{
    static readonly HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];

    public string Transform(string input)
    {
        if(string.IsNullOrEmpty(input)) throw new ArgumentNullException(nameof(input));

        // 1. Reverse string
        var reversedString = new string(input.Reverse().ToArray());

        // 2. earliest character in the alphabet
        var letters = input.Where(char.IsLetter).ToList();
        if(letters.Count == 0) throw new ArgumentException("Input must have at least one letter", nameof(input));

        var earliestLetter = letters.OrderBy(char.ToLowerInvariant).First();

        // 3. open/rent based on vowel count
        var vowelCount = input.Count(x => vowels.Contains(char.ToLowerInvariant(x)));
        var suffix = vowelCount % 2 != 0 ? "open" : "rent";

        // concat everything
        return reversedString + earliestLetter + suffix;
    }
}