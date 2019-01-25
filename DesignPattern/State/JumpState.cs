
public class JumpState : CharacterState
{
     public JumpState(Hero hero)
     {
        mHero = hero;
     }

     public override void Enter()
     {
         mHero.PlayAction("Jump");
     }


    public override CharacterState HandleInput(Keybord keybord)
    {
        if (keybord == Keybord.PRESS_J)
            return new DiviState(this.mHero);

        return null;
    }



}
