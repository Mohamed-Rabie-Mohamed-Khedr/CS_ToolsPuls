using System.Text;
public static class StringProcessing
{
    /// <summary>
    /// Counts the occurrences of a specified string within another string.
    /// </summary>
    /// <param name="text">The text to search within.</param>
    /// <param name="value">The string to search for.</param>
    /// <returns>The number of occurrences of the specified string within the text.</returns>
    public static int Count(string text, string value)
    {
        int count = 0, start = 0, s = 0;
        while (true)
        {
            s = text.IndexOf(value, start);
            if (s != -1)
            {
                count++;
                start = s + value.Length;
            }
            else break;
        }
        return count;
    }

    /// <summary>
    /// Counts the occurrences of a specified character in the given text.
    /// </summary>
    /// <param name="text">The text in which to search for the character.</param>
    /// <param name="letter">The character to count occurrences of.</param>
    /// <returns>The number of occurrences of the specified character in the text.</returns>
    public static int Count(string text, char letter)
    {
        int count = 0;
        foreach (char c in text){ if (c == letter) count++; }
        return count;
    }

    /// <summary>
    /// Converts the input text into title case format.
    /// </summary>
    /// <param name="text">The text to be converted.</param>
    /// <returns>The input text in title case format.</returns>
    public static string ToTitleCase(string text)
    {
        StringBuilder Str = new StringBuilder(text.Length);
        bool firstLetter = true;
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                if (!firstLetter) Str.Append(c.ToString().ToLower());
                else
                {
                    Str.Append(c.ToString().ToUpper());
                    firstLetter = false;
                }
            }
            else
            {
                Str.Append(c);
                firstLetter = true;
            }
        }
        return Str.ToString();
    }
    
    public static void GetDigits(this string t, out string digits)
    {
        StringBuilder Str = new StringBuilder();
        foreach (char c in t) if (char.IsDigit(c)) Str.Append(c);
        digits = Str.ToString();
    }
    
    public static void GetDigits(this string t, out uint digits)
    {
        t += "?";
        uint Number = 0;
        StringBuilder valNumber = new StringBuilder();
        for (int i = 0; i < t.Length; i++)
        {
            if (char.IsDigit(t[i])) valNumber.Append(t[i]);
            else if (!valNumber.Equals(""))
            {
                Number = checked(Number + uint.Parse(valNumber.ToString()));
                valNumber.Clear();
            }
        }
        digits = Number;
    }
    
    public static void GetDigits(this string t, out double digits)
    {
        t += "?";
        double Number = 0;
        StringBuilder valNumber = new StringBuilder();
        bool dot = false;
        for (int i = 0; i < t.Length; i++)
        {
            if (char.IsDigit(t[i])) valNumber.Append(t[i]);
            else if (t[i] == '.' && !dot)
            {
                if (!valNumber.Equals(""))
                {
                    Number = checked(Number + double.Parse(valNumber.ToString()));
                    valNumber.Clear();
                }
                dot = true;
            }
            else if (!valNumber.Equals(""))
            {
                Number = checked(Number + double.Parse(dot ? "0." + valNumber.ToString() : valNumber.ToString()));
                valNumber.Clear();
            }
        }
        digits = Number;
    }
}