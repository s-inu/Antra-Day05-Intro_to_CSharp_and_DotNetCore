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

}
