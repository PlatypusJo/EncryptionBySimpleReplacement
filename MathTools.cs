using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1DP
{
    public static class MathTools
    {
        public static ushort InverseValue(ushort value)
        {
            ushort a, b, x1, x2, x;
            a = ushort.MaxValue;
            b = value;
            x1 = 1;
            x2 = 0;
            while (b > 1)
            {
                x = (ushort)(x2 - (a / b * x1));
                x2 = x1;
                x1 = x;
                x = (ushort)(a % b);
                a = b;
                b = x;
            }
            value = (ushort)((x1 + ushort.MaxValue) % ushort.MaxValue);
            return value;
        }

        public static uint CalcCodeSymCipherText(uint shiftCoeff, uint decCoeff, uint codeSymPlainText, uint alphabetSize) => (decCoeff * codeSymPlainText + shiftCoeff) % alphabetSize;

        public static uint CalcCodeSymPlainText(uint shiftCoeff, uint decCoeff, uint codeSymCipherText, uint alphabetSize) => (uint)InverseValue((ushort)decCoeff) * (codeSymCipherText - shiftCoeff) % alphabetSize;

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
