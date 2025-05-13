using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;

namespace ChatBot3
{
    class Program
    {
        static SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        static string userName = "";

        static void Main(string[] args)
        {
            ConfigureVoice();
            DisplayAsciiImage();
            IntroduceChatbot();
            GetUserName();
            ChatLoop();
        }

        static void ConfigureVoice()
        {
            try
            {
                synthesizer.SelectVoice("Microsoft Hazel");
            }
            catch (Exception)
            {
                synthesizer.SelectVoiceByHints(VoiceGender.Female);
            }

            synthesizer.Rate = 1;
            synthesizer.Volume = 100;
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
 /  ************  \             (\o/)            (_,_)                   (_,_)
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
                userName = "CyberStar";
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
            string lowerInput = input.ToLower();

            // Definitions per topic
            Dictionary<string, string> definitions = new Dictionary<string, string>
            {
                { "phishing", "Phishing is a type of cyber attack where scammers trick you into giving away personal information, often through fake emails or websites." },
                { "vpn", "A VPN, or Virtual Private Network, encrypts your internet connection and masks your IP address to protect your privacy online." },
                { "malware", "Malware is malicious software designed to harm or exploit computers and networks." },
                { "firewall", "A firewall is a security system that monitors and controls incoming and outgoing network traffic based on security rules." },
                { "ransomware", "Ransomware is malware that locks or encrypts your data and demands payment to restore access." },
                { "mfa", "Multi-Factor Authentication (MFA) is a security system that requires more than one method of authentication to access an account." },
                { "encryption", "Encryption is the process of converting information into a code to prevent unauthorized access." },
                { "social engineering", "Social engineering is the use of manipulation to trick people into giving away confidential information." },
                { "password", "A password is a string of characters used to verify a user’s identity. Strong passwords are unique and hard to guess." },
                { "privacy", "Privacy refers to your ability to control how your personal information is collected and used online." },
                { "scam", "A scam is a dishonest scheme or fraud, often used to steal money or personal information." }
            };

            // Tips per topic
            Dictionary<string, List<string>> tipLists = new Dictionary<string, List<string>>
            {
                { "phishing", new List<string> {
                    "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.",
                    "Never click on suspicious links. Hover over them first to inspect the actual destination.",
                    "Look for typos or urgent language in emails — these are common signs of phishing attempts."
                }},
                { "vpn", new List<string> {
                    "Use a reputable VPN to secure your internet traffic, especially on public Wi-Fi.",
                    "Avoid free VPNs that may log your data or slow down your connection.",
                    "Always keep your VPN software updated for the latest security patches."
                }},
                { "malware", new List<string> {
                    "Install and regularly update antivirus software to detect malware early.",
                    "Don’t download files or software from untrusted websites.",
                    "Avoid clicking on suspicious links in emails or pop-up ads."
                }},
                { "firewall", new List<string> {
                    "Enable your device’s firewall to block unauthorized network access.",
                    "Configure firewall settings to allow only trusted apps.",
                    "Firewalls are especially useful when using public or untrusted networks."
                }},
                { "ransomware", new List<string> {
                    "Back up your files regularly to an offline location.",
                    "Do not click on suspicious links or attachments.",
                    "Keep your operating system and software up to date."
                }},
                { "mfa", new List<string> {
                    "Enable MFA on all your important accounts for added protection.",
                    "Use an authenticator app instead of SMS when possible.",
                    "MFA can stop attackers even if they steal your password."
                }},
                { "encryption", new List<string> {
                    "Encrypt sensitive files before uploading them to the cloud.",
                    "Use encrypted messaging apps like Signal for private conversations.",
                    "Enable full-disk encryption on your devices for better data protection."
                }},
                { "social engineering", new List<string> {
                    "Never give out personal info to unknown callers or emailers.",
                    "Verify identities before sharing sensitive data.",
                    "If something feels off, it probably is — trust your instincts."
                }},
                { "password", new List<string> {
                    "Use a mix of letters, numbers, and symbols in your passwords.",
                    "Never reuse the same password across multiple sites.",
                    "Consider using a password manager to keep track of strong passwords."
                }},
                { "privacy", new List<string> {
                    "Review app permissions and revoke access to what you don’t use.",
                    "Use privacy-focused browsers and search engines.",
                    "Disable location tracking unless absolutely necessary."
                }},
                { "scam", new List<string> {
                    "If it sounds too good to be true, it probably is.",
                    "Never share financial details over the phone or email unless you're certain it's secure.",
                    "Scammers often pressure you to act quickly — always take your time to verify."
                }}
            };

            // Check for definition vs tip
            foreach (var topic in definitions.Keys)
            {
                if (lowerInput.Contains(topic))
                {
                    if (lowerInput.Contains("what is") || lowerInput.StartsWith("define"))
                    {
                        response = definitions[topic];
                        goto RESPOND;
                    }

                    if (tipLists.ContainsKey(topic))
                    {
                        response = GetRandomResponse(tipLists[topic]);
                        goto RESPOND;
                    }
                }
            }

            response = "I'm sorry, I don't have information on that topic. Please ask another question.";

        RESPOND:
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("CyberSpark: ");
            TypeText(response);
            Speak(response);
            Console.ResetColor();
        }

        static string GetRandomResponse(List<string> responses)
        {
            Random rand = new Random();
            return responses[rand.Next(responses.Count)];
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
