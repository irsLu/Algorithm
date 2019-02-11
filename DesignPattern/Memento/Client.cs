/// <summary>
/// Client.cs
/// Created by irs  2019-2-11
/// </summary>

using System;

public class Client
{

    static void Main(string[] args)
    {
        Hero irs = new Hero(0, 10, 1);

        HeroCaretaker caretaker = new HeroCaretaker();
        
        irs.UpLevel();

        irs.HeroStateInfo();

        caretaker.SaveMemento(irs.CreateMemento());

        irs.UpLevel();

        irs.HeroStateInfo();

        irs.RestoreMemento(caretaker.retrieveMemento());

        irs.HeroStateInfo();

        Console.ReadKey();
    }

}