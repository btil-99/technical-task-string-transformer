using TechnicalTask;

namespace TechnicalTaskTests;

[TestFixture]
public class StringTransformerServiceTests
{
    private IStringTransformer transformer = null!;

    [SetUp]
    public void SetUp() => transformer = new StringTransformerService();

    [TestCase("nepo", "openerent", TestName = "Even vowel count appends rent")]
    [TestCase("dog", "goddopen", TestName = "Odd vowels count appends open")]
    [TestCase("pizza", "azziparent", TestName = "Reverse string followed by earliest character in alphabet")]
    public void Transform_returns_correct_concatenated_string(string input, string expected)
    {
        Assert.That(transformer.Transform(input), Is.EqualTo(expected));
    }

    [Test]
    public void Transform_ignores_case_for_earliest_letter_but_keeps_original_casing_for_output()
    {
        Assert.That(transformer.Transform("Food"), Is.EqualTo("dooFdrent"));
    }

    [Test]
    public void Transform_ignores_non_letter_characters_for_letter_pick()
    {
        Assert.That(transformer.Transform("a1b!"), Is.EqualTo("!b1aaopen"));
    }
    
    [TestCase(null, TestName = "Null should throw null exception")]
    [TestCase("", TestName = "Empty string should throw null exception")]
    public void Transform_throws_exception_when_null_input(string? input)
    {
        Assert.That(() => transformer.Transform(input), Throws.TypeOf<ArgumentNullException>());
    }

    [TestCase("123")]
    [TestCase("   ")]
    [TestCase("!?-")]
    public void Transform_throws_exception_when_no_letters(string input)
    {
        Assert.That(() => transformer.Transform(input),
            Throws.TypeOf<ArgumentException>().With.Message.Contains("at least one letter"));
    }
}