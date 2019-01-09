/// <summary>
/// Tree.cs
/// Created by irs  2019-01-09
/// </summary>

using System;

public class Tree:MapNodeComponent
{
    public Tree(string name) : base(name) { }

    public override void Draw()
    {
        Console.WriteLine(this.Name + " on Draw~");
    }
}
