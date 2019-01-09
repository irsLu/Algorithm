/// <summary>
/// MapNodeComponent.cs
/// Created by irs  2019-01-09
/// </summary>

public abstract class MapNodeComponent
{
    public string Name;

    public MapNodeComponent(string name)
    {
        Name = name;
    }

    public abstract void Draw();
}
