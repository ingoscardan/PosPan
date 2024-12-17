using System.Text;

namespace Services.Extensions;

/// <summary>
/// Contains extension methods for strings to be use only within this project
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Creates a new utf-8 lowe case string. If the string contains multiple words it will join them with a dash
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToDashedNotation(this string str)
    {
        return str.ToLowerInvariant().ToDashedString();
    }
    
    /// <summary>
    /// Gets a string and return it with the words separated by a dash. It will remove any non digit or non letter that it finds
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToDashedString(this string str)
    {
        str = str.Trim();
        var charsArray = str.ToCharArray();
        var strBuilder = new StringBuilder();
        var i = 0;

        while (i < charsArray.Length)
        {
            var charToEval = charsArray[i];
            if (char.IsLetter(charToEval) || char.IsDigit(charToEval))
            {
                strBuilder.Append(charToEval);
                i++;
            }
            else
            {
                while (i < charsArray.Length && (!char.IsLetter(charToEval) && !char.IsDigit(charToEval)))
                {
                    charToEval = charsArray[++i];
                }

                strBuilder.Append('-');
            }
        }
        
        return strBuilder.ToString();
    }
}