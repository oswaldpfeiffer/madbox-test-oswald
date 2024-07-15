public interface ISettingsManager : IService
{
    bool IsAudioOn();
    bool IsHapticOn();
    void SetAudioState(bool on);
    void SetHapticState(bool on);
}
