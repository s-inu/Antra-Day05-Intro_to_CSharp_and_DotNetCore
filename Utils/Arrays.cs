namespace Utils;

public class Arrays
{
  public static string ArrToString<T>(T[] arr, char delimiter = ',')
  {
    return string.Join(delimiter, arr);
  }
  public static string ArrToString<T>(T[] arr, string delimiter = ",")

  {
    return string.Join(delimiter, arr);
  }

  public static void PrintArr<T>(T[] arr)
  {
    Console.WriteLine($"[{ArrToString(arr, delimiter: ',')}]");
  }

  public static void PrintArrElements<T>(T[] arr, char delimiter = ' ')
  {
    Console.WriteLine($"{ArrToString(arr, delimiter)}");
  }

  public static void PrintArrElements<T>(T[] arr, string delimiter = " ")
  {
    Console.WriteLine($"{ArrToString(arr, delimiter)}");
  }

  public static Dictionary<T, (int Freq, int FirstIdx)> GetFrequencyDict<T>(T[] arr) where T : notnull
  {
    Dictionary<T, (int Freq, int FirstIdx)> frequency = [];
    for (int i = 0; i < arr.Length; i++)
    {
      T number = arr[i];
      if (frequency.TryGetValue(number, out (int Freq, int FirstIdx) value))
      {
        frequency[number] = (value.Freq + 1, value.FirstIdx);
      }
      else
      {
        frequency.Add(number, (1, i));
      }
    }

    return frequency;
  }
}
