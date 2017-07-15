using System;
using System.Linq;

namespace Palindromes
{
    public class PalindromeFinder
    {
        private readonly string _str;
        private Tuple<int, int>[] _result; 

        public PalindromeFinder(string str)
        {
            _str = str;
        }

        public Tuple<int, int>[] Unique(int n)
        {
            if (String.IsNullOrEmpty(_str)) return null;

            _result = new Tuple<int, int>[n];
            for (int i = 0; i < _result.Length; i++)
                _result[i] = Tuple.Create(0, 0);

            for (var i = 0; i < _str.Length; i++)
            {
                // Return if max possible palindrome is shorter than the shorthes result 
                var maxPalindromLength = (_str.Length - i - 1) * 2 + 1;
                if (i > _str.Length / 2 && _result.Last().Item2 > maxPalindromLength)
                    break;

                // Calculate odd length palindrome
                var j = i - 1;
                var k = i + 1;
                var candidate = FindPalindrome(j, k) ?? Tuple.Create(i, 1);
                AddToResults(candidate);

                // Calculate even length palindrome
                j = i;
                k = i + 1;
                candidate = FindPalindrome(j, k);
                AddToResults(candidate);
            }

            return _result;
        }

        private Tuple<int, int> FindPalindrome(int j, int k)
        {
            Tuple<int, int> candidate = null;
            while (j >= 0 && k < _str.Length && _str[j] == _str[k])
            {
                candidate = Tuple.Create(j, k - j + 1);
                j--;
                k++;
            }
            return candidate;
        }

        private void AddToResults(Tuple<int, int> candidate)
        {
            if (candidate == null) return;

            var substring = _str.Substring(candidate.Item1, candidate.Item2);
            if (_result.Select(t => _str.Substring(t.Item1, t.Item2)).Contains(substring))
                return;

            var n = _result.Length;
            if (_result[n - 1].Item2 < candidate.Item2)
            {
                var l = n - 2;
                while (l >= 0 && candidate.Item2 > _result[l].Item2)
                {
                    _result[l + 1] = _result[l];
                    l--;
                }
                _result[l + 1] = candidate;
            }
        }
    }
}