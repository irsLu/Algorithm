using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Client
{
    static void Main(string[] args)
    {
        ATask task = new GetPorkTask();
        TaskSys.GetInstance().AddTask(task);

        ClickAutoTask(1);

        Console.ReadKey();
    }

    static void ClickAutoTask(int taskID)
    {
        AutoFacade.AutoTask(taskID);
    }

}

