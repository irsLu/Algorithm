/// <summary>
/// PathFindingSys.cs
/// Created by irs  2019-01-12
/// </summary>


using System;

class PathFindingSys
{
    private static PathFindingSys _instance = new PathFindingSys();

    private PathFindingSys() { }

    public static PathFindingSys GetInstance()
    {
        return _instance;
    }

    public void Finding(int x, int y)
    {
        Console.WriteLine("path algorthm is finding " + "(" + x + ","+y+")");
    }

}

