/// <summary>
/// FiveChessmanFactory.cs
/// Created by irs  2019-01-11
/// </summary>

using System;
using System.Collections.Generic;

public class FiveChessmanFactory
{
    private static FiveChessmanFactory _inst = new FiveChessmanFactory();

    private FiveChessmanFactory()
    { }

    public static FiveChessmanFactory GetInstance()
    {
        return _inst;
    }

    private Dictionary<string, AChessman> mCache = new Dictionary<string, AChessman>();

    public AChessman GetChessMan(string chess)
    {
        AChessman res = null;
        if (!mCache.ContainsKey(chess))
        {
            switch (chess)
            {
                case "black":
                    res = new BlackChessman();
                    break;
                case "white":
                    res = new WhiteChessman();
                    break;
                default:
                    break;
            }
            mCache[chess] = res;
        }
        else
        {
            res = mCache[chess];
        }

        return res;
    }
}