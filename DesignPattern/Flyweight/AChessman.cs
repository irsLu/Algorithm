/// <summary>
/// AChessman.cs
/// Created by irs  2019-01-11
/// </summary>

using System;

public abstract class AChessman
{
    public string Name;
    protected int mX;
    protected int mY;

    public AChessman(string name)
    {
        Name = name;
    }

    public abstract void point(int x, int y);

    public void show()
    {
        Console.WriteLine(this.Name + "(" + this.mX + "," + this.mY + ")");
    }
}