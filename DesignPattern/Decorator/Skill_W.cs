/// <summary>
/// Skill_W.cs
/// Created by irs  2019-01-02
/// </summary>

using System;

public class Skill_W : SkillDecorator
{
    private string mName;

    public Skill_W(string name, IHero hero) : base(hero)
    {
        mName = name;
    }

    public override void learnSkill()
    {
        Console.WriteLine("learn W skill: " + mName);
        base.learnSkill();
    }
}