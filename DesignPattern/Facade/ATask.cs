/// <summary>
/// ATask.cs
/// Created by irs  2019-01-12
/// </summary>

public abstract class ATask
{
    public string Name;

    public int ID;

    public TaskType Type;

    public enum TaskType
    {
        Fight,
        GoTo,
    }

    public abstract void OnCompleteTask();
}