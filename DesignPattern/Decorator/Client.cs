/// <summary>
/// Client.cs
/// Created by irs  2019-01-02
/// </summary>

using System;

public class Client
{

    static void Main(string[] args)
    {
        IHero liqing = new BlindMonk("李青");

        IHero q = new Skill_Q("天音破", liqing);
        IHero w = new Skill_W("金钟罩", q);
        IHero e = new Skill_E("天雷破", w);
        IHero r = new Skill_R("猛龙摆尾", e);

        r.learnSkill();
        Console.ReadKey();
    }

}

