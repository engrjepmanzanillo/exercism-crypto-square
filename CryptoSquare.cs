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
        //check if the rectangle is less than perfect square of col
        if((col * row) < textLength)
        {
            row = row + 1;
        }
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
        for (int c = 0; c < row; c++)
        {
            for (int r = 0; r < col; r++)
            {
                encoded += textSegments[r][c];
            }
            if (c < row - 1 )
            {
                encoded += " ";
            }
        }
        return encoded;
    }

    public static string Ciphertext(string plaintext)
    {
        if(plaintext.Length > 0)
            return Encoded(plaintext);
        return "";
    }

}