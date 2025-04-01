using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot2
{
    class Program
    {
        static SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        static string userName = "";

        static void Main(string[] args)
        {
            // Configure the bot's voice settings.
            ConfigureVoice();

            // Display a welcoming ASCII art to give the bot some personality.
            DisplayAsciiImage();

            // The bot introduces itself with a friendly greeting.
            IntroduceChatbot();

            // Ask the user for their name to personalize the conversation.
            GetUserName();

            // Begin the interactive chat loop where the user can ask questions.
            ChatLoop();
        }

        static void ConfigureVoice()
        {
            try
            {
                // Setting the bot's voice to a friendly female voice named "Hazel".
                synthesizer.SelectVoice("Microsoft Hazel");
            }
            catch (Exception)
            {
                // If "Hazel" isn't available, we go with any female voice the system offers.
                synthesizer.SelectVoiceByHints(VoiceGender.Female);
            }

            synthesizer.Rate = 1; // Normal speaking speed.
            synthesizer.Volume = 100; // Max volume to make sure the bot is clear and audible.
        }

        static void DisplayAsciiImage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            // The bot's cool ASCII art introduction. This gives the bot some unique personality as you can see taht it looks cute, friendly and techy.
            string asciiArt = @"
   (___________)
     |       |
  .-'  ^   ^  `-.
 /    (o) (o)    \        
|                 |      
|     '-----'     |         
 \_______________/ /          / ____|    | |             / ____|                | |   
    /         \   /          | |    _   _| |__   ___ _ _| (___  _ __   __ _ _ __| | __
   /           \ /           | |   | | | | '_ \ / _ \ '__\___ \| '_ \ / _` | '__| |/ /
  '-\-----------'            | |___| |_| | |_) |  __/ |  ____) | |_) | (_| | |  |   < 
   /            \             \_____\__, |_.__/ \___|_| |_____/| .__/ \__,_|_|  |_|\_\
  /              \                   __/ |                     | |                    
 '----|------|----'                 |___/                      |_|                    
      |_     |_

                    CyberSpark - Your Trusted Cybersecurity Awareness Bot
            ";

            Console.WriteLine(asciiArt);
            Console.ResetColor();
        }

        static void IntroduceChatbot()
        {
            string botName = "CyberSpark";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Hello. I am {botName}, your Cybersecurity Awareness Bot. I am here to help you stay safe online.");
            Console.ResetColor();

            // The bot will introduces itself through speech as well for a more interactive experience.
            Speak($"Hello. I am {botName}, your Cybersecurity Awareness Bot. I am here to help you stay safe online.");
        }

        static void Speak(string text)
        {
            synthesizer.Speak(text); // This the bot's way of talking to you.
        }

        static void GetUserName()
        {
            Console.Write("\nWhat's your name? ");
            userName = Console.ReadLine(); // Capture the user's name to make the interaction feel personal.
            Console.WriteLine($"\nNice to meet you, {userName}! How can I assist you today?");
            Speak($"Nice to meet you, {userName}. How can I assist you today?");
        }

        static void ChatLoop()
        {
            string input;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYou can ask me questions related to cybersecurity. Type 'exit' to leave.\n");
            Console.ResetColor();

            while (true)
            {
                Console.Write($"{userName}: ");
                input = Console.ReadLine().ToLower();

                if (input == "exit")
                {
                    // Friendly exit message to wrap up the conversation nicely.
                    Speak("Goodbye! Stay safe online.");
                    Console.WriteLine("\nGoodbye! Stay safe online.");
                    break;
                }

                RespondToInput(input);
            }
        }

        static void RespondToInput(string input)
        {
            string response = "";

            // This switch block is the brain of the bot where it tries to understand what you are asking.
            switch (true)
            {
                case bool _ when input.Contains("how are you"):
                    response = "I'm just a bunch of code, but I'm ready to help you!";
                    break;

                case bool _ when input.Contains("purpose"):
                    response = "I'm here to help you stay safe online by providing cybersecurity tips.";
                    break;

                case bool _ when input.Contains("password"):
                    response = "Use strong, unique passwords for each account. Avoid common words and consider using a password manager.";
                    break;

                case bool _ when input.Contains("phishing"):
                    response = "Phishing is when attackers trick you into revealing personal information. Avoid clicking on suspicious links or attachments.";
                    break;

                case bool _ when input.Contains("browsing") || input.Contains("safe browsing"):
                    response = "Always keep your browser updated, avoid suspicious websites, and use privacy tools like VPNs and ad blockers.";
                    break;

                case bool _ when input.Contains("malware"):
                    response = "Malware is harmful software designed to damage or gain unauthorized access to your system. Keep your antivirus software updated.";
                    break;

                case bool _ when input.Contains("social engineering"):
                    response = "Social engineering involves manipulating people to give up confidential information. Always verify identities and be cautious.";
                    break;

                case bool _ when input.Contains("encryption"):
                    response = "Encryption is the process of encoding data to prevent unauthorized access. It's essential for protecting sensitive information.";
                    break;

                case bool _ when input.Contains("multi-factor") || input.Contains("mfa"):
                    response = "MFA adds an extra layer of security by requiring two or more verification steps to access an account.";
                    break;

                case bool _ when input.Contains("ransomware"):
                    response = "Ransomware encrypts your files and demands payment for their release. Always back up your data and avoid clicking on suspicious links.";
                    break;

                case bool _ when input.Contains("firewall"):
                    response = "A firewall monitors and controls network traffic to protect your system from threats.";
                    break;

                case bool _ when input.Contains("vpn"):
                    response = "A VPN protects your privacy by encrypting your internet connection and masking your IP address.";
                    break;

                default:
                    response = "I'm sorry, I don't have information on that topic. Please ask another question.";
                    break;
            }

            Console.WriteLine($"CyberSpark: {response}");
            Speak(response); // The bot speaks its response, making the interaction feel more natural.
        }
    }
}


