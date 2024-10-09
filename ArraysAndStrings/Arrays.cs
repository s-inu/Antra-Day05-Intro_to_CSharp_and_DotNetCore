namespace ArraysAndStrings;

using System.Data;
using static Utils.Arrays;
using static Utils.IO;
using static Utils.Lists;
public class Arrays
{
  public static T[] CopyAnArray<T>(T[] srcArr)
  {
    T[] newArr = new T[srcArr.Length];

    for (int i = 0; i < srcArr.Length; i++)
    {
      newArr[i] = srcArr[i];
    }

    Console.WriteLine("Original Array:");
    PrintArr(srcArr);
    Console.WriteLine("Copied Array:");
    PrintArr(newArr);

    return newArr;
  }

  public static void ToDoList()
  {
    List<string> items = [];

    while (true)
    {
      string input = Input("Enter command (+ item, - item, or -- to clear):");

      Command command = ParseInput(input, out string? data);

      switch (command)
      {
        case Command.Add:
          if (!string.IsNullOrEmpty(data))
          {
            if (items.Contains(data))
            {
              Console.WriteLine($"Item already exists: {data}");
            }
            else
            {
              items.Add(data);
              Console.WriteLine($"Added: {data}");
            }
          }
          break;
        case Command.Remove:
          if (!string.IsNullOrEmpty(data) && items.Remove(data))
          {
            Console.WriteLine($"Removed: {data}");
          }
          else
          {
            Console.WriteLine($"Item not found: {data}");
          }
          break;
        case Command.Clear:
          items.Clear();
          Console.WriteLine("List cleared.");
          break;
        case Command.Invalid:
          Console.WriteLine("Invalid command. Please use + item to add, - item to remove, or -- to clear.");
          break;
      }

      Console.WriteLine("Current List:");
      foreach (var item in items)
      {
        Console.WriteLine(item);
      }
    }
  }

  private enum Command
  {
    Add,
    Remove,
    Clear,
    Invalid
  }

  private static Command ParseInput(string input, out string? data)
  {
    input = input.Trim();

    if (input == "--")
    {
      data = null;
      return Command.Clear;
    }
    else if (input.StartsWith('+'))
    {
      data = input[1..].Trim();
      return Command.Add;
    }
    else if (input.StartsWith('-'))
    {
      data = input[1..].Trim();
      return Command.Remove;
    }

    else
    {
      data = null;
      return Command.Invalid;
    }
  }

  public static int[] PrimeNumbers(int startNum, int endNum)
  {
    List<int> primes = [];
    for (int num = startNum; num <= endNum; num++)
    {
      if (IsPrime(num))
      {
        primes.Add(num);
      }
    }
    return [.. primes];
  }

  private static bool IsPrime(int n)
  {
    if (n <= 1) { return false; }
    if (n == 2) { return true; }
    if (n % 2 == 0) { return false; }

    for (int i = 3; i <= (int)Math.Sqrt(n); i += 2)
    {
      if (n % i == 0) { return false; }
    }

    return true;
  }

  public static int[] RotateAndSum(int[] arr, int k)
  {
    string rotation_input = Input(AskForMessage("How many times will the array be rotated?"));

    int[] sum = new int[arr.Length];
    for (int r = 1; r <= k; r++)
    {
      for (int i = 0; i < sum.Length; i++)
      {
        sum[(i + r) % arr.Length] += arr[i];
      }
    }

    PrintArrElements(sum, delimiter: ',');
    return sum;
  }

  public static int[] LongestSequence(int[] arr)
  {
    int longestStart, longestEnd;
    longestStart = longestEnd = 0;

    int i = 0;
    while (i < arr.Length)
    {
      int j = i;
      while (j < arr.Length && arr[j] == arr[i])
      {
        j++;
      }

      if (j - i > longestEnd - longestStart)
      {
        longestStart = i;
        longestEnd = j;
      }

      i = j;
    }

    int[] longestSeq = arr[longestStart..longestEnd];

    PrintArrElements(longestSeq, delimiter: ',');
    return longestSeq;
  }

  public static int MostFreqNumber(int[] arr, out int freq)
  {
    var frequency = GetFrequencyDict(arr);

    int maxFreq = frequency.Values.Max(v => v.Freq);
    var maxFreqNumbers = frequency.Where(f => f.Value.Freq == maxFreq)
                                  .OrderBy(f => f.Value.FirstIdx)
                                  .Select(f => f.Key)
                                  .ToList();

    if (maxFreqNumbers.Count == 1)
    {
      Console.WriteLine($"The number {maxFreqNumbers.First()} "
                        + $"is the most frequent "
                        + $"(occurs {maxFreq} {(maxFreq > 1 ? "times" : "time")})"
                        );
    }
    else
    {
      Console.WriteLine($"The numbers {FormatListElementsSorted(maxFreqNumbers)} "
                        + $"have the same maximal frequency "
                        + $"(each occurs {maxFreq} {(maxFreq > 1 ? "times" : "time")}). "
                        + $"The leftmost of them is {maxFreqNumbers.First()}."
                        );
    }

    freq = maxFreq;
    return maxFreqNumbers.First();
  }
}
