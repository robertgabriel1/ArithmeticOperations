using OOP;

namespace JSONValidator
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No JSON found");
                return;
            }

            string text = File.ReadAllText(args[0]);
            var value = new Value();
            var json = value.Match(text);
            Console.WriteLine(json.Success() && json.RemainingText() == "" ? "Valid JSON format" : "Invalid JSON format");
        }
    }
}
