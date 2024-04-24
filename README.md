This is a library that provides a set of useful functions for C# developers.

This class, named `StringProcessing`, is a collection of static methods for processing strings in various ways. Here's a description of each method:

1. **SwapCase**: This method swaps the case of each alphabetic character in a string, converting uppercase characters to lowercase and vice versa.

2. **IsAlphanumeric**: This method checks whether a string consists only of alphanumeric characters, with an option to ignore specified characters.

3. **Center**: This method centers a string within a specified number of padding characters, either a single character or a string, on each side.

4. **ValueCount (string)**: This method counts the occurrences of a specified string within the current string, using a specified string comparison option.

5. **ValueCount (char)**: This method counts the occurrences of a specified character within the current string.

6. **IsTitle**: This method checks if the input string follows the title case format.

7. **ToTitleCase**: This method converts the current string to title case.

8. **GetDigit (out string)**: This method retrieves all digits from the current string and outputs them as a string.

9. **GetDigit (out uint)**: This method retrieves a non-negative integer from the current string and outputs it as an unsigned integer.

10. **GetDigit (out double)**: This method retrieves a floating-point number from the current string and outputs it as a double.

Each method is thoroughly documented with XML comments, providing information about its purpose, parameters, and return values. Additionally, the methods are designed to handle various scenarios, such as ignoring specific characters, handling different types of padding, and parsing digits or numbers from strings.
