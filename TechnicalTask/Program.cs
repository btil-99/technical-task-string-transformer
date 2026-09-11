namespace TechnicalTask;

public static class Program
{
    public static void Main(string[] args)
    {
        IStringTransformer service = new StringTransformerService();

        var input = args.Length > 0 ? args[0] : Prompt();
        
        try
        {
            var transformedString = service.Transform(input);
            Console.WriteLine($"Output: {transformedString}");
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Could not transform string: {exception.Message}");
        }
    }

    static string Prompt()
    {
        Console.Write("Enter a string: ");
        return Console.ReadLine() ?? string.Empty;
    }
}