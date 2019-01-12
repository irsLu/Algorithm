/// <summary>
/// BattleSys.cs
/// Created by irs  2019-01-12
/// </summary>


using System;

class BattleSys
{
    private static BattleSys _instance = new BattleSys();

    private BattleSys() { }

    public static BattleSys GetInstance()
    {
        return _instance;
    }

    public void Fight(string npc)
    {
        Console.WriteLine("is Fighting with "+npc);
    }
}
