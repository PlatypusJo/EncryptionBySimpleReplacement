using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1DP
{
    public static class MathTools
    {
        public static uint InverseValue(uint value, uint mod)
        {
            uint a, b, x1, x2, x;
            a = mod;
            b = value;
            x1 = 1;
            x2 = 0;
            while (b > 1)
            {
                x = (x2 - (a / b * x1));
                x2 = x1;
                x1 = x;
                x = (a % b);
                a = b;
                b = x;
            }
            value = (x1 + mod) % mod;
            return value;
        }

        public static uint CalcCodeSymCipherText(uint shiftCoeff, uint decCoeff, uint codeSymPlain, uint alphabetSize) => (decCoeff * codeSymPlain + shiftCoeff) % alphabetSize;

        public static uint CalcCodeSymPlainText(uint shiftCoeff, uint decCoeff, uint codeSymCipher, uint alphabetSize) => InverseValue(decCoeff, alphabetSize) * (codeSymCipher - shiftCoeff) % alphabetSize;

        public static void CreateTable(string[] cipherTextAlphabet, string[] plainTextAlphabet, uint shiftCoeff, uint decCoeff)
        {
            string[] buf = new string[cipherTextAlphabet.Length];
            Array.Copy(cipherTextAlphabet, buf, cipherTextAlphabet.Length);
            for (int i = 0; i < plainTextAlphabet.Length; i++)
            {
                uint codeSym = CalcCodeSymCipherText(shiftCoeff, decCoeff, (uint)i, (uint)plainTextAlphabet.Length);
                cipherTextAlphabet[codeSym] = buf[i];
            }
        }
    }
}
