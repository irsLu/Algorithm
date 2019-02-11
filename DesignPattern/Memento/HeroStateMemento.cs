public partial class Hero
{

    private class HeroStateMemento : IMemento
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

        public HeroStateMemento(int level, long hp, int atk)
        {
            Level = level;
            Atk = atk;
            HP = hp;
        }
    }
}