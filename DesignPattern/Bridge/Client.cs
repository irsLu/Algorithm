/// <summary>
/// Client.cs
/// 武器接口
/// Created by irs  2018-12-24
/// </summary>

using System;

public class Client
{

    static void Main(string[] args)
    {
        ACharactor daidai = new DaiDai(new Sword());

        daidai.Attack();

        Console.ReadKey();
    }

}