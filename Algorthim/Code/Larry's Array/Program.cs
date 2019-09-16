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

    static string larrysArray(int[] A)
    {
        bool isFind = true;
        int length = A.Length;
        int index = 0;
        int _i;

        while (index < length)
        {
            if (index + 1 == A[index])
            {
                index++;
                continue;
            }

            _i = index + 1;
            while (_i < length)
            {
                if (index + 1 == A[_i])
                {
                    break;
                }

                _i++;
            }

            while (_i > index)
            {
                if (_i == index + 1)
                {
                    if (_i + 1 >= length)
                    {
                        return "No";
                    }

                    if (tryRotate(ref A[_i - 1], ref A[_i], ref A[_i + 1]))
                    {
                        if (A[_i - 1] == index + 1)
                        {
                            _i -= 1;
                        }
                    }
                }
                else
                {
                    if (tryRotate(ref A[_i - 2], ref A[_i - 1], ref A[_i]))
                    {
                        if (_i - 2 < index)
                        {
                            return "No";
                        }
                        if (A[_i - 2] == index + 1)
                        {
                            _i -= 2;
                        }
                    }
                }
            }

            index++;

        }

        return "Yes";
    }

    static bool tryRotate(ref int left, ref int middle, ref int right)
    {
        int temp;
        int temp1;
        if (left < middle && left < right)
        {
            return true;
        }

        if (middle < right && middle < left)
        {
            temp = left;
            left = middle;
            middle = right;
            right = temp;
            return true;
        }

        if (right < left && right < middle)
        {
            temp = left;
            temp1 = middle;
            left = right;
            middle = temp;
            right = temp1;
            return true;
        }

        return false;
    }

    static void Main(string[] args) {
        string ret = "";
        int[] A = new List<int>(){1,3,4,2}.ToArray();

        ret = larrysArray(A);

        Console.WriteLine(ret);

    }
}
