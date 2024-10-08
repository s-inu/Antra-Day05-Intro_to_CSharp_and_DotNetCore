namespace DataTypes;

using System.Numerics;
using static Utils.IO;

public class NumberSizesAndRanges
{
  public static void DisplayInfo()
  {
    string FORMAT = "{0,-8} {1,5} {2,30} {3,30}";

    // sbyte, byte, short, ushort, int, uint, long, ulong, float, double, decimal
    Console.WriteLine(FORMAT, "Type", "Bytes", "Min", "Max");
    Console.WriteLine(new string('-', 77));  // Prints a separator line

    Console.WriteLine(FORMAT, "sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
    Console.WriteLine(FORMAT, "byte", sizeof(byte), byte.MinValue, byte.MaxValue);
    Console.WriteLine(FORMAT, "short", sizeof(short), short.MinValue, short.MaxValue);
    Console.WriteLine(FORMAT, "ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
    Console.WriteLine(FORMAT, "int", sizeof(int), int.MinValue, int.MaxValue);
    Console.WriteLine(FORMAT, "uint", sizeof(uint), uint.MinValue, uint.MaxValue);
    Console.WriteLine(FORMAT, "long", sizeof(long), long.MinValue, long.MaxValue);
    Console.WriteLine(FORMAT, "ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
    Console.WriteLine(FORMAT, "float", sizeof(float), float.MinValue, float.MaxValue);
    Console.WriteLine(FORMAT, "double", sizeof(double), double.MinValue, double.MaxValue);
    Console.WriteLine(FORMAT, "decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
  }

  public static void ConvertCenturies()
  {
    BigInteger c = BigInteger.Parse(Input(AskForMessage("Centuries")));

    BigInteger y = c * 100;
    BigInteger d = y * 365;
    BigInteger h = d * 24;
    BigInteger m = h * 60;
    BigInteger s = m * 60;
    BigInteger ms = s * 1_000;
    BigInteger us = ms * 1_000;
    BigInteger ns = us * 1_000;

    Console.WriteLine($"{c} centuries = {y} years = {d} days = {h} hours = {m} minutes " +
                          $"= {s} seconds = {ms} milliseconds = {us} microseconds = {ns} nanoseconds");
  }
}
