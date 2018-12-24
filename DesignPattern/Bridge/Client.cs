/// <summary>
/// Client.cs
/// 武器接口
/// Created by irs  2018-12-24
/// </summary>


public class Client
{
    public void Init()
    {
        ACharactor daidai = new DaiDai(new Sword());

        daidai.Attack();
    }
}