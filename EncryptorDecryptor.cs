using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1DP
{
    public class EncryptorDecryptor
    {
        public void Encrypt(string plainText, string[] cipherTextAlphabet, string[] plainTextAlphabet, uint shiftCoeff, uint decCoeff)
        {
            string filePath = "./encryptedText.txt";
            File.WriteAllText(filePath, string.Empty);
            StreamWriter writer = new(filePath);
            plainText.ToLower();
            string cipherText = "";
            for (int i = 0; i < plainText.Length; i++)
            {
                int symCodePlainText = Array.IndexOf(plainTextAlphabet, plainText[i].ToString());
                if (symCodePlainText >= 0)
                {
                    uint symCodeCipherText = MathTools.CalcCodeSymCipherText(shiftCoeff, decCoeff, (uint)symCodePlainText, (uint)plainTextAlphabet.Length);
                    cipherText += cipherTextAlphabet[symCodeCipherText];
                }
                else
                {
                    cipherText += plainText[i];
                }
            }
            writer.Write(cipherText);
            writer.Close();
        }

        public void Decrypt(string cipherText, string[] cipherTextAlphabet, string[] plainTextAlphabet, uint shiftCoeff, uint decCoeff)
        {
            string filePath = "./decryptedText.txt";
            File.WriteAllText(filePath, string.Empty);
            StreamWriter writer = new StreamWriter(filePath);
            cipherText.ToLower();
            string plainText = "";
            bool isSyllable = false; // флаг слога
            string symbol = string.Empty;
            for (int i = 0; i < cipherText.Length; i++)
            {
                symbol = isSyllable ? symbol + cipherText[i].ToString() : cipherText[i].ToString();
                int symCodeCipherText = Array.IndexOf(cipherTextAlphabet, symbol);
                if (symCodeCipherText < 0 && plainTextAlphabet.Contains(symbol))
                {
                    isSyllable = true;
                }
                else if (symCodeCipherText >= 0)
                {
                    uint symCodePlainText = MathTools.CalcCodeSymPlainText(shiftCoeff, decCoeff, (uint)symCodeCipherText, (uint)cipherTextAlphabet.Length);
                    plainText += plainTextAlphabet[symCodePlainText];
                    isSyllable = false;
                }
                else
                {
                    plainText += cipherText[i];
                }
            }
            writer.Write(plainText);
            writer.Close();
        }
    }
}
