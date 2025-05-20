using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityAwarenessBot
{
    public static class CyberBotUtils
    {
        // Keyword-based cybersecurity facts
        public static Dictionary<string, string> KeywordResponses = new Dictionary<string, string>
        {
            { "password", "Make sure your password is at least 12 characters long and unique." },
            { "phishing", "Phishing is a scam where attackers trick you into revealing personal info." },
            { "safe browsing", "Always check the URL and use HTTPS websites when entering sensitive info." },
            { "malware", "Malware is software that is designed to damage or disable computers." },
            { "firewall", "A firewall helps protect your computer by filtering incoming and outgoing traffic." }
        };

        // Sentiment keyword banks
        public static List<string> SadWords = new List<string> { "sad", "tired", "upset", "angry", "frustrated", "depressed" };
        public static List<string> HappyWords = new List<string> { "happy", "excited", "great", "good", "amazing" };

        // Mood responses for variety
        public static List<string> MoodResponses = new List<string>
        {
            "I'm doing great! Staying safe online, as always.",
            "All systems operational. How about you?",
            "I'm feeling cyber-secure today!"
        };

        // Get a random response from a list
        public static string GetRandomResponse(List<string> responses)
        {
            Random rnd = new Random();
            int index = rnd.Next(responses.Count);
            return responses[index];
        }

        // Check if input contains any keyword (case insensitive)
        public static string DetectKeyword(string input)
        {
            foreach (var keyword in KeywordResponses)
            {
                if (input.ToLower().Contains(keyword.Key))
                {
                    return keyword.Value;
                }
            }
            return null; // No keyword matched
        }

        // Detect mood (basic sentiment)
        public static string DetectSentiment(string input)
        {
            input = input.ToLower();

            foreach (var word in SadWords)
            {
                if (input.Contains(word))
                    return "sad";
            }

            foreach (var word in HappyWords)
            {
                if (input.Contains(word))
                    return "happy";
            }

            return "neutral";
        }
    }
}