/// <summary>
/// MapLayerComposite.cs
/// Created by irs  2019-01-09
/// </summary>

using System.Collections.Generic;

public class MapLayerComposite : MapNodeComponent
{
    public MapLayerComposite(string name):base(name)
    { }

    private List<MapNodeComponent> mList = new List<MapNodeComponent>();

    public override void Draw()
    {
       foreach(MapNodeComponent item in mList)
        {
            item.Draw();
        }
    }

    public void Add(MapNodeComponent node)
    {
        mList.Add(node);
    }

    public void Remove(MapNodeComponent node)
    {
        mList.Remove(node);
    }
}