/// <summary>
/// ND.cs
/// Created by irs  2018-12-29
/// </summary>

using System;

public class ND
{
    public void NLog(string msg, DateTime time)
    {
        Console.WriteLine(string.Format("{0} Log: {1}", time.ToString(), msg));
    }

    public void NWarning(string msg, DateTime time)
    {
        Console.WriteLine(string.Format("{0} Warning: {1}", time.ToString(), msg));
    }

    public void NError(string msg, DateTime time)
    {
        Console.WriteLine(string.Format("{0} Error: {1}", time.ToString(), msg));
    }
}