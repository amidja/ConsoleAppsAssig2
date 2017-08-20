using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assig2Task2
{
    class CaesarCipher
    {
        private const int NO_CHARS = 26;
        private const char START_CHAR = 'a';

        private int shiftKey;

        //Constructors
        // - - - - - - - - - - - - - - - - 
        public CaesarCipher(int shiftKey)
        {
            this.shiftKey = shiftKey;
        }

        //Properties 
        // - - - - - - - - - - - - - - - - 
        public int ShiftKey
        {
            get
            {
                return shiftKey;
            }
        }

        //Methods
        // - - - - - - - - - - - - - - - - 
        public string Encrypt(string plaintext)
        {
            try
            {
                plaintext = Normalize(plaintext);
            }
            catch (System.ArgumentException)
            {
                return "Invalid input provided";
            }
            
            string ciphertext = "";
            foreach (char ch in plaintext)
            {                
                char cipherch = (char)((((ch + ShiftKey) - START_CHAR) % NO_CHARS) + START_CHAR);
                ciphertext += cipherch;
            }
  
           return ciphertext;
        }

        public string Decrypt(string ciphertext)
        {
            try
            {
                ciphertext = Normalize(ciphertext);
            }
            catch (System.ArgumentException)
            {
                return "Invalid input provided";
            }

            string plaintext = "";
            foreach (char ch in ciphertext)
            {   
                char plainchar = (char)((((ch + (NO_CHARS - ShiftKey)) - START_CHAR) % NO_CHARS) + START_CHAR);
                plaintext += plainchar;
            }
            return plaintext;
        }

        //Remove spaces from the input, convert it to lowercase 
        // and perform some basic input validation
        private string Normalize(String text)
        {
            if (text == null || text.Length == 0)
            {
                throw new System.ArgumentException("Parameter cannot be empty or null", "text");
            }
   
            text = Regex.Replace(text, @"\s+", "");

            foreach (char ch in text)
            {
                if (!char.IsLetter(ch))
                {
                    throw new System.ArgumentException("Parameter can only contain letters", "text"); ;
                }
            }
            return text.ToLower();
        }
    }
}
