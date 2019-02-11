

using System;

public partial class Hero
{
    public int Level
    {
        private set;
        get;
    }

    public long HP
    {
        private set;
        get;
    }

    public int Atk
    {
        private set;
        get;
    }

    public Hero(int level, long hp, int atk)
    {
        Level = level;
        Atk = atk;
        HP = hp;
    }

    public void UpLevel()
    {
        Level += 1;
        Atk += 5;
        HP += 10;
    }

    public void HeroStateInfo()
    {
        Console.WriteLine("=================");
        Console.WriteLine("hero level：" + Level);
        Console.WriteLine("hero hp：" + HP);
        Console.WriteLine("hero atk：" + Atk);
        Console.WriteLine("=================");
    }

    public void RestoreMemento(IMemento memento)
    {
        HeroStateMemento state = memento as HeroStateMemento;

        this.Atk = state.Atk;
        this.HP = state.HP;
        this.Level = state.Level;
    }

    public IMemento CreateMemento()
    {
        return new HeroStateMemento(this.Level,this.HP, this.Atk);
    }
   
}