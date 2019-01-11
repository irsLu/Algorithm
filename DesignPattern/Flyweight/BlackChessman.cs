/// <summary>
/// BlackChessman.cs
/// Created by irs  2019-01-11
/// </summary>

using System;

public class BlackChessman:AChessman
{

    public BlackChessman() : base("●")
    {

    }

    public override void point(int x, int y)
    {
        this.mX = x;
        this.mY = y;

        show();
    }
}