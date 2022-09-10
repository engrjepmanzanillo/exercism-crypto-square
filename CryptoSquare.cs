using System;
using System.Collections.Generic;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        string normalizedPlainText = "";
        foreach (char letter in plaintext)
        {
            if(char.IsLetterOrDigit(letter))
            {
                normalizedPlainText += letter;
            }
        }
        return normalizedPlainText.ToLower();
        
    }

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        List<string> plaintextSegments = new List<string>();
        string normalizedPlainText = NormalizedPlaintext(plaintext);
        int textLength = normalizedPlainText.Length;
        int col = Convert.ToInt32(Math.Ceiling(Math.Sqrt(textLength)));
        int row = Convert.ToInt32(Math.Floor(Math.Sqrt(textLength)));
        int addSpace = (col * row) - textLength;
        if (addSpace > 0)
        {
            for (int i = 0; i < addSpace; i++)
            {
                normalizedPlainText += " ";
            }
            if (row * col >= textLength && col >= row)
            {
                for (int i = 0; i < col; i++)
                {
                    plaintextSegments.Add(normalizedPlainText.Substring((i * row), col));
                }
            }
        }
        return plaintextSegments;
    }

    public static string Encoded(string plaintext)
    {
        List<string> textList = new List<string>();
        List<char> charList = new List<char>();
        IEnumerable<string> plaintextSegments = PlaintextSegments(plaintext);
        int col = 0;
        foreach (var text in plaintextSegments)
        {
            textList.Add(text);
            col++;
        }
        string[] textArray = textList.ToArray();
        int row = textArray[0].Length;
        string encodedText = "";
        int index = 0;
        for (int r = 0; r < col; r++)
        {
            for (int c = r; c < row; c++)
            {
                encodedText += textArray[r][c].ToString();
                index++;
            }
        }
        return encodedText;

        
    }


    public static string Ciphertext(string plaintext) 
    {
                return Encoded(plaintext);
    }

}