

public class SerializableContext
{
    private ISerializable mSerializeStrategy;

    public SerializableContext(ISerializable strategy)
    {
        mSerializeStrategy = strategy;
    }

    public void ExecuteSerialize<T>(string filePath, T data)
    {
        mSerializeStrategy.Serialize(filePath, data);
    }

    public T ExecuteDeserialize<T>(string filePath)
    {
        return mSerializeStrategy.Deserialize<T>(filePath);
    }

}
