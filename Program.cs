using System;
using System.Media;
using System.IO;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static string userName = "";
        static string lastTopic = "";

        static void TypingEffect(string message)
        {
            foreach (char letter in message)
            {
                Console.Write(letter);
                Thread.Sleep(30); // faster typing effect
            }
            Console.WriteLine();
        }

        static void PlayGreetingSound()
        {
            try
            {
                string audioFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "greeting.wav");
                if (File.Exists(audioFilePath))
                {
                    SoundPlayer player = new SoundPlayer(audioFilePath);
                    player.PlaySync();
                }
                else
                {
                    Console.WriteLine("🔇 Greeting sound file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing the greeting sound: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";
            PlayGreetingSound();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("********************************************");
            Console.WriteLine("*  Welcome to the Cybersecurity Awareness  *");
            Console.WriteLine("*                Chatbot 🤖               *");
            Console.WriteLine("********************************************");
            Console.ResetColor();

            TypingEffect("Hello! I'm your Cybersecurity Awareness Bot 🤖");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("What's your name? ");
            Console.ResetColor();
            userName = Console.ReadLine()?.Trim();
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypingEffect($"Hi {userName}, happy to have you here! 💡");
            Console.ResetColor();

            TypingEffect("Ask me anything about cybersecurity (e.g., phishing, password safety). Type 'exit' anytime to leave.\n");

            bool continueChat = true;

            while (continueChat)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("🧠 You: ");
                Console.ResetColor();
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    TypingEffect("🤔 I didn't catch that. Can you try again?");
                    continue;
                }

                if (userInput == "exit")
                {
                    TypingEffect("👋 Goodbye! Stay safe online!");
                    break;
                }

                // Check sentiment
                string mood = CyberBotUtils.DetectMood(userInput);
                if (!string.IsNullOrEmpty(mood))
                {
                    TypingEffect(mood);
                }

                // Get cyber response
                string response = CyberBotUtils.GetCyberResponse(userInput);
                if (!string.IsNullOrEmpty(response))
                {
                    TypingEffect(response);
                    lastTopic = userInput; // memory recall
                }
                else
                {
                    TypingEffect("❓ I didn't understand that. Try asking me about topics like 'safe browsing', 'malware', or 'password safety'.");
                }

                // Conversation Flow
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\n🔄 Would you like to continue? (yes/no): ");
                Console.ResetColor();
                string continueInput = Console.ReadLine()?.Trim().ToLower();

                if (continueInput == "no" || continueInput == "n")
                {
                    TypingEffect("✅ Alright, goodbye for now! Stay cyber safe! 🔐");
                    continueChat = false;
                }
                else if (continueInput == "yes" || continueInput == "y")
                {
                    if (!string.IsNullOrEmpty(lastTopic))
                    {
                        TypingEffect($"Great! Let me know if you want to dive deeper into '{lastTopic}' 🧐");
                    }
                }
                else
                {
                    TypingEffect("🤖 I’ll assume you want to continue. Let’s keep going!\n");
                }
            }
        }
    }
}
