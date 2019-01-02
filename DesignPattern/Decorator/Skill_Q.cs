/// <summary>
/// Skill_Q.cs
/// Created by irs  2019-01-02
/// </summary>

using System;

public class Skill_Q:SkillDecorator
{
    private string mName;

    public Skill_Q(string name, IHero hero):base(hero)
    {
        mName = name;
    }

    public override void learnSkill()
    {
        Console.WriteLine("learn Q skill: " + mName);
        base.learnSkill();
    }
}