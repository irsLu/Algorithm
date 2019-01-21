/// <summary>
/// Client.cs
/// Created by irs  2019-01-09
/// </summary>

using System;
using System.Reflection;

public class Client
{

    static void Main(string[] args)
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("Player was 0 level with wood sword.");
        Console.WriteLine("-----------------------");
        IWeapon sword_0 = new Sword_Worrd();
        sword_0.Attack();
        Console.WriteLine("-----------------------");
        Console.WriteLine("Player had up 99 levels,and get damocles.");
        Console.WriteLine("-----------------------");
        IWeapon sword_99 = new Sword_Damocles();

        sword_99.Attack();

        Console.ReadKey();
    }
}