/// <summary>
/// Client.cs
/// Created by irs  2019-2-11
/// </summary>

using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;

using TFW;

public class Client
{

    static void Main(string[] args)
    {
        Console.WriteLine("begin preProcess");

        ProcessMgr.PreProcess();

        Console.WriteLine("processing......");

        ProcessMgr.PostProcess();

        Console.ReadKey();
    }
}



