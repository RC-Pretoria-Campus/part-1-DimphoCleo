using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    class Program
    {
        static SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        static void Main(string[] args)
        {
            // Setting up the bot's voice. I'm aiming for Microsoft Susan, but if she's not available, any female voice will do.
            ConfigureVoice();

            // Showing off some ASCII art for a cool visual effect
            DisplayAsciiImage();

            // Let's introduce the bot to the user
            IntroduceChatbot();


            // Just keeping the console window open so the user can read the message
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void ConfigureVoice()
        {
            try
            {
                // Trying to use Microsoft Hazel. It might not work on all systems, so I’ll add a fallback.
                synthesizer.SelectVoice("Microsoft Hazel");
            }
            catch (Exception)
            {
                // If "Hazel" isn't available, we'll use any available female voice. Better safe than sorry.
                synthesizer.SelectVoiceByHints(VoiceGender.Female);
            }

            // Setting the voice to sound natural and clear.
            synthesizer.Rate = 1;  // Speed of speech, I prefer it not being too fast or too slow.
            synthesizer.Volume = 100;  // Maximum volume so it’s nice and clear.
        }

        static void IntroduceChatbot()
        {
            string botName = "CyberSpark";

            // Giving the console some color to make it look friendly and cool.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Hi there! I am {botName}, your friendly Cybersecurity Awareness Bot. I am here to help you stay safe online.");
            Console.ResetColor();

            // The bot should sound welcoming but also a little professional. Keeping it straightforward.
            Speak($"Hi there! I am {botName}, your Cybersecurity Awareness Bot. I am here to help you stay safe online.");
        }

        static void Speak(string text)
        {
            // Just speaking whatever text is passed in. Keeping this function simple.
            synthesizer.Speak(text);
        }

        static void DisplayAsciiImage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            // This is just a rough logo made out of text. I think it looks kind of cool.
            string asciiArt = @"
   (___________)
     |       |
  .-'  ^   ^  `-.
 /    (o) (o)    \        
|                 |      
|     '-----'     |         
 \_______________/ /  
    /         \   /        
   /           \ /       
  '-\-----------'         
  /  \_         \                             
 /               \     
'----|-------|----' 
     |_      |_
            ";

            Console.WriteLine(asciiArt);
            Console.ResetColor();
        }
    }
}
