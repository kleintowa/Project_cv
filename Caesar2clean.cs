using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CaesarVerschlüsselung
{
    class Program
    {
        static public char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        static public string GetStringInput(string input)
        {
            input = input.ToLower();
            return input;
        }

        static public string Encoding(string option, string keyWord, string input)
        {
            StringBuilder outputBuild = new StringBuilder();
            int key = 0;

            for (int i = 0; i < input.Length; i++){
              //find key out of keyWord
                key = 1 + Array.IndexOf(alphabet, keyWord[i % keyWord.Length]);
                //is letter in word?
                bool inString = (alphabet.Contains(input[i]));
                if (inString)
                {
                    //search char in alphabet
                    int notEncoded = Array.IndexOf(alphabet, input[i]);
                    int encoded = 0;
                    //decode or encode?
                    if (option == "E")
                    {
                      encoded = notEncoded + key;//%
                    }
                    else if (option == "D"){
                      encoded = notEncoded - key;
                    }

                    if (encoded > 25)
                    {
                        encoded = (encoded - 25);
                    }
                    else if (encoded < 0)
                    {
                        encoded = (encoded + 25);
                    }

                    //search char with index +/-key
                    var codeObj = alphabet.GetValue(encoded);
                    char encodedLetter = Convert.ToChar(codeObj);
                    //write new char in output
                    outputBuild.Append(encodedLetter).Append("");
                } else
                {
                    //if not convertable, write original
                    outputBuild.Append(input[i]);
                }
            } string output = Convert.ToString(outputBuild);
            return output;
          }

        static void Main(string[] args)
        {
            string uppInput = null;
            string keyInput = null;

            Console.WriteLine("Do you want to encode(E) or decode(D) code?");
            string option = Console.ReadLine();
            option = option.ToUpper();

            if (option == "E")
            {
                Console.WriteLine("Please insert encodable text.");
                uppInput = Console.ReadLine();
                Console.WriteLine("Please insert key.");
                keyInput = Console.ReadLine();
                keyInput = keyInput.ToLower();
            }
            else if (option == "D")
            {
                Console.WriteLine("Please insert decodable text");
                uppInput = Console.ReadLine();
                Console.WriteLine("To decode text, please insert key.");
                keyInput = Console.ReadLine();
                keyInput = keyInput.ToLower();
            }
            else
            {
                Console.WriteLine("Please choose one of the given options");
            }
            string output = Encoding(option, keyInput, GetStringInput(uppInput));
                Console.WriteLine(//"Your input: " + stringInput
                   //+ "\nYour Key: " + intKey +
                    "\nYour output: " + output);
                Console.ReadKey();
        }
    }
}
