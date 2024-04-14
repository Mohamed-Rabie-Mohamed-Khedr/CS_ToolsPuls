using System.Text;
public class StringProcessing
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
                start = s + value.Length - 1;
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

    /// <summary>
    /// Extracts numeric digits from the given text and returns them as a string.
    /// </summary>
    /// <param name="text">The text from which to extract numeric digits.</param>
    /// <returns>A string containing only the numeric digits found in the text.</returns>
    public static string GetDigits(string text)
    {
        StringBuilder Str = new StringBuilder();
        foreach (char c in text) if (char.IsDigit(c)) Str.Append(c);
        return Str.ToString();
    }

    /// <summary>
    /// Parses the numeric digits from the given text and returns their summation as an unsigned integer.
    /// </summary>
    /// <param name="text">The text containing numeric digits.</param>
    /// <returns>The summation of numeric digits found in the text as an unsigned integer.</returns>
    public static uint GetDigitsAsUint(string text)
    {
        text += "?";
        uint Number = 0;
        StringBuilder valNumber = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsDigit(text[i])) valNumber.Append(text[i]);
            else if (!valNumber.Equals(""))
            {
                Number += uint.Parse(valNumber.ToString());
                valNumber.Clear();
            }
        }
        return Number;
    }

    /// <summary>
    /// Parses numeric values from the given text and returns their summation as a double.
    /// </summary>
    /// <param name="text">The text containing numeric values.</param>
    /// <returns>The summation of numeric values found in the text as a double.</returns>
    public static double GetDigitsAsDouble(string text)
    {
        text += "?";
        double Number = 0;
        StringBuilder valNumber = new StringBuilder();
        bool dot = false;
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsDigit(text[i])) valNumber.Append(text[i]);
            else if (text[i] == '.' && !dot)
            {
                if (!valNumber.Equals(""))
                {
                    Number += double.Parse(valNumber.ToString());
                    valNumber.Clear();
                }
                dot = true;
            }
            else if (!valNumber.Equals(""))
            {
                Number += double.Parse(dot ? "0." + valNumber.ToString() : valNumber.ToString());
                valNumber.Clear();
            }
        }
        return Number;
    }
}