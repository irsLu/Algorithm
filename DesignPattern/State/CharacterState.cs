

public abstract class CharacterState
{
    protected Hero mHero;

    public abstract CharacterState HandleInput(Keybord keybord);

    public virtual void Update() { }

    public virtual void Enter() { }

}
