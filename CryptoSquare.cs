using System;
using System.Collections.Generic;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        string normalizedPlainText = "";
        foreach (char letter in plaintext)
        {
            if(!char.IsPunctuation(letter))
            {
                normalizedPlainText += String.Join("", letter);
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
        return plaintextSegments;
    }

    public static string Encoded(string plaintext)
    {
        string[] textArray = {};
        IEnumerable<string> plaintextSegments = PlaintextSegments(plaintext);
        int row = 1;
        foreach (var text in plaintextSegments)
        {
            row++;
        }

        
        
    
    }


    public static string Ciphertext(string plaintext) => String.Join(" ",Encoded(plaintext));

}