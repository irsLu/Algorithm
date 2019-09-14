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
   static string morganAndString(string a, string b)
    {

        int aLength = a.Length;
        int bLength = b.Length;
        int pA = 0, pB = 0;
        StringBuilder ret = new StringBuilder();
        int _count;
        while (pA < aLength && pB < bLength)
        {

            if (a[pA] < b[pB])
            {
                ret.Append(a[pA++]);
            }
            else if (a[pA] > b[pB])
            {
                ret.Append(b[pB++]);
            }
            else
            {
                _count = 1;
                bool isFind = true;
                while (true)
                {
                  if (pA + _count == aLength || pB + _count == bLength)
                    {
                        isFind = false;
                        break;
                    }

                    if (b[pB + _count] < a[pA + _count])
                    {
                        ret.Append(b[pB++]);
                        while (pB < bLength && b[pB] <= b[pB - 1]) {
                            ret.Append(b[pB++]);
                        }
                        break;
                    }

                    if (a[pA + _count] < b[pB + _count])
                    {
                        ret.Append(a[pA++]);
                        while (pA < aLength && a[pA] <= a[pA - 1]) {
                            ret.Append(a[pA++]);
                        }
                        break;
                    }
                    _count++;
              }

                if (!isFind)
                {
                    if (pA + _count == aLength)
                    {
                        ret.Append(b[pB++]);
                        while (pB < bLength && b[pB] <= b[pB - 1]) {
                            ret.Append(b[pB++]);
                        }
                    }
                    else
                    {
                        ret.Append(a[pA++]);
                        while (pA < aLength && a[pA] <= a[pA - 1]) {
                            ret.Append(a[pA++]);
                        }
                    }
                }
            }
        }

        if (pA < aLength)
        {
            ret.Append(a.Substring(pA));
        }

        if (pB < bLength)
        {
            ret.Append(b.Substring(pB));
        }

        return ret.ToString();
    }

    static void Main(string[] args) {
       // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        string ret = "";
       // int t = Convert.ToInt32(Console.ReadLine());

       string a = "AAAAAAAAAAB";
       string b = "AAAAAAAAAAC";




       ret = morganAndString(a, b);
       Console.WriteLine(ret == "AAAAAAAAAAAAAAAAAAAABC");
       Console.WriteLine(ret);

//        for (int tItr = 0; tItr < t; tItr++) {
//            string a = Console.ReadLine();
//1
//            string b = Console.ReadLine();
//
//            ret = morganAndString(a, b);
//            Console.WriteLine(ret);
//        }

    }
}
