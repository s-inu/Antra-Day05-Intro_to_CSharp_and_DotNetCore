# 01 Introduction to C# and Data Types

## Understanding Data Types

### Test your Knowledge

1. What type would you choose for the following “numbers”?

- A person’s telephone number
  - `string`
- A person’s height
  - `float`
- A person’s age
  - `byte`
- A person’s gender (Male, Female, Prefer Not To Answer)
  - `enum`
- A person’s salary
  - `decimal`
- A book’s ISBN
  - `string`
- A book’s price
  - `decimal`
- A book’s shipping weight
  - `float`
- A country’s population
  - `uint`
- The number of stars in the universe
  - `ulong`
- The number of employees in each of the small or medium businesses in the United Kingdom (up to about 50,000 employees per business)
  - `ushort`

2. What are the difference between value type and reference type variables? What is boxing and unboxing?

| value type             | reference type          |
| ---------------------- | ----------------------- |
| holds the data         | holds the reference     |
| on stack               | on heap                 |
| cannot collected by GC | will be collected by GC |
| does not take `null`   | takes `null`            |

- boxing: wrap a value type into a reference type

- unboxing: extract the value type out of a reference type where it is contained

3. What is meant by the terms managed resource and unmanaged resource in .NET

   - managed resource: resource that is managed by CLR(common language runtime)'s GC. e.g.
   - unmanaged resource: resource that is NOT managed by CLR(common language runtime)'s GC. It can be managed by implementing `IDisposable`

4. Whats the purpose of Garbage Collector in .NET?
   - Automatic Memory Management & Simplifying Development
   - Optimizing Application Performance: compacting the heap
   - Improving Program Safety: an object that is no longer accessible will be destroyed
   - Enhancing Application Stability: preventing memory leak

## Controlling Flow and Converting Types

### Test your Knowledge

1. What happens when you divide an int variable by 0?

   - runtime `System.DivideByZeroException`

2. What happens when you divide a double variable by 0?

   - positive double, `double.PositiveInfinity`
   - `0d`, `double.NaN`
   - positive double, `double.NegativeInfinity`

3. What happens when you overflow an int variable, that is, set it to a value beyond its
   range?

   - if `checked`, `System.OverflowException`
   - otherwise, the value wraps to the other end of range

4. What is the difference between x = y++; and x = ++y;?

   - `y++`, post-increment, `y+=1; x=y`;
   - `++y`, pre-increment, `x=y; y+=1;`

5. What is the difference between break, continue, and return when used inside a loop
   statement?

   - `break`: exits the current loop
   - `continue`: skips the current iteration of the current loop
   - `return`: exits the method where the loop resides

6. What are the three parts of a for statement and which of them are required?

   - `for(Initialization; Condition; Iteration){}`

7. What is the difference between the = and == operators?

   - `=`, assignment operator
   - `==`, equality operator

8. Does the following statement compile? for ( ; true; ) ;

   - Yes, and it creates an infinite loop

9. What does the underscore \_ represent in a switch expression?

   - every expression, including `null`, always matches the discard pattern

10. What interface must an object implement to be enumerated over by using the foreach statement?
    - `IEnumerable`

### Practice loops and operators

1. What will happen if this code executes?
    Create a console application and enter the preceding code. Run the console application and view the output. What happens?
    What code could you add (don’t change any of the preceding code) to warn us about the problem?

```c#
int max = 500;
for (byte i = 0; i < max; i++)
{
  WriteLine(i);
}
```

- infinite loop
- revision for warning

```c#
int max = 500;
for (byte i = 0; i < max; i++)
{
  if(max>byte.MaxValue){ // <-- start
      WriteLine($"potential overflow and infinite loop: ${max}>{byte.MaxValue}!");
      break;
  } // <-- end
  WriteLine(i);
}
```
