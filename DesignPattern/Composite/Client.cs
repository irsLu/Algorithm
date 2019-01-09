/// <summary>
/// Client.cs
/// Created by irs  2019-01-09
/// </summary>

using System;
using System.Reflection;

public class Client
{

    static void Main(string[] args)
    {
        MapNodeComponent singleTree = new Tree("SingleTree");

        MapLayerComposite forest = new MapLayerComposite("Forest");

        InitForest(forest);

        singleTree.Draw();

        forest.Draw();

        Console.ReadKey();
    }

    static void InitForest(MapLayerComposite forest)
    {
        for (int i = 0; i < 10; i++)
        {
            MapNodeComponent tree = new Tree("Tree" + i);
            MapNodeComponent grass = new Grass("Grass" + i);
            forest.Add(tree);
            forest.Add(grass);
        }
    }
}

