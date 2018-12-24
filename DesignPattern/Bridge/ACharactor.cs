/// <summary>
/// ACharactor.cs
/// 角色基类
/// Created by irs  2018-12-24
/// </summary>

using System;
using UnityEngine;

public abstract class ACharactor
{
    public IWeapon implement;

    public string name;

    public ACharactor(IWeapon weapen)
    {
        implement = weapen;
    }

    public void Attack()
    {
        Debug.Log(this.name + " begin Attack: ");
        implement.Action();
    }
}