using OOP;
static void Main(string[] args)
{
    string file = @"D:\bgm\arithmetic\OOP\JSONValidator\JSONText.txt";
    string text = File.ReadAllText(file);
    var value = new Value();
    var json = value.Match(text);
    Console.WriteLine(json.Success() && json.RemainingText() == "" ? "Valid JSON format" : "Invalid JSON format");
}
