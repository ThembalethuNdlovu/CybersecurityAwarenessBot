using System;
using System.Media;
using System.IO;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        // Simulates typing effect for responses
        static void TypingEffect(string message, int delay = 50)
        {
            foreach (char letter in message)
            {
                Console.Write(letter);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        // Plays greeting sound from the Assets folder
        static void PlayGreetingSound()
        {
            try
            {
                string audioFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "greeting.wav");
                if (File.Exists(audioFilePath))
                {
                    SoundPlayer player = new SoundPlayer(audioFilePath);
                    player.PlaySync(); // Waits for audio to finish
                }
                else
                {
                    Console.WriteLine("⚠️ Greeting sound file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error playing greeting sound: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            // Play greeting sound
            PlayGreetingSound();

            // Show header with green border
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("********************************************");
            Console.WriteLine("*  Welcome to the Cybersecurity Awareness  *");
            Console.WriteLine("*                Chatbot                   *");
            Console.WriteLine("********************************************");
            Console.ResetColor();

            // Show intro message with typing effect
            Console.ForegroundColor = ConsoleColor.White;
            TypingEffect("Hello! I'm your Cybersecurity Awareness Bot. Let's keep your digital life safe!");
            Console.ResetColor();

            // Ask for the user's name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n🤖 What's your name? ");
            Console.ResetColor();
            string userName = Console.ReadLine()?.Trim();

            // Personalized greeting
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypingEffect($"\nHi {userName}, it's great to meet you! 💻 Let's talk about online safety.");
            Console.ResetColor();

            // Display Help Prompt
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n🔍 You can ask me about topics like:");
            Console.WriteLine("   - Phishing");
            Console.WriteLine("   - Password safety");
            Console.WriteLine("   - Malware");
            Console.WriteLine("   - Safe browsing");
            Console.WriteLine("   - Firewalls, VPNs, 2FA");
            Console.WriteLine("💡 Type 'exit' anytime to end the chat.");
            Console.ResetColor();

            // ASCII art logo
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(@"
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@ Cybersecurity Awareness Chatbot by Thembalethu Ndlovu @@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
");
            Console.ResetColor();

            // Chat Loop
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\n🧠 You: ");
                string userInput = Console.ReadLine()?.Trim();

                // Handle empty input
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("⚠️ Please type something.");
                    continue;
                }

                // Handle exit command
                if (userInput.ToLower() == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    TypingEffect("👋 Goodbye! Stay cyber safe!");
                    break;
                }

                // Detect mood/emotion
                string moodResponse = CyberBotUtils.DetectMood(userInput);
                if (!string.IsNullOrEmpty(moodResponse))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    TypingEffect($"Bot: {moodResponse}");
                    continue;
                }

                // Respond to cybersecurity questions
                string cyberResponse = CyberBotUtils.GetCyberResponse(userInput);
                if (!string.IsNullOrEmpty(cyberResponse))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect($"Bot: {cyberResponse}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    TypingEffect("🤔 Bot: I'm not sure how to respond to that. Try asking about phishing, passwords, or safe browsing.");
                }

                Console.ResetColor();
            }

            // Final goodbye
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypingEffect("💬 Thanks for chatting with me! Remember, cybersecurity starts with YOU.");
            Console.ResetColor();
        }
    }
}
