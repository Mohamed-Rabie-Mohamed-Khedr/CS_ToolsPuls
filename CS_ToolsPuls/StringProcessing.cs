public class StringProcessing
{
    /// <summary>
    /// Extracts all digits from a string and stores them as a string.
    /// </summary>
    /// <param name="text">The string to extract numbers from.</param>
    /// <param name="numbersAsStr">The output string containing only the digits from the input text.</param>
    public static void GetNumbers(string text, out string NumbersAsStr)
    {
        string Str = "";
        foreach (char c in text)
        {
            if (char.IsDigit(c)) Str += c;
        }
        NumbersAsStr = Str;
    }

    /// <summary>
    /// Extracts all digits from a string, converts them to a single integer, and stores the sum.
    /// </summary>
    /// <param name="text">The string to extract numbers from.</param>
    /// <param name="numbersAsInt">The output integer containing the sum of all digits extracted from the input text.</param>
    public static void GetNumbers(string text, out int NumbersAsInt)
    {
        text += "?";
        int Number = 0;
        string valNumber = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsDigit(text[i])) valNumber += text[i];
            else if (valNumber != "")
            {
                Number += int.Parse(valNumber);
                valNumber = "";
            }
        }
        NumbersAsInt = Number;
    }

    /// <summary>
    /// Extracts all digits from a string, converts them to a single double, and stores the sum.
    /// Considers decimal points and treats numbers after a point as decimals.
    /// </summary>
    /// <param name="text">The string to extract numbers from.</param>
    /// <param name="numbersAsDouble">The output double containing the sum of all digits and decimals extracted from the input text.</param>
    public static void GetNumbers(string text, out double NumbersAsDouble)
    {
        text += "?";
        double Number = 0;
        string valNumber = "";
        bool dot = false;
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsDigit(text[i])) valNumber += text[i];
            else if (text[i] == '.' && !dot)
            {
                if (valNumber != "")
                {
                    Number += double.Parse(valNumber);
                    valNumber = "";
                }
                dot = true;
            }
            else if (valNumber != "")
            {
                Number += double.Parse(dot ? "0." + valNumber : valNumber);
                valNumber = "";
            }
        }
        NumbersAsDouble = Number;
    }
}