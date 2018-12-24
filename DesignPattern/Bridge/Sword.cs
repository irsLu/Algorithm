/// <summary>
/// Sword.cs
/// 剑
/// Created by irs  2018-12-24
/// </summary>

using System;
using UnityEngine;

public class Sword:IWeapon
{
    public void class Sword()
    {
        this.name = "EX";
    }

    public void Action()
    {
        Debug.Log(this.name + "stab !");
    }
}