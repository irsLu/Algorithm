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

    public static bool CanPartition(int[] nums)
    {
        int sum = nums.Sum();
        if (sum % 2 == 1)
        {
            return false;
        }

        int C = sum / 2;
        int n = nums.Length;

        bool[,] m = new bool[n, C + 1];

        for (int i = 0; i < n; i++)
        {
            m[i, 0] = true;
        }

        for (int i = 1; i < n; i++)
        {
            for (int k = 1; k < C + 1; k++)
            {
                if (k >= nums[i-1])
                {
                    m[i, k] = m[i - 1, k] || m[i - 1, k - nums[i-1]];
                }
                else
                {
                    m[i, k] = m[i - 1, k];
                }
            }

        }

        return m[n - 1, C];
    }



    static void Main(string[] args)
    {
        int[] t = new[] {1,5, 11, 5};

        bool ret = CanPartition(t);

        Console.WriteLine(ret);
    }
}
