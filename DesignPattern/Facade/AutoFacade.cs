/// <summary>
/// AutoFacade.cs
/// Created by irs  2019-01-12
/// </summary>

using System;

class AutoFacade
{
    public static void AutoTask(int taskID)
    {
        ATask task = TaskSys.GetInstance().GetTask(taskID);

        if (null == task)
            return;

        if(task.Type == ATask.TaskType.Fight)
        {
            AutoFightTask(task as FightTask);
        }
    }

    private static void AutoFightTask(FightTask task)
    {
        PathFindingSys.GetInstance().Finding(task.Pos.X, task.Pos.Y);

        BattleSys.GetInstance().Fight(task.TargetNpc);

        task.OnCompleteTask();
    }

}