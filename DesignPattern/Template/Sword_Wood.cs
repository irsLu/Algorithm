using System;

public class Sword_Worrd : IWeapon
{
    protected override void PlayAttackAction()
    {
        Console.WriteLine("Play stab action~");
    }

    protected override void PlayAttackEffect()
    {
       
    }

    protected override void PlayAttackSound()
    {
        Console.WriteLine("Play sword sound~");
    }
}
