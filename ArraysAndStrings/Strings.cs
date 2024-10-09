namespace ArraysAndStrings;
using System.Text.RegularExpressions;
using static Utils.Strings;
using static Utils.Arrays;
public partial class Strings
{
  public static string ReverseInputCharArrImpl(string src)
  {
    var charArr = src.ToCharArray();

    Array.Reverse(charArr);

    var ret = new string(charArr);
    Console.WriteLine($"{ret}");

    return ret;
  }
  public static string ReverseInputBackWardIdxImpl(string src)
  {
    for (int i = src.Length - 1; i >= 0; i--)
    {
      Console.Write(src[i]);
    }

    return new string(src.Reverse().ToArray());
  }


  public static string ReverseWords(string src)
  {
    string wordPattern = $"{NON_SEPARATORS_CHARSET_PAT}+";
    string[] words = Regex.Matches(src, wordPattern)
                              .Cast<Match>()
                              .Select(match => match.Value)
                              .Reverse()
                              .ToArray();

    int i = 0;
    string ret = Regex.Replace(src, wordPattern, m => words[i++]);

    Console.WriteLine($"{ret}");
    return ret;
  }

  public static string[] ExtractUniqueSortedPalindromes(string src)
  {
    string[] words = src.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);

    var uniqueSortedPalindromes = words.Where(IsPalindrome)
                                        .Distinct()
                                        .OrderBy(word => word)
                                        .ToArray();

    PrintArrElements(uniqueSortedPalindromes, delimiter: ", ");
    return uniqueSortedPalindromes;
  }

  public static void ParseURL(string URL, out string protocol, out string server, out string resource)
  {
    Regex regex = MyRegex();
    Match match = regex.Match(URL);

    if (match.Success)
    {
      protocol = match.Groups["protocol"].Value;
      server = match.Groups["server"].Value;
      resource = match.Groups["resource"].Value;

      Console.WriteLine($"{URL}");
      Console.WriteLine($"[protocol] = \"{protocol}\"");
      Console.WriteLine($"[server] = \"{server}\"");
      Console.WriteLine($"[resource] = \"{resource}\"");
      Console.WriteLine();
    }
    else
    {
      protocol = string.Empty;
      server = string.Empty;
      resource = string.Empty;

      Console.WriteLine("Failed to parse URL: " + URL);
    }
  }

  [GeneratedRegex(@"^(?:(?<protocol>\w+)://)?(?<server>[^/]+)(?:/(?<resource>.*))?$")]
  private static partial Regex MyRegex();
}
