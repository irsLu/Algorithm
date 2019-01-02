/// <summary>
/// Skill_E.cs
/// Created by irs  2019-01-02
/// </summary>

using System;

public class Skill_E : SkillDecorator
{
    private string mName;

    public Skill_E(string name, IHero hero) : base(hero)
    {
        mName = name;
    }

    public override void learnSkill()
    {
        Console.WriteLine("learn E skill: " + mName);
        base.learnSkill();
    }
}