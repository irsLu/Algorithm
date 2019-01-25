
using System;

public class AttackState : CharacterState
{
    public AttackState(Hero hero)
    {
        mHero = hero;
        pressDuration = 0;
    }

    public override CharacterState HandleInput(Keybord keybord)
    {
        if (keybord == Keybord.RELEASE_J)
        {
            return new IdleState(this.mHero);
        }

        return null;
    }

    public override void Enter()
    {
        mHero.PlayAction("Attack");
    }

    public override void Update()
    {
        pressDuration++;
        // 假设 fps = 60
        if (pressDuration > 180)
        {
            Console.WriteLine("hero is charging~");
        }
    }

    private int pressDuration = 0;

}