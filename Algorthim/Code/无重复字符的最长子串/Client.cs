
using System.Collections.Generic;
using System;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        int ret = 0;

        Dictionary<char, int> map = new Dictionary<char, int>();

        int i, j = 0;

        int n = s.Length;
        for (i = 0, j = 0; j < n; j++)
        {
            if (map.ContainsKey(s[j]))
            {
                i = Math.Max(i, map[s[j]]);
                map[s[j]] = j + 1;
            }
            else
            {
                map.Add(s[j], j + 1);
            }

            ret = Math.Max(ret, j - i + 1);
        }

        return ret;
    }
}


