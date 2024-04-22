using System.Text;
/// <summary>
/// A static class for string processing containing extension methods to perform various string operations.
/// </summary>
public static class StringProcessing
{
    /// <summary>
    /// Checks whether a string consists only of alphanumeric characters,
    /// with an option to ignore specified characters.
    /// </summary>
    /// <param name="t">The string to check.</param>
    /// <param name="ignoranceChars">Characters to ignore.</param>
    /// <returns>True if the string is alphanumeric; otherwise, false.</returns>
    public static bool IsAalphanumeric(this string t, params char[] ignoranceChars)
    {
        if (t.Length == 0) return false;
        foreach (char c in t)
        {
            if (!char.IsDigit(c) && !char.IsLetter(c))
            {
                for (int i = 0; i < ignoranceChars.Length; i++)
                {
                    if (c == ignoranceChars[i]) break;
                    else if (i == ignoranceChars.Length -1) return false;
                }
            }
        }
        return true;
    }
 
    /// <summary>
    /// Checks whether a string consists only of alphanumeric characters.
    /// </summary>
    /// <param name="t">The string to check.</param>
    /// <returns>True if the string is alphanumeric; otherwise, false.</returns>
    public static bool IsAalphanumeric(this string t)
    {
        if (t == string.Empty) return false;
        foreach (char c in t)
        {
            if (!char.IsDigit(c) && !char.IsLetter(c)) return false;
        }
        return true;
    }

    /// <summary>
    /// Centers a string within a specified number of padding characters.
    /// </summary>
    /// <param name="t">The string to center.</param>
    /// <param name="value">The padding character.</param>
    /// <param name="count">The number of padding characters on each side.</param>
    /// <returns>The centered string.</returns>
    public static string Center(this string t, char value, int count)
    {
        if (count < 1) return t;
        count *= 2;
        StringBuilder Str = new StringBuilder(t.Length + count);
        for (int i = 0; i < count; i++) Str.Append(value);
        Str.Insert(Str.Length / 2, t);
        return Str.ToString();
    }

    /// <summary>
    /// Centers a string within a specified number of padding characters.
    /// </summary>
    /// <param name="t">The string to center.</param>
    /// <param name="value">The padding string.</param>
    /// <param name="count">The number of times the padding string should be added on each side.</param>
    /// <returns>The centered string.</returns>
    public static string Center(this string t, string value, int count)
    {
        if (count < 1) return t;
        count *= 2;
        StringBuilder Str = new StringBuilder(t.Length + value.Length * count);
        for (int i = 0; i < count; i++) Str.Append(value);
        Str.Insert(Str.Length / 2, t);
        return Str.ToString();
    }

    /// <summary>
    /// Counts the occurrences of a specified string within the current string, using a specified string comparison option.
    /// </summary>
    /// <param name="t">The current string.</param>
    /// <param name="value">The string to count.</param>
    /// <param name="comparison">The string comparison option to use (default is StringComparison.Ordinal).</param>
    /// <returns>The number of occurrences of the specified string.</returns>
    public static int ValueCount(this string t, string value, StringComparison comparison = StringComparison.Ordinal)
    {
        int count = 0, start = 0, s = 0;
        while (true)
        {
            s = t.IndexOf(value, start, comparison);
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