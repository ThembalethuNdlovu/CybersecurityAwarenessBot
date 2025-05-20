using System;
using System.Collections.Generic;

namespace CybersecurityAwarenessBot
{
    public static class CyberBotUtils
    {
        // Random generator for variety
        static Random rnd = new Random();

        // Detect basic positive/negative sentiment
        public static string DetectMood(string input)
        {
            string lowerInput = input.ToLower();
            string[] positiveWords = { "good", "great", "awesome", "fine", "okay", "happy", "well" };
            string[] negativeWords = { "bad", "sad", "tired", "angry", "upset", "mad", "frustrated" };

            foreach (string word in positiveWords)
            {
                if (lowerInput.Contains(word))
                {
                    return "😊 I'm glad you're feeling " + word + "!";
                }
            }

            foreach (string word in negativeWords)
            {
                if (lowerInput.Contains(word))
                {
                    return "😟 I'm sorry you're feeling " + word + ". Cyber safety matters even on tough days.";
                }
            }

            return "";
        }

        // Categorized response generator
        public static string GetCyberResponse(string input)
        {
            input = input.ToLower();

            if (input.Contains("phishing"))
            {
                string[] replies = {
                    "🎣 Phishing is when attackers trick you into giving personal info via fake emails or websites.",
                    "Beware of phishing scams — never click suspicious links or attachments!",
                    "Phishing often looks like legit emails from banks or stores. Always verify the source!"
                };
                return GetRandomReply(replies);
            }
            else if (input.Contains("password"))
            {
                string[] replies = {
                    "🔑 Use a strong password with a mix of letters, numbers, and symbols!",
                    "Never reuse the same password across multiple sites.",
                    "Consider using a password manager to keep your logins secure."
                };
                return GetRandomReply(replies);
            }
            else if (input.Contains("malware") || input.Contains("virus"))
            {
                string[] replies = {
                    "🛡️ Malware is harmful software that can damage or spy on your system.",
                    "Keep your antivirus software up to date to protect against malware.",
                    "Avoid downloading files from unknown or shady websites."
                };
                return GetRandomReply(replies);
            }
            else if (input.Contains("safe browsing") || input.Contains("web safety"))
            {
                string[] replies = {
                    "🌐 Always make sure websites use HTTPS before entering personal info.",
                    "Be cautious about clicking popups or banners, especially on unfamiliar sites.",
                    "Use browser security features and ad blockers to improve web safety."
                };
                return GetRandomReply(replies);
            }
            else if (input.Contains("2fa") || input.Contains("two factor"))
            {
                return "🧪 2FA (Two-Factor Authentication) adds an extra layer of security using your phone or app to verify it's you.";
            }
            else if (input.Contains("firewall"))
            {
                return "🧱 A firewall monitors incoming and outgoing traffic — it's like a bouncer for your network.";
            }
            else if (input.Contains("vpn"))
            {
                return "🕵️ A VPN hides your IP and encrypts your internet activity, making public Wi-Fi safer to use.";
            }

            return "";
        }

        private static string GetRandomReply(string[] replies)
        {
            int index = rnd.Next(replies.Length);
            return replies[index];
        }
    }
}
