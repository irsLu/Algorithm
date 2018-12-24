/// <summary>
/// IWeapon.cs
/// 武器接口
/// Created by irs  2018-12-24
/// </summary>

using System;
using UnityEngine;

public abstract IWeapon
{
    public string name;

    public abstract void Action();
}