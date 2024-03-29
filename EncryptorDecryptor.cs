﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1DP
{
    public class EncryptorDecryptor
    {
        public void Encrypt(string plainText, string[] cipherTextAlphabet, string[] plainTextAlphabet, uint shiftCoeff)
        {
            string filePath = "./encryptedText.txt";
            File.WriteAllText(filePath, string.Empty);
            StreamWriter writer = new(filePath);
            plainText = plainText.ToLower();
            string cipherText = string.Empty;
            for (int i = 0; i < plainText.Length; i++)
            {
                int codeSymPlain = Array.IndexOf(plainTextAlphabet, plainText[i].ToString());
                if (codeSymPlain >= 0)
                {
                    uint codeSymCipher = MathTools.CalcCodeSymCipherText(shiftCoeff, (uint)codeSymPlain, (uint)plainTextAlphabet.Length);
                    cipherText += cipherTextAlphabet[codeSymCipher];
                }
                else
                {
                    cipherText += plainText[i];
                }
            }
            writer.Write(cipherText);
            writer.Close();
        }

        public void Decrypt(string cipherText, string[] cipherTextAlphabet, string[] plainTextAlphabet, uint shiftCoeff)
        {
            string filePath = "./decryptedText.txt";
            File.WriteAllText(filePath, string.Empty);
            StreamWriter writer = new(filePath);
            cipherText = cipherText.ToLower();
            string plainText = string.Empty;
            bool isSyllable = false; // флаг слога
            string symbol = string.Empty;
            for (int i = 0; i < cipherText.Length; i++)
            {
                symbol = isSyllable ? symbol + cipherText[i].ToString() : cipherText[i].ToString();
                int codeSymCipher = Array.IndexOf(cipherTextAlphabet, symbol);
                if (codeSymCipher >= 0)
                {
                    uint codeSymPlain = MathTools.CalcCodeSymPlainText(shiftCoeff, (uint)codeSymCipher, (uint)cipherTextAlphabet.Length);
                    plainText += plainTextAlphabet[codeSymPlain];
                    isSyllable = false;
                }
                else if (plainTextAlphabet.Contains(symbol))
                {
                    isSyllable = true;
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
