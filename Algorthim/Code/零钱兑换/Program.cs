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

    public static int CoinChange(int[] coins, int amount)
    {
        int ret = -1;

        int[] dp = new int[amount + 1];
        for (int i = 0; i < amount +1; i++)
        {
            dp[i] = Int32.MaxValue;
        }
        dp[0] = 0;

        for (int i = 0; i < coins.Length; i++)
        {
            for (int j = 0; j < amount +1; j++)
            {
                if (j - coins[i] >= 0 && dp[j - coins[i]] != Int32.MaxValue)
                    dp[j] = Math.Min(dp[j], dp[j - coins[i]] + 1);
            }
        }

        return (dp[amount] <= amount && dp[amount] >= 0)? dp[amount]:-1;
    }

    static void Main(string[] args)
    {
        int[] t = new[] {2, 5, 10 ,1};

       //string strs = "";
        int ret = CoinChange(t, 27);

        Console.WriteLine(ret);
    }
}
