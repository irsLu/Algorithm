/// <summary>
/// Client.cs
/// Created by irs  2019-01-25
/// </summary>

using System;
using System.Reflection;

public class Client
{

    static void Main(string[] args)
    {
       Hero Jack = new Hero();

       Jack.HandleInput(Keybord.PRESS_J);
       Jack.HandleInput(Keybord.RELEASE_J);
       Jack.HandleInput(Keybord.PRESS_BlANK);
       Jack.HandleInput(Keybord.PRESS_J);

        Console.ReadKey();
    }
}