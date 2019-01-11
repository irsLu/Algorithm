/// <summary>
/// Client.cs
/// Created by irs  2019-01-11
/// </summary>

using System;
using System.Reflection;

public class Client
{

    static void Main(string[] args)
    {
        FiveChessmanFactory factory = FiveChessmanFactory.GetInstance();

        AChessman chess = null;

        chess = factory.GetChessMan("white");
        chess.point(2, 2);

        chess = factory.GetChessMan("black");
        chess.point(1, 1);

        chess = factory.GetChessMan("white");
        chess.point(1, 3);

        chess = factory.GetChessMan("black");
        chess.point(3, 1);

        chess = factory.GetChessMan("white");
        chess.point(2, 1);

        chess = factory.GetChessMan("black");
        chess.point(2, 3);

        chess = factory.GetChessMan("white");
        chess.point(1, 2);

        chess = factory.GetChessMan("black");
        chess.point(3, 2);

        chess = factory.GetChessMan("white");
        chess.point(3, 3);

        Console.WriteLine("平局");

        Console.ReadKey();
    }

}

