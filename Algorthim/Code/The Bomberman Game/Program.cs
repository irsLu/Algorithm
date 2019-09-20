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

    static string[] bomberMan(int n, string[] grid)
    {
        int row = grid.Length;
        int col = grid[0].Length;
        int[,] map = new int[row,col];
        if (n == 1)
        {
            return grid;
        }

        string[] ret = new string[row];
        if (n % 2 == 0)
        {
            for (int i = 0; i < row; i++)
            {
                ret[i] = new string('O', col);
            }

            return ret;
        }

        preDeal(ref map, grid, row, col);

        int realTime = (n - 3) / 2 % 2 == 0 ? 1 : 2;


        for (int k = 0; k < realTime; k++)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (map[i, j] == 0)
                    {
                        map[i, j] = 1;
                    }
                    else if (map[i, j] == 1)
                    {
                        bomb(ref map, i, j, row, col);
                    }
                    else
                    {
                        map[i, j] = 0;
                    }
                }
            }

        }


        postDeal(ref map, ref ret, row, col);

        return ret;
    }

    static void preDeal(ref int[,] map, string[] grid,  int row, int col)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (grid[i][j] == '.')
                {
                    map[i,j] = 0;
                }
                else if (grid[i][j] == 'O')
                {
                    map[i,j] = 1;
                }
            }
        }
    }

    static void postDeal(ref int[,] map, ref string[] ret,int row, int col)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (map[i, j] == 0)
                {
                    sb.Append('.');
                }
                else if (map[i, j] == 1)
                {
                    sb.Append('O');
                }
            }

            ret[i] = sb.ToString();
            sb.Clear();
        }
    }

    static void bomb(ref int[,] map, int i, int j, int row, int col)
    {
        map[i, j] = 0;
        //left
        if (i > 0)
        {
            map[i - 1, j] = 0;
        }

        //right
        if (i < row - 1)
        {
            if (map[i + 1, j] != 1)
            {
                map[i + 1, j] = -1;
            }
        }

        //top
        if (j > 0)
        {
            map[i, j - 1] = 0;
        }

        //bottom
        if (j < col - 1)
        {
            if (map[i, j + 1] != 1)
            {
                map[i, j + 1] = -1;
            }

        }
    }

    static void Main(string[] args) {
        string[] RC= new string[]
        {
            ".......",
            "...O.O.",
            "....O..",
            "..O....",
            "OO...OO",
            "OO.O...",
        };



        string[] result = bomberMan(9, RC);
        foreach (var v in result)
        {
            Console.WriteLine(v);
        }

//        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
//
//        int t = Convert.ToInt32(Console.ReadLine());
//
//        for (int tItr = 0; tItr < t; tItr++) {
//            string[] RC = Console.ReadLine().Split(' ');
//
//            int R = Convert.ToInt32(RC[0]);
//
//            int C = Convert.ToInt32(RC[1]);
//
//            string[] G = new string [R];
//
//            for (int i = 0; i < R; i++) {
//                string GItem = Console.ReadLine();
//                G[i] = GItem;
//            }
//
//            string[] rc = Console.ReadLine().Split(' ');
//
//            int r = Convert.ToInt32(rc[0]);
//
//            int c = Convert.ToInt32(rc[1]);
//
//            string[] P = new string [r];
//
//            for (int i = 0; i < r; i++) {
//                string PItem = Console.ReadLine();
//                P[i] = PItem;
//            }
//
//            string result = gridSearch(G, P);
//
//            textWriter.WriteLine(result);
//        }
//
//        textWriter.Flush();
//        textWriter.Close();
    }
}
