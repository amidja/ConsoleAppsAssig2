using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assig2Task2
{
    class CipherProgram
    {
        private const int SHIFT_KEY = 3;

        static void Main(string[] args)
        {
            int userSelection = 0;
            CaesarCipher caesarCipher = new CaesarCipher(SHIFT_KEY);
            do {
                Console.Clear();

                userSelection = MainMenu(userSelection);

                switch (userSelection) 
                {
                    case 1: EncryptMenu(caesarCipher); break;
                    case 2: DecryptMenu(caesarCipher); break;
                }

            }while (userSelection != 3) ;
        }

        public static void EncryptMenu(CaesarCipher caesarCipher)
        {
            string userInput = "Yes";
            do
            {
                Console.Write("\tMessage to encrypt: ");
                userInput = Console.ReadLine();
                string encrypted = caesarCipher.Encrypt(userInput);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\tEncrypted message: {encrypted}");
                Console.ResetColor();

                Console.Write("Encrypt another message [Yes/No]: ");
                userInput = Console.ReadLine();


            } while (userInput.Equals("Yes", StringComparison.OrdinalIgnoreCase));

        }

        public static void DecryptMenu(CaesarCipher caesarCipher)
        {
            string userInput = "Yes";
            do
            {
                Console.Write("\tMessage to decrypt: ");
                userInput = Console.ReadLine();
                string encrypted = caesarCipher.Decrypt(userInput);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\tMessage: {encrypted}");
                Console.ResetColor();
                Console.Write("Decrypt another message [Yes/No]: ");
                userInput = Console.ReadLine();
            } while (userInput.Equals("Yes", StringComparison.OrdinalIgnoreCase));
        }

        public static int MainMenu(int previousSelection)
        {
            Console.WriteLine("Menu Selection");
            Console.WriteLine("\t(1) Encrypt a message");
            Console.WriteLine("\t(2) Decrypt a message");
            Console.WriteLine("\t(3) Exit");
            int selection = previousSelection;

            if (selection < 0)
                Console.WriteLine("Invalid selection provided!");
                       
            Console.Write("Please select one option [1-3]: ");
           
            try
            {
                selection = int.Parse(Console.ReadLine());
            }
            catch
            {
                selection = -1;
            }
            return selection;
        }
    }
}