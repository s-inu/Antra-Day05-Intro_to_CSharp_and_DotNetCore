namespace Utils;

public class IO
{
  public static string Input(string prompt)
  {
    Console.Write($"{prompt}");
    return Console.ReadLine() ?? "";
  }
  public static string AskForMessage(string item)
  {
    return $"{item}?: ";
  }

  public static T[] InputArrByElements<T>(string prompt, Func<string, T> parser, char delimiter = ' ')
  {
    string input = Input(prompt);
    return input.Split(delimiter).Select(parser).ToArray();
  }

}
