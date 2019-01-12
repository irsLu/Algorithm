/// <summary>
/// GetPorkTask.cs
/// Created by irs  2019-01-12
/// </summary>

public class GetPorkTask:FightTask
{
    public GetPorkTask()
    {
        this.Name = "GetPorkTask";
        this.Pos = new Position(18, 20);
        this.TargetNpc = "Pig";
        this.ID = 1;
        this.Type = TaskType.Fight;
    }
}