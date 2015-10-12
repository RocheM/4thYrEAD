using System;

namespace Lab6
{

    public delegate string EncryptionDelegate(string toEncrypt, int shift);
    public delegate string EncryptionDelegate2(string toEncrypt);
    class Encryption
    {
        public static string ReverseText(string toEncrypt)
        {
            char[] reverseString = new char[toEncrypt.Length];

            int j = toEncrypt.Length;
            for (int i = 0; i < toEncrypt.Length; i++) { 
            
                reverseString[i] = toEncrypt[j -1];
                j--;
            }

            return new string(reverseString);
        }

        public static string CeasarCipher(string toEncrypt, int shift)
        {

            char[] workingStr = toEncrypt.ToCharArray();

            for (int i = 0; i < workingStr.Length; i++)
            {
                char current = workingStr[i];
                current = (char)(current + shift);

                if (current > 'z')
                {
                    current = (char) (current - 26);
                }
                else if (current < 'a')
                {
                    current = (char) (current + 26);
                }
                workingStr[i] = current;
            }
            

            return new string(workingStr);
        }

    }

    class Program
    {
        static void Main()
        {
            EncryptionDelegate delObj = Encryption.CeasarCipher;
            EncryptionDelegate2 delObj2 = Encryption.ReverseText;

            Console.WriteLine("Enter a sentence to Encrypt:");
            string toEncrypt = Console.ReadLine();

            Console.WriteLine("Enter a number to shift by:");
            int shift = Convert.ToInt32((Console.ReadLine()));

            Console.WriteLine("'{0}' shifted by {1} places is:\n", toEncrypt, shift);
            string cipher = delObj(toEncrypt, shift);
            Console.WriteLine(cipher);
            

            Console.WriteLine("Enter Text to Reverse:");
            toEncrypt = Console.ReadLine();

            cipher = delObj2(toEncrypt);
            Console.WriteLine(cipher);


            Console.ReadLine();

        }
    }
}