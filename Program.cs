using System;
using System.Media;
using System.IO;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        // Method to simulate the typing effect
        static void TypingEffect(string message)
        {
            foreach (char letter in message)
            {
                Console.Write(letter);
                Thread.Sleep(100); // Adjust the speed of typing effect
            }
            Console.WriteLine();
        }

        // Method to play the voice greeting
        static void PlayGreetingSound()
        {
            try
            {
                // Get the path to the WAV file relative to the project's output directory
                string audioFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "greeting.wav");

                // Check if the file exists before trying to play it
                if (File.Exists(audioFilePath))
                {
                    SoundPlayer player = new SoundPlayer(audioFilePath);
                    player.PlaySync(); // PlaySync ensures the greeting plays before moving forward
                }
                else
                {
                    Console.WriteLine("Greeting sound file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing the greeting sound: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            // Play the voice greeting
            PlayGreetingSound();

            // Add a border with color
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("********************************************");
            Console.WriteLine("*  Welcome to the Cybersecurity Awareness  *");
            Console.WriteLine("*                Chatbot                   *");
            Console.WriteLine("********************************************");
            Console.ResetColor();

            // Simulate typing effect for greeting
            TypingEffect("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");

            // Spacing
            Console.WriteLine();

            // Ask for user's name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What's your name?");
            Console.ResetColor();

            string userName = Console.ReadLine();

            // Personalized greeting
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypingEffect($"Hi {userName}! I'm happy to assist you with your cybersecurity knowledge.");
            Console.ResetColor();

            // Display ASCII Art (Cybersecurity Awareness Bot Logo)
            Console.WriteLine(@"@@@@@%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@%%%%%%%%%%%%%%%%%%%%%%%%%#-%%%%%%%=%%%%%%%##%%%%%%%%%%%%%%%%%%%%%%%%%%@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@%%%%%%%%%%%%%%%%%%%%%%%%%%#%%===%%%%%%#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%@@@@@@@@@@@@@@@@@@@@@@@@@
%%@@%%%%%%%%%%%%%%%%%%%%%%%*%%#%#+#:#%%%*%+%+%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%@@@@@@@@@@@@@@@@@@@@@@
%%%%%%%%%%%%%%%%%%%%%%%%*##*%%#%%+:#%%%%%*%#+%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%@@@@@@@@@@@@@@@@@@@@@
%%%%%%%%%%%%%%%%%%%%%%#+*##*#%*%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%@@@@@@@@@@@@@@@@@@@
%%%%%%%%%%%%%%%%%%%+#%#+*##*#%##%####%################################%%%%%%%%%%%@@@@@@@@@@@@@@@@@@@
%%%%%%%%%%%%%%+%%#%+#%#+*##*#%#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%%%%%%%%%%%%@@@@@@@@@@@@@@@@@@
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%%%%%%%%%%+=*+*%#++==%%==+#==#%%%%%%%%##%%%%%%%%%%%@@@@@@@@@@@@@@@@@@
%%%%%%%%%%%%%%%%#=%%%%%%%%%%%%#%%%%%%%%%-%%%%+#+%-%*=%=%%#*#:%%%%%%%%##%%%%%%%%%%%@@@@@@@@@@@@@@@@@@
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%%%%%%%%%-%%%%%.%%-%%-#+%%#*+*%%%%%%%%#%%%%%%%%%%%@@@@@@@@@@@@@@@@@@@
%%%%%%%%%%%%%%%%%%%%*######+%%#%%%%%%%%%%##%%%#%%%##%%##%%%%%%%%%%%%%#%%*%%*%%%%@@@@@@@@@@@@@@@@@@@@
@@@%%%%%%%%%%%-##=%%*@%%%%%+%%#%%%%%%%%%%#%%##%%%%%%%*#%%##****%%#%%%#%%*%%*%%%%%%@@@@@@@@@@@@@@@@@@
@@@@@@@%%%%%%%@@%%%%********%%#%%%#-%#%:%%%-%%#=#%#**#%:%:%*+%%=**%%%#%%%%%+%%%@@%@@@@@@@@@@@@@@@@@@
@@@@@@@%%%%%%%%%%%%%*+*****#%%#%%%%%*:#:##*=%%%=#%****=#%:%*+%%*-%%%%#%%%%%%%%@@@%@@@@@@%@@@@@@@@@@@
@@@@@@@@%%@%@%@@%%%%%%%%%%%%%%#%%%#=-*%--=##==#%*=*%#%%*#*%%#%%%#%%%%%%%#%%@%%@@@%@@@@@@@@@@@@@@%#+=
@@@@@@@@@@%%*%%%#=%%%%%%%%%*%%#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#+#+*@@%%-==-%@@@#+-=-----
@@@@@@@@@@@@@@@@%%@@%%++%%%%%%#%%%%%%%%%%%%%%%%%%%%%%%%%%%%###########%@%%#%%**@@%@%++@@@+----=====+
@@@@@@@@@@@@@@@@@%@%*....+@%%%%%%%%%%%%%%%%@%%@%%%%%%%%%%%%%%%#%%%%%%%%%%@@%+#@@@%@@@@@#:---=+*#*+**
@@@@@@@@@@@@@@@@@@@@+=:=:+@%@%@*%%##%#*%#=%#=#%=+%%*%%%%%%%%%%-#%%%%%-#@+%**%%#%@@@@@@=---=+*#*=++*#
@@@@@@@@@@@@@@@@@@@@+:-@=*@%@@%+#%*#%#*%%*%%*%%#%@@%%@%%%%%%%%%@@%%@%%@@@@@%@%@@@@@@+---=*##*--=+*#%
@@@@@@@@@@@@@@@@@%#%%%%%%%%+%%%%%%%%%%#*%%%%%%%%%%%#%@##%@##%@%@@@%+=..:%@@@@+%@%@*--==+#%@#--=++*#%
@@@@@@@@@@@@@@@@@@@@%#####@%@@@%*#**%%%%%%%%:.*%%%%%%%*%*-%*%%#%%=......-#%%%#%@%---+*#%@@%===+*#***
@@@@@@@@@@@@@@@@@@@@+=====%%%%%*#**#+######=..:=#######=##*#####*.......-#%%%%%%%++*%%%%%%%++*###***
@@@@@@@@@@%%%%%%%%%%#*****%%%%%*#+*+######+#*-##-#######*+####*#############%%%%%===+*%%%%%######%%%
@@@@@@@@@@@@@@%###%%%%%%%%%#%%%%%*##%#####+++**###################%%%#%%%%#########%%%%@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@%#*#%%%####%%%%@@@%%%%#####*#**###%%%@@@@@@@@@@%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
");

            // Text-based greeting and user interaction
            Console.WriteLine("\nI'm here to help you stay safe online.");
            Console.WriteLine("\nAsk me about cybersecurity, or type 'exit' to quit.");

            // Basic Response System
            while (true)
            {
                string userInput = Console.ReadLine().ToLower();

                // Handle exit condition
                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    TypingEffect("Goodbye, stay safe online!");
                    break;
                }

                // Respond to common questions
                if (userInput.Contains("how are you"))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect("I'm just a bot, but I'm doing great! How can I assist you?");
                }
                else if (userInput.Contains("what's your purpose"))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect("My purpose is to help you stay safe online and raise awareness about cybersecurity.");
                }
                else if (userInput.Contains("what can i ask you about"))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect("You can ask me about password safety, phishing, safe browsing, and more!");
                }
                else if (userInput.Contains("password safety"))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect("It's important to use strong passwords and change them regularly. Avoid using the same password across multiple sites.");
                }
                else if (userInput.Contains("phishing"))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect("Phishing emails try to trick you into giving away personal information. Always verify the sender before clicking links or downloading attachments.");
                }
                else if (userInput.Contains("safe browsing"))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect("Make sure to use HTTPS websites and avoid clicking on suspicious links. Keep your browser and software updated.");
                }
                else
                {
                    // Handle unsupported input
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypingEffect("I didn't quite understand that. Could you rephrase?");
                }

                // Reset color after each interaction
                Console.ResetColor();
            }

            // End the program
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypingEffect("Thanks for chatting with me! Stay safe online.");
            Console.ResetColor();
        }
    }
}
