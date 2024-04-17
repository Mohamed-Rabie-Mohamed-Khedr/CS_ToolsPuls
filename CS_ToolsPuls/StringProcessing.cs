using System.Text;
/// <summary>
/// A static class for string processing containing extension methods to perform various string operations.
/// </summary>
public static class StringProcessing
{
    /// <summary>
    /// Counts the occurrences of a specified string within the current string.
    /// </summary>
    /// <param name="t">The current string.</param>
    /// <param name="value">The string to count.</param>
    /// <returns>The number of occurrences of the specified string.</returns>
    public static int ValueCount(this string t, string value)
    {
        int count = 0, start = 0, s = 0;
        while (true)
        {
            s = t.IndexOf(value, start);
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
    /// Counts the occurrences of a specified character within the current string.
    /// </summary>
    /// <param name="t">The current string.</param>
    /// <param name="value">The character to count.</param>
    /// <returns>The number of occurrences of the specified character.</returns>
    public static int ValueCount(this string t, char value)
    {
        int count = 0;
        foreach (char c in t){ if (c == value) count++; }
        return count;
    }

    /// <summary>
    /// Converts the current string to title case.
    /// </summary>
    /// <param name="t">The current string.</param>
    /// <returns>The string converted to title case.</returns>
    public static string ToTitleCase(this string t)
    {
        StringBuilder Str = new StringBuilder(t.Length);
        bool firstLetter = true;
        foreach (char c in t)
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
    /// Retrieves all digits from the current string.
    /// </summary>
    /// <param name="t">The current string.</param>
    /// <param name="digitAsString">Output parameter containing digits as a string.</param>
    public static void GetDigit(this string t, out string digitAsString)
    {
        StringBuilder Str = new StringBuilder();
        foreach (char c in t) if (char.IsDigit(c)) Str.Append(c);
        digitAsString = Str.ToString();
    }

    /// <summary>
    /// Retrieves a non-negative integer from the current string.
    /// </summary>
    /// <param name="t">The current string.</param>
    /// <param name="digitAsUint">Output parameter containing the non-negative integer.</param>
    public static void GetDigit(this string t, out uint digitAsUint)
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
        digitAsUint = Number;
    }

    /// <summary>
    /// Retrieves a floating-point number from the current string.
    /// </summary>
    /// <param name="t">The current string.</param>
    /// <param name="digitAsDouble">Output parameter containing the floating-point number.</param>
    public static void GetDigit(this string t, out double digitAsDouble)
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
        digitAsDouble = Number;
    }
}