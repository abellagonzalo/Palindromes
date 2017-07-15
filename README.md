# Palindromes
Find the 3 longest unique palindromes in a supplied string.

The algorithm runs in O(n^2) in the worst case scenario, for example with a string where all characters are equal like 'aaaaa'.

## Build and run

The solution is implemented in C# and uses the dotnet Core framework. Please make sure you have the dotnet environment installed. Find further details in the link below:

https://www.microsoft.com/net/download/core

The following instructions have been run on a DOS shell. Please make sure to change the path separators if you are not using a Windows machine.

One the unit tests might fail depending on how powerfull is the computer.

```bash
git clone https://github.com/abellagonzalo/Palindromes.git
cd Palindromes
dotnet restore
dotnet build
dotnet test Palindromes.Tests\Palindromes.Tests.csproj
dotnet run -p Palindromes\Palindromes.csproj -- sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop
```
