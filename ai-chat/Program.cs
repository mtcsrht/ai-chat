namespace ai_chat;
using OpenAI.Chat;
class Program
{
    private static ChatCompletion response;
    static void Main()
    {
        Console.Clear();
        var apikey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        ChatClient client = new ChatClient(model: "gpt-4o", apiKey: apikey);
        using StreamWriter sw = new StreamWriter("../../logs.txt",true, System.Text.Encoding.UTF8);
        do
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[CLIENT]: ");
            sw.Write("[CLIENT]: ");
            Console.ForegroundColor = ConsoleColor.White;
            var clientText = Console.ReadLine().Trim();
            if (clientText != null && clientText.Length > 1)
            {
                sw.WriteLine(response);
                response = client.CompleteChat(clientText);
                
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[ASSISTANT]: ");
            sw.WriteLine("[ASSISTANT]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{response.Content[0].Text}");
            sw.WriteLine($"{response.Content[0].Text}");
        } while (true);
    }
}
