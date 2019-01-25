

using System.Runtime.Serialization;

public class IdleState : CharacterState
{
    public IdleState(Hero hero)
    {
        mHero = hero;
    }

    public override void Enter()
    {
        mHero.PlayAction("Idel");
    }

    public override CharacterState HandleInput(Keybord keybord)
    {
        if (keybord == Keybord.PRESS_BlANK)
        {
            return new JumpState(this.mHero);
        }
        else if (keybord == Keybord.PRESS_J)
        {
            return new AttackState(this.mHero);
        }

        return null;
    }


}
