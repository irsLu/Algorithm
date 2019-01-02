/// <summary>
/// Skill_R.cs
/// Created by irs  2019-01-02
/// </summary>

using System;

public class Skill_R : SkillDecorator
{
    private string mName;

    public Skill_R(string name, IHero hero) : base(hero)
    {
        mName = name;
    }

    public override void learnSkill()
    {
        Console.WriteLine("learn R skill: " + mName);
        base.learnSkill();
    }
}