using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Enter a string to analyze: ");
            string? userInput = Console.ReadLine();

            var validationMessage = ValidateInput(userInput);
            if (string.IsNullOrEmpty(validationMessage))
            {
                FirstUniqueChar(userInput!);
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine(validationMessage);
                WriteDividerLine('_', 65);
                Console.WriteLine("");
            }

            Console.WriteLine("Press any key to restart.");
            Console.ReadKey();
        }
    }

    static void FirstUniqueChar(string s)
    {
        var count = new Dictionary<char, int>();

        Console.WriteLine("");
        Console.WriteLine($"Find the first non-repeating char in the string: {s}");
        WriteDividerLine('_', 65);
        Console.WriteLine("");

        foreach (var c in s)
        {
            Console.WriteLine($"Evaluating char: '{c}': {count.GetValueOrDefault(c, 0) + 1} result(s)");
            count[c] = count.GetValueOrDefault(c, 0) + 1;
        }

        Console.WriteLine("");
        Console.WriteLine("Iterate through characters until first unique result is found:");
        Console.WriteLine("");

        var i = 0;
        foreach (var c in s)
        {
            i++;

            if (i == s.Length) {
                WriteDividerLine('_', 65);
                Console.WriteLine("");
                Console.WriteLine("No unique characters found.");
                Console.WriteLine("");
                return;
            }

            if (count[c] == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{i}) character: '{c}' - count: {count[c]} - SUCCESS");
                Console.ResetColor();
                WriteDividerLine('_', 65);
                Console.WriteLine("");
                Console.WriteLine($"Character '{c}' is the first non-repeating character.");
                Console.WriteLine("");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{i}) character: '{c}' - count: {count[c]}");
            Console.ResetColor();
        }
    }
    
    static void WriteDividerLine(char c, int length)
    {
        Console.WriteLine(new string(c, length));
    }

    static string? ValidateInput(string? userInput)
    {
        if (string.IsNullOrWhiteSpace(userInput))
        {
            return "Input is empty.";
        }
        else
        {
            return null;
        }
    }

    
}
