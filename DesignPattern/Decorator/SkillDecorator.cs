/// <summary>
/// SkillDecorator.cs
/// Created by irs  2019-01-02
/// </summary>

using System;

public class SkillDecorator:IHero
{
    private IHero mHero;

    public SkillDecorator(IHero hero)
    {
        mHero = hero;
    }


    public virtual void learnSkill()
    {
        mHero.learnSkill();
    }
}