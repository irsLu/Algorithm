using System;

public class Sword_Damocles : IWeapon
{
    protected override void PlayAttackAction()
    {
        Console.WriteLine("Play cut action~");
    }

    protected override void PlayAttackEffect()
    {
        Console.WriteLine("Fire on Sword~");
    }

    protected override void PlayAttackSound()
    {
        Console.WriteLine("Play Damocles sound~");
    }
}
