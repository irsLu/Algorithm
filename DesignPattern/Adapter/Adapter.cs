/// <summary>
/// Adapter.cs
/// Created by irs  2018-12-29
/// </summary>

using System;

public class Adapter:ID
{
    private ND newImp;

    public Adapter(ND obj)
    {
        this.newImp = obj;
    }

    public void Log(string msg)
    {
        newImp.NLog(msg, DateTime.Now);
    }

    public void Warning(string msg)
    {
        newImp.NWarning(msg, DateTime.Now);
    }

    public void Error(string msg)
    {
        newImp.NError(msg, DateTime.Now);
    }
}