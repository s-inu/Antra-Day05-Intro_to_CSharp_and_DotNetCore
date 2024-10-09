using System.Text.RegularExpressions;

namespace Utils;

public class Strings
{
  public static readonly char[] SEPARATORS = ['.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' '];
  public static readonly string SEPARATORS_CHARSET_PAT = @"[" + string.Join("", SEPARATORS.Select(c => c == ']' ? @"\]" : Regex.Escape(c.ToString()))) + "]";
  public static readonly string NON_SEPARATORS_CHARSET_PAT = @"[^" + string.Join("", SEPARATORS.Select(c => c == ']' ? @"\]" : Regex.Escape(c.ToString()))) + "]";
  public static bool IsPalindrome(string src)
  {
    return IsPalindrome(src, 0, src.Length - 1);
  }
  public static bool IsPalindrome(string src, int startIdx, int endIdx)
  {
    while (startIdx < endIdx)
    {
      if (src[startIdx] != src[endIdx]) { return false; }
      startIdx++;
      endIdx--;
    }

    return true;
  }
  public static string[] GetAllPalindromes(string src)
  {
    bool[,] palindromeTable = BuildPalindromeTable(src);
    List<string> ret = [];

    for (int i = 0; i < src.Length;)
    {
      for (int j = i; j < src.Length; j++)
      {
        if (palindromeTable[i, j])
        {
          ret.Add(src[i..(j + 1)]);
        }
      }
    }

    return [.. ret];
  }

  public static bool[,] BuildPalindromeTable(string src)
  {
    int n = src.Length;
    bool[,] dp = new bool[n, n];

    for (int i = 0; i < n; i++)
    {
      dp[i, i] = true;
    }

    for (int i = 0; i < n - 1; i++)
    {
      if (src[i] == src[i + 1])
      {
        dp[i, i + 1] = true;
      }
    }

    for (int len = 3; len <= n; len++)
    {
      for (int i = 0; i <= n - len; i++)
      {
        int j = i + len - 1;
        if (src[i] == src[j] && dp[i + 1, j - 1])
        {
          dp[i, j] = true;
        }
      }
    }

    return dp;
  }
}
