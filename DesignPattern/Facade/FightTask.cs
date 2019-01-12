/// <summary>
/// FightTask.cs
/// Created by irs  2019-01-12
/// </summary>

using System;

public abstract class FightTask:ATask
{
    public struct Position
    {
        public readonly int X;
        public readonly int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public Position Pos;

    public String TargetNpc;

    public override void OnCompleteTask()
    {
        Console.WriteLine(this.Name + "had completed~");
    }

}