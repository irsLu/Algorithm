using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    public static int FindMaxForm(string[] strs, int m, int n)
    {
        // m:0 n:1
        int [,] dp = new int[m+1,n+1];

        string str = "";
        for (int i = 0; i < strs.Length; i++)
        {
            str = strs[i];
            int[] numOf01 = num_of_0_1(str);
            for (int j = m; j >= numOf01[0]; j--)
            {
                for (int k = n; k >= numOf01[1]; k--)
                {
                    dp[j, k] = Math.Max(dp[j, k], dp[j - numOf01[0], k - numOf01[1]] + 1);
                }
            }
        }

        return dp[m, n];
    }

    public static int[] num_of_0_1(string s)
    {
        int[] ret = new int[2];

        foreach (var c in s)
        {
            if (c == '0')
            {
                ret[0]++;
            }
            else if (c == '1')
            {
                ret[1]++;
            }
        }

        return ret;
    }



    static void Main(string[] args)
    {
        string[] t = new[] {"10", "0001", "111001", "1", "0"};

       //string strs = "";
        int ret = FindMaxForm(t, 5, 3);

        Console.WriteLine(ret);
    }
}
