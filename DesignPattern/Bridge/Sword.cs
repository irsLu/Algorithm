/// <summary>
/// Sword.cs
/// 剑
/// Created by irs  2018-12-24
/// </summary>

using System;

public class Sword : IWeapon
{
    public Sword()
    {
        this.name = "KAKA Sword";
    }

    public override void Action()
    {
       Console.WriteLine(this.name + " stab !");
    }
}