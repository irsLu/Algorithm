/// <summary>
/// DImp.cs
/// Created by irs  2018-12-29
/// </summary>

using System;

public class DImp:ID
{
    public void Log(string msg)
    {
        Console.WriteLine("Log:" + msg);
    }

    public void Warning(string msg)
    {
        Console.WriteLine("Warning: " + msg);
    }

    public void Error(string msg)
    {
        Console.WriteLine("Error: " + msg);
    }
}