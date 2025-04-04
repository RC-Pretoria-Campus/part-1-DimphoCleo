using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBot3
{
    class Program
    {
        // Text-to-speech synthesizer
        static SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        // Stores the user's name
        static string userName = "";

        static void Main(string[] args)
        {
            ConfigureVoice();      // Set up the bot's voice
            DisplayAsciiImage();    // Display a welcoming ASCII art
            IntroduceChatbot();     // Friendly introduction
            GetUserName();          // Ask for user's name
            ChatLoop();             // Start the chat loop
        }

        static void ConfigureVoice()
        {
            try
            {
                synthesizer.SelectVoice("Microsoft Hazel"); // Attempt to set voice to 'Hazel'
            }
            catch (Exception)
            {
                synthesizer.SelectVoiceByHints(VoiceGender.Female); // Default to a female voice if 'Hazel' is unavailable
            }

            synthesizer.Rate = 1;    // Normal speech rate
            synthesizer.Volume = 100; // Maximum volume
        }

        static void DisplayAsciiImage()
        {
            DisplaySectionHeader("Welcome to CyberSpark");

            Console.ForegroundColor = ConsoleColor.Magenta;
            string asciiArt = @"
  |*\_/*|________     (\o/)                  _( )_                                         _ 
 ||_/-\_|______  |    (/|\)                 (_ o _)                                      _( )_ 
 | |           | |          / ____|    |     (_,_)     / ____|                | |       (_ o _)
 | |   0   0   | |         | |    _   _| |__   ___ _ _| (___  _ __   __ _ _ __| | __     (_,_) 
 | |     -     | |         | |   | | | | '_ \ / _ \ '__\___ \| '_ \ / _` | '__| |/ /
 | |   \___/   | |         | |___| |_| | |_) |  __/ |  ____) | |_) | (_| | |  |   < 
 | |___________| |          \_____\__, |_.__/ \___|_| |_____/| .__/ \__,_|_|  |_|\_\
 |_______________|                 __/ |           _         | |                   (\o/)
    _|________|_                  |___/          _( )_       |_|            _      (/|\)    
   / ********** \                               (_ o _)                   _( )_     
 /  ************  \             (\o/)            (_,_)                   (_ o _)
--------------------            (/|\)                                     (_,_)
       ";
            Console.WriteLine(asciiArt);
            Console.ResetColor();
        }

        static void IntroduceChatbot()
        {
            DisplaySectionHeader("Introduction");

            string botName = "CyberSpark";
            TypeText($"Hello! I am {botName}, your friendly cybersecurity awareness assistant. ");
            Speak($"Hello! I am {botName}, your friendly cybersecurity awareness assistant.");
            TypeText("I'm here to help you stay safe and smart online. Let's make sure your digital life is secure!\n");
        }

        static void Speak(string text)
        {
            try
            {
                synthesizer.SpeakAsync(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during speech synthesis: " + ex.Message);
            }
        }

        static void GetUserName()
        {
            TypeText("\nMay I ask what your name is? ");
            Speak("May I ask what your name is?");
            userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "CyberStar"; // Default name if none provided
            }

            TypeText($"\nNice to meet you, {userName}! How can I assist you today?");
            Speak($"Nice to meet you, {userName}. How can I assist you today?");
        }

        static void ChatLoop()
        {
            DisplaySectionHeader("Chat Mode Activated");

            string input;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{userName}: ");
                Console.ResetColor();
                input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(input))
                {
                    TypeText("CyberSpark: I didn’t quite understand that. Could you rephrase?");
                    Speak("I didn’t quite understand that. Could you rephrase?");
                    continue;
                }

                if (input == "exit")
                {
                    TypeText("CyberSpark: Are you sure you want to exit? (yes/no)");
                    Speak("Are you sure you want to exit?");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{userName}: ");
                    string confirmation = Console.ReadLine()?.Trim().ToLower();
                    Console.ResetColor();

                    if (confirmation == "yes")
                    {
                        TypeText("CyberSpark: Goodbye! Stay safe and awesome online. ");
                        Speak("Goodbye! Stay safe and awesome online.");
                        break;
                    }
                    else
                    {
                        TypeText("CyberSpark: Great! I'm glad you're staying. How can I help you?");
                        Speak("Great! I'm glad you're staying. How can I help you?");
                    }
                }
                else
                {
                    RespondToInput(input);
                }
            }
        }

        static void RespondToInput(string input)
        {
            string response;
            // This switch block is the brain of the bot where it tries to understand what you are asking.
            switch (true)
            {
                case bool _ when input.Contains("how are you"):
                    response = "I'm just a friendly bot, running smoothly and ready to help you! ";
                    break;

                case bool _ when input.Contains("purpose"):
                    response = "I'm here to help you stay safe online by providing reliable cybersecurity advice.";
                    break;

                case bool _ when input.Contains("password"):
                    response = "Use strong, unique passwords for each account. A password manager can help you keep track of them.";
                    break;

                case bool _ when input.Contains("phishing"):
                    response = "Phishing attacks are attempts to trick you into giving away personal information. Be cautious with suspicious links or attachments.";
                    break;

                case bool _ when input.Contains("browsing") || input.Contains("safe browsing"):
                    response = "Always keep your browser updated, avoid suspicious websites, and use privacy tools like VPNs and ad blockers.";
                    break;

                case bool _ when input.Contains("malware"):
                    response = "Malware is harmful software that can damage your system. Always keep your antivirus software updated.";
                    break;

                case bool _ when input.Contains("firewall"):
                    response = "A firewall helps protect your system by monitoring and filtering incoming and outgoing network traffic.";
                    break;

                case bool _ when input.Contains("encryption"):
                    response = "Encryption secures your data by converting it into a code, making it unreadable without the proper key.";
                    break;

                case bool _ when input.Contains("social engineering"):
                    response = "Social engineering is manipulating people into revealing confidential information. Always verify identities before sharing sensitive details.";
                    break;

                case bool _ when input.Contains("vpn"):
                    response = "A VPN protects your privacy by encrypting your internet connection and masking your IP address.";
                    break;


                case bool _ when input.Contains("multi-factor") || input.Contains("mfa"):
                    response = "MFA adds an extra layer of security by requiring two or more verification steps to access an account.";
                    break;

                case bool _ when input.Contains("ransomware"):
                    response = "Ransomware encrypts your files and demands payment for their release. Always back up your data and avoid clicking on suspicious links.";
                    break;

                default:
                    response = "I'm sorry, I don't have information on that topic. Please ask another question.";
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("CyberSpark: ");
            TypeText(response);
            Speak(response);
            Console.ResetColor();
        }

        static void TypeText(string text, int delay = 20)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        static void DisplaySectionHeader(string header)
        {
            DisplayDivider();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n>>> {header.ToUpper()} <<<\n");
            Console.ResetColor();
            DisplayDivider();
        }

        static void DisplayDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n===============================================================================================================\n");
            Console.ResetColor();
        }
    }
}
