/// <summary>
/// prototype设计模式实例
/// </summary>
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public abstract class ColorPrototype
{

    public abstract ColorPrototype Clone();
}

public class Color:ColorPrototype
{
    private int _red;
    private int _blue;
    private int _green;

    public Color(int red, int blue, int green)
    {
        _red = red;
        _blue = blue;
        _green = green;
    }

    //浅拷贝
    public override ColorPrototype Clone()
    {
        return this.MemberwiseClone() as ColorPrototype;
    }

    //深拷贝，主要是把对象内部的引用的对象也拷贝一份，不影响源对象
    //采用C#的序列化和反序列化来实现深拷贝
    public override ColorPrototype Clone()
    {
        using(MemoryStream ms = new MemoryStream())
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, this);
            ms.Position = 0；
            return bf.Deserialize(ms) as ColorPrototype;   
        }
    }
}

public class ColorMgr
{
    private Dictionary<string, ColorPrototype> _dic = new Dictionary<string, ColorPrototype>();

    public ColorPrototype this[string key]
    {
        get
        {
            return _dic[key];
        }
        set
        {
            _dic.add(key, value);
        }
    }
}

/// <summary>
/// 客户端类
/// </summary>
class Client
{
    static void Main(string[] args)
    {
        ColorMgr colorMgr = new ColorMgr();

        //这种实现防止了外部对对象的修改
        colorMgr["red"] = new Color(255, 0, 0);
        colorMgr["bule"] = new Color(0, 0, 255);
        colorMgr["green"] = new Color(0, 255, 0);
        colorMgr["white"] = new Color(255, 255, 255);



        //当需要颜色的时候，直接克隆
        //减少了new 的开销
        Color white = colorMgr["white"].Clone();

    }
}
