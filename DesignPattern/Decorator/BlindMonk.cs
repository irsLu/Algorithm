/// <summary>
/// BlindMonk.cs
/// Created by irs  2019-01-02
/// </summary>

using System;

public class BlindMonk:IHero
{
    private string mName;

    public BlindMonk(string name)
    {
        mName = name;
    }

    public void learnSkill()
    {
        Console.WriteLine(mName + " 学习了以上技能");
    }
}

