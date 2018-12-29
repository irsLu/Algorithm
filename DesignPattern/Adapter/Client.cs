/// <summary>
/// Client.cs
/// Created by irs  2018-12-29
/// </summary>

using System;

public class Client
{

    static void Main(string[] args)
    {
        ID D = new DImp();

        D.Log("pala~ pala~ pala~");

        D = new Adapter(new ND());

        D.Log("pala~ pala~ pala~");

        Console.ReadKey();
    }

}

