using System;

public abstract class IWeapon
{
    public void Attack()
    {
        PlayAttackPrelude();

        PlayAttackAction();
        PlayAttackEffect();
        PlayAttackSound();

        hookMethod();
    }

    private void PlayAttackPrelude()
    {
        Console.WriteLine("play attack Prelude~");
    }

    protected abstract void PlayAttackAction();

    protected abstract void PlayAttackEffect();

    protected abstract void PlayAttackSound();

    private void hookMethod()
    {
        
    }
}

