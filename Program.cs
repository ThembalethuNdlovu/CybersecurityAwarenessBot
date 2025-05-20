using System;
using System.Media;
using System.IO;
using System.Threading;
using CybersecurityAwarenessBot; // <-- Namespace for CyberBotUtils.cs

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGreetingSound();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("********************************************");
            Console.WriteLine("*  Welcome to the Cybersecurity Awareness  *");
            Console.WriteLine("*                Chatbot                   *");
            Console.WriteLine("********************************************");
            Console.ResetColor();

            TypingEffect("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What's your name?");
            Console.ResetColor();
            string userName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            TypingEffect($"Hi {userName}! I'm happy to assist you with your cybersecurity knowledge.");
            Console.ResetColor();

            DisplayAsciiArt();

            Console.WriteLine("\nYou can ask me about cybersecurity, or type 'exit' to quit.\n");

            string lastTopic = "";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{userName}: ");
                string userInput = Console.ReadLine().ToLower();
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypingEffect("Please type something so I can help you.");
                    Console.ResetColor();
                    continue;
                }

                if (userInput == "exit" || userInput == "quit")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    TypingEffect("Goodbye, stay safe online!");
                    Console.ResetColor();
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Cyan;

                // 1. Detect cybersecurity topic keywords
                string keywordResponse = CyberBotUtils.DetectKeyword(userInput);
                if (keywordResponse != null)
                {
                    TypingEffect($"🔐 {keywordResponse}");
                    lastTopic = userInput;
                    Console.ResetColor();
                    continue;
                }

                // 2. Sentiment detection
                string sentiment = CyberBotUtils.DetectSentiment(userInput);
                if (sentiment == "sad")
                {
                    TypingEffect("😟 I'm here for you. Want to hear a cybersecurity tip?");
                    Console.ResetColor();
                    continue;
                }
                else if (sentiment == "happy")
                {
                    TypingEffect("😊 I'm glad you're feeling good! Let's talk about staying safe online.");
                    Console.ResetColor();
                    continue;
                }

                // 3. General questions (purpose, mood, etc.)
                if (userInput.Contains("how are you"))
                {
                    TypingEffect(CyberBotUtils.GetRandomResponse(CyberBotUtils.MoodResponses));
                }
                else if (userInput.Contains("what's your purpose") || userInput.Contains("what is your purpose"))
                {
                    TypingEffect("My purpose is to help you stay safe online and raise awareness about cybersecurity.");
                }
                else if (userInput.Contains("what can i ask you about"))
                {
                    TypingEffect("You can ask me about password safety, phishing, safe browsing, and more!");
                }
                else
                {
                    TypingEffect("🤖 I'm not sure I understand. Try asking about password safety, phishing, or safe browsing.");
                }

                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            TypingEffect("Thanks for chatting with me! Stay safe online.");
            Console.ResetColor();
        }

        static void TypingEffect(string message)
        {
            foreach (char letter in message)
            {
                Console.Write(letter);
                Thread.Sleep(50); // Typing speed
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
                    Console.WriteLine("Greeting sound file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing greeting sound: " + ex.Message);
            }
        }

        static void DisplayAsciiArt()
        {
            string asciiPath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "ascii_logo.txt");
            if (File.Exists(asciiPath))
            {
                string asciiArt = File.ReadAllText(asciiPath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(asciiArt);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("ASCII art not found.");
            }
        }
    }
}
