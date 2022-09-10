using System;
using System.Collections.Generic;

public static class CryptoSquare
{  
    public static string NormalizedPlaintext(string plaintext)
    {
        string normalizedPlainText = "";
        foreach (char letter in plaintext)
        {
            if (char.IsLetterOrDigit(letter))
            {
                normalizedPlainText += letter;
            }
        }
        return normalizedPlainText.ToLower();
    }

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        string normalizedPlainText = NormalizedPlaintext(plaintext);
        int textLength = normalizedPlainText.Length;
        int col = Convert.ToInt32(Math.Ceiling(Math.Sqrt(textLength)));
        int row = Convert.ToInt32(Math.Floor(Math.Sqrt(textLength)));
        int addSpace = (col * row) - textLength;
        string[] plaintextSegments = new string[row];
        if (addSpace > 0)
        {
            for (int i = 0; i < addSpace; i++)
            {
                normalizedPlainText += " ";
            }
        }
        for (int i = 0; i < row; i++)
        {
            plaintextSegments[i] = normalizedPlainText.Substring((i * col), col);
        }
        return plaintextSegments;
    }

    public static string Encoded(string plaintext)
    {
        IEnumerator<string> plainTextSegment = PlaintextSegments(plaintext).GetEnumerator();
        List<string> plainTextList = new List<string>();
        while (plainTextSegment.MoveNext())
        {
            plainTextList.Add(plainTextSegment.Current);
        }
        string[] textSegments = plainTextList.ToArray();
        string encoded = "";
        int col = textSegments.Length;
        int row = textSegments[0].Length;
        for (int c = 0; c < col + 1; c++)
        {
            for (int r = 0; r < row - 1; r++)
            {
                encoded += textSegments[r][c];
            }
            if(c < col)
            {
                encoded += " ";
            }
        }
        return encoded;
    }

    public static string Ciphertext(string plaintext) => Encoded(plaintext);

}