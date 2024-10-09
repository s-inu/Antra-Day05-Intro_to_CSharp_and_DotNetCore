# 02 Arrays and Strings

### Test your Knowledge

1. When to use String vs. StringBuilder in C# ?

   - `string` is immutable, better for simple and safe operations that are not involved mutation

   - `StringBuilder` provides a way to mutate string

2. What is the base class for all arrays in C#?

   - `System.Array`

3. How do you sort an array in C#?

   - `Array.Sort(arr, (a, b)=>{...});`

4. What property of an array object can be used to get the total number of elements in
   an array?

   - `length`

5. Can you store multiple data types in System.Array?

   - Yes. For example, `object[] mixedArr = [1, '1', "1"];`

6. What’s the difference between the System.Array.CopyTo() and System.Array.Clone()?
   - `System.Array.CopyTo()`:
     - `arr1.CopyTo(arr2, idx);`
     - shallow copy
     - combine one array `arr1` into another `arr2`, starting from `idx` in `arr2`
   - `System.Array.Clone()`
     - `object o = arr1.Clone();`
     - shallow copy
     - gives a quick copy of the original array
