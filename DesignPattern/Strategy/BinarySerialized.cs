
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Reflection;

public class BinarySerialized : ISerializable
{
   
    public T Deserialize<T>(string filePath)
    {
        if (!File.Exists(filePath))
            return default(T);

        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            BinaryFormatter bf = new BinaryFormatter();
            T data = (T) bf.Deserialize(fs);

            if (null != data)
                return data;
        }

        return default(T);
    }

    public void Serialize<T>(string filePath, T Data)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Data);
        }
    }

    /// <summary>
    /// 在反序列化使用的IFormatter 对象加入Binder 属性,使其获取要反序列化的对象所在的程序集
    /// </summary>
    public class UBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            return ass.GetType(typeName);
        }
    }

}
