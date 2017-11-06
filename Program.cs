using System;
using IntelligentVacuum.Environments;
using IntelligentVacuum.Agent;
using IntelligentVacuum.Client;

namespace IntelligentVacuum
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int iXAxis = PromptForInt("Please enter the length of the X axis:");
                int iYAxis = PromptForInt("Please enter the length of the Y axis:");
                int rounds = PromptForInt("Please enter the number of rounds");
                var client = new Client.Client();
                client.Run(iXAxis, iYAxis, rounds);
            } while (PromptForBool("Keep playing? (y/n)"));
        }

        static string Prompt(string message, params object[] values)
        {
            Console.WriteLine(message, values);
            return Console.ReadLine();
        }

        static bool PromptForBool(string message, params object[] values)
        {
            bool? result = null;
            while (result == null)
            {
                char response = Prompt(message, values).ToLower()[0];
                if (response == 'y')
                {
                    result = true;
                }
                else if (response == 'n')
                {
                    result = false;
                }
            }
            return result.Value;
        }

        static int PromptForInt(string message, params object[] values)
        {
            int parsed;
            while(!int.TryParse(Prompt(message, values), out parsed));
            return parsed;
        }

        static void Pause(string message = "Press any key to continue...")
        {
            System.Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
