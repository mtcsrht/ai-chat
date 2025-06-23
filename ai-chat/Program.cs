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
        using StreamWriter sw = new StreamWriter("../../logs.txt", true, System.Text.Encoding.UTF8);
        bool exit = false;
        do
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[CLIENT]: ");
            sw.Write("[CLIENT]: ");
            Console.ForegroundColor = ConsoleColor.White;
            var clientText = Console.ReadLine()?.Trim();

            // Check for exit command
            if (clientText?.ToLower() == "exit" || clientText?.ToLower() == "quit")
            {
                exit = true;
            }
            else
            {
                // Log client input
                sw.WriteLine(clientText);
                sw.Flush();

                if (!string.IsNullOrWhiteSpace(clientText) && clientText.Length > 1)
                {
                    response = client.CompleteChat(clientText);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[ASSISTANT]: ");
                    sw.WriteLine("[ASSISTANT]:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{response.Content[0].Text}");
                    sw.WriteLine($"{response.Content[0].Text}");
                    sw.Flush();
                }
            }


        } while (!exit);
    }
}
