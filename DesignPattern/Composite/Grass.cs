/// <summary>
/// Grass.cs
/// Created by irs  2019-01-09
/// </summary>

using System;

public class Grass : MapNodeComponent
{
    public Grass(string name) : base(name) { }

    public override void Draw()
    {
        Console.WriteLine(this.Name + " on Draw~");
    }
}