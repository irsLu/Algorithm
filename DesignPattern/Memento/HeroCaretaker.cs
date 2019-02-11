
public class HeroCaretaker
{
    private IMemento mMemento;

    public IMemento retrieveMemento()
    {
        return mMemento;
    }

    public void SaveMemento(IMemento memento)
    {
        mMemento = memento;
    }
}
