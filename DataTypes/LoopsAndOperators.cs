namespace DataTypes;

using Microsoft.VisualBasic;
using static Utils.IO;

public class LoopsAndOperators
{
  public static void FizzBuzz()
  {
    for (int i = 1; i <= 100; i++)
    {
      Console.WriteLine($"{EvalFizzBuzz(i)}");
    }
  }

  private static bool IsFizz(int n) { return n % 3 == 0; }
  private static bool IsBuzz(int n) { return n % 5 == 0; }
  private static bool IsFizzBuzz(int n) { return IsFizz(n) && IsBuzz(n); }

  private static string EvalFizzBuzz(int n)
  {
    if (IsFizzBuzz(n)) { return "fizzbuzz"; }
    else if (IsFizz(n)) { return "fizz"; }
    else if (IsBuzz(n)) { return "buzz"; }

    return n.ToString();
  }

  public static void GuessNumber()
  {
    string HIGH_PROMPT, LOW_PROMPT, CORRECT_PROMPT;
    HIGH_PROMPT = "too high";
    LOW_PROMPT = "too low";
    CORRECT_PROMPT = "BINGO";

    int randomInt = new Random().Next(3) + 1;

    while (true)
    {
      int guess = int.Parse(Input(AskForMessage("An integer between 1 and 3, inclusively")));

      if (guess == randomInt)
      {
        Console.WriteLine($"{CORRECT_PROMPT}");
        break;
      }

      if (guess < randomInt)
      {
        Console.WriteLine($"{LOW_PROMPT}");
      }
      else
      {
        Console.WriteLine($"{HIGH_PROMPT}");
      }
    }
  }


  public static void PrintAPyramid(int maxLevel = 5)
  {
    for (int curLv = 1; curLv <= maxLevel; curLv++)
    {
      int starCount, totalWidth;
      starCount = (curLv - 1) * 2 + 1;
      totalWidth = maxLevel + curLv - 1;

      string line = new string('*', starCount).PadLeft(totalWidth);

      Console.WriteLine($"{line}");
    }
  }

  public static void DOB(int year = 1990, int month = 8, int day = 31)
  {
    DateTime dob = new DateTime(year: year, month: month, day: day);
    DateTime today = DateTime.Today;

    int daysOld = (today - dob).Days;
    Console.WriteLine($"You are {daysOld} days old.");

    int daysToNextAnniversary = 10_000 - (daysOld % 10_000);
    Console.WriteLine($"Days until the next 10,000 day anniversary: {daysToNextAnniversary}");

    DateTime nextAnniversaryDate = today.AddDays(daysToNextAnniversary);
    Console.WriteLine($"Your next 10,000 day anniversary will be on: {nextAnniversaryDate:MM/dd/yyyy}");
  }

  public static void Greeting(DateTime? time = null)
  {
    if (!time.HasValue) { time = DateTime.Now; }

    int hour = time.Value.Hour;

    if (IsInRange(hour, 0, 6)) { Console.WriteLine("Good Night"); return; }
    if (IsInRange(hour, 6, 12)) { Console.WriteLine("Good Morning"); return; }
    if (IsInRange(hour, 12, 18)) { Console.WriteLine("Good Afternoon"); return; }
    if (IsInRange(hour, 18, 24)) { Console.WriteLine("Good Evening"); return; }
  }

  private static bool IsInRange(int target, int start, int end)
  {
    return target >= start && target < end;
  }

  public static void CountUpTo24()
  {
    string DELIMITER = ",";

    for (int inc = 1; inc <= 4; inc++)
    {
      for (int cur = 0; cur <= 24; cur += inc)
      {
        Console.Write($"{cur}{(cur != 24 ? DELIMITER : "")}");
      }
      Console.WriteLine();
    }
  }
}
