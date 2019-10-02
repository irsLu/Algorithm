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

    public static int LastStoneWeightII(int[] stones)
    {
        int ret = 0;

        int sum = stones.Sum();
        int n = stones.Length;
        int V = (int) sum / 2;

        int [, ] m = new int[n + 1, V+1];
        for (int i = 1; i < n + 1; i++)
        {
            for (int k = 1; k < V + 1; k++)
            {
                if (k < stones[i - 1])
                {
                    m[i, k] = m[i - 1, k];
                }
                else
                {
                    m[i, k] = Math.Max(m[i - 1, k], stones[i - 1] + m[i - 1, k - stones[i - 1]]);
                }
            }
        }
        return sum - 2 * m[n, V];
    }


    static void Main(string[] args)
    {
        int[] t = new[] {2,7,4,1,8,1};

        int ret = LastStoneWeightII(t);

        Console.WriteLine(ret);
    }
}
