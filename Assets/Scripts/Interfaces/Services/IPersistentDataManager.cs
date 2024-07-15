public interface IPersistentDataManager : IService
{
    void SaveInt(string key, int value);
    void SaveString(string key, string value);
    void SaveFloat(string key, float value);

    int GetInt(string key, int defaultValue);
    string GetString(string key, string defaultValue);
    float GetFloat(string key, float defaultValue);
}
