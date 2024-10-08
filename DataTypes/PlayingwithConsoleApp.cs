namespace DataTypes;

using static Utils.IO;

public class PlayingwithConsoleApp
{
  public static string Play()
  {
    string favColor, astroSign, stAddrNum;

    favColor = Input(AskForMessage("favorite color"));
    astroSign = Input(AskForMessage("astrology sign"));
    stAddrNum = Input(AskForMessage("street address number"));

    var message = $"Your hacker name is {favColor}{astroSign}{stAddrNum}.";
    Console.WriteLine(message);

    return message;
  }
}
