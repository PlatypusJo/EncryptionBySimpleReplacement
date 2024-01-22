using System;
using System.IO;
using System.Text;

namespace Lab1DP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            uint decCoeff = 5;
            uint shiftCoeff = 7;
            string[] plainTextAlphabet = ["а", "б", "в", "г", "д", "е", "ж", "з", 
                                          "и", "к", "л", "м", "н", "о", "п", "р", 
                                          "с", "т", "у", "ф", "х", "ц", "ч", "ш", 
                                          "щ", "ъ", "ы", "ь", "э", "ю", "я", " ",];
            string[] cipherTextAlphabet = ["ме", "ли", "ко", "ин", "зе", "жу", "ню", "ою", 
                                           "пы", "ра", "су", "ти", "у", "хи", "от", "ца", 
                                           "чу", "ше", "ам", "ик", "ъ", "то", "ь", "ю", 
                                           "я", "ф", "ас", "бе", "за", "гу", "ди", "е",];

            MathTools.CreateTable(cipherTextAlphabet, plainTextAlphabet, shiftCoeff, decCoeff);

            string filePath;
            StreamReader reader;
            EncryptorDecryptor encryptorDecryptor = new EncryptorDecryptor();

            Console.WriteLine("Зашифровать - e\n Расшифровать - d\n Выйти - esc\n");
            ConsoleKey chosen = ConsoleKey.None;
            while (chosen != ConsoleKey.Escape)
            {
                chosen = Console.ReadKey().Key;
                
                if (chosen == ConsoleKey.E)
                {
                    Console.WriteLine("\nВведите путь к файлу, который хотите зашифровать: ");
                    filePath = Console.ReadLine();
                    reader = new StreamReader(filePath);
                    string text = reader.ReadToEnd();
                    encryptorDecryptor.Encrypt(text, cipherTextAlphabet, plainTextAlphabet, shiftCoeff, decCoeff);
                    reader.Close();
                    Console.WriteLine("Текст зашифрован.");
                }
                else if (chosen == ConsoleKey.D)
                {
                    Console.WriteLine("\nВведите путь к файлу, который хотите расшифровать: ");
                    filePath = Console.ReadLine();
                    reader = new StreamReader(filePath);
                    string text = reader.ReadToEnd();
                    encryptorDecryptor.Decrypt(text, cipherTextAlphabet, plainTextAlphabet, shiftCoeff, decCoeff);
                    reader.Close();
                    Console.WriteLine("Текст расшифрован.");
                }
            }
        }
    }
}