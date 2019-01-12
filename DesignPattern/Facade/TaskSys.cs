/// <summary>
/// TaskSys.cs
/// Created by irs  2019-01-12
/// </summary>

using System;
using System.Collections.Generic;

class TaskSys
{
    private static TaskSys _instance = new TaskSys();

    private TaskSys() { }

    public static TaskSys GetInstance()
    {
        return _instance;
    }

    private Dictionary<int, ATask> mSelfTasks = new Dictionary<int, ATask>();

    public void AddTask(ATask task)
    {
        mSelfTasks[task.ID] = task;
    }

    public ATask GetTask(int id)
    {
        if(mSelfTasks.ContainsKey(id))
        {
            return mSelfTasks[id];
        }

        return null;
    }

}