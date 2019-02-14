using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// 因为unity 原生的字典不能序列化，所以实现自己的
/// </summary>
/// <typeparam name="TKey">字典key</typeparam>
/// <typeparam name="TValue">字典value</typeparam>
[Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    // 用list存放data  因为unity不允许其他
    [SerializeField]
    private List<TKey> mKeys;
    
    [SerializeField]
    private List<TValue> mValues;

    /// <summary>
    /// Before the serialization
    /// </summary>
    public void OnBeforeSerialize()
    {
        mKeys = new List<TKey>(this.Count);
        mValues = new List<TValue>(this.Count);
        foreach (var kvp in this)
        {
            mKeys.Add(kvp.Key);
            mValues.Add(kvp.Value);
        }
    }

    /// <summary>
    /// After the serialization
    /// </summary>
    public void OnAfterDeserialize()
    {
        this.Clear();
        int count = Mathf.Min(mKeys.Count, mValues.Count);
        for (int i = 0; i < count; ++i)
        {
            this.Add(mKeys[i], mValues[i]);
        }
    }
    
   
}