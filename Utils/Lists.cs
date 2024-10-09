namespace Utils;

public class Lists
{
  public static string FormatListElementsSorted<T>(List<T> ls)
  {
    string NULL = "[null]";

    ls = [.. ls];
    ls.Sort();

    if (ls == null || ls.Count == 0) { return ""; }
    if (ls.Count == 1) { return ls[0]?.ToString() ?? NULL; }

    string allButLast = string.Join(", ", ls[0..^1]
                              .Select(n => n?.ToString() ?? NULL));
    string last = ls[^1]?.ToString() ?? NULL;

    return $"{allButLast} and {last}";
  }
}
