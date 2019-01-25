public class DiviState : CharacterState
{
    public DiviState(Hero hero)
    {
        mHero = hero;
    }

    public override void Enter()
    {
        mHero.PlayAction("Divi");
    }


    public override CharacterState HandleInput(Keybord keybord)
    {
       

        return null;
    }


}