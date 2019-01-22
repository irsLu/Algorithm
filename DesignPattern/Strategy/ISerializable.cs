


public interface ISerializable
{
    void Serialize<T>(string filePath, T Data);

    T Deserialize<T>(string filePath);
}
