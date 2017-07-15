using System;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace Palindromes.Tests
{
    public class PalindromeFinderUnitTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Palindromes_AreNull(string str)
        {
            Assert.Null(new PalindromeFinder(str).Unique(3));
        }

        [Theory]
        [InlineData("a",  new[] { 0, 1, 0, 0, 0, 0 })]
        [InlineData("ab", new[] { 0, 1, 1, 1, 0, 0 })]
        [InlineData("abc", new[] { 0, 1, 1, 1, 2, 1 })]
        [InlineData("abcd", new[] { 0, 1, 1, 1, 2, 1 })]
        [InlineData("aa", new[] { 0, 2, 0, 1, 0, 0 })]
        [InlineData("aabb", new[] { 0, 2, 2, 2, 0, 1 })]
        [InlineData("aabbcc", new[] { 0, 2, 2, 2, 4, 2 })]
        [InlineData("aba12aba", new[] { 0, 3, 0, 1, 3, 1 })]
        [InlineData("sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop", new[] { 23, 10, 13, 8, 5, 6 })]
        [InlineData("aba12bccb34cddc56cddc89", new[] { 5, 4, 11, 4, 0, 3 })]
        [InlineData("abcdefghijklmnopqrstuvwxyz0123456789", new[] { 0, 1, 1, 1, 2, 1 })]
        [InlineData("abcdedcba", new[] { 0, 9, 0, 1, 1, 1 })]
        public void Palindromes_Tests(string str, int[] expected)
        {
            var expectedTuples = new Tuple<int, int>[3];
            for (int i = 0; i < expected.Length/2; i++)
                expectedTuples[i] = Tuple.Create(expected[i * 2], expected[i * 2 + 1]);

            Assert.Equal(expectedTuples, new PalindromeFinder(str).Unique(3));
        }

        [Fact]
        public void Palindromes_WorstCase()
        {
            var stopwatch = Stopwatch.StartNew();

            var n = 1000;
            var builder = new StringBuilder();
            for (int i = 0; i < n; i++)
                builder.Append("a");

            var expected = new []
            {
                Tuple.Create(0, n), Tuple.Create(0, n-1), Tuple.Create(0, n-2)
            };

            Assert.Equal(expected, new PalindromeFinder(builder.ToString()).Unique(3));

            Assert.True(stopwatch.ElapsedMilliseconds < 10);
        }
    }
}