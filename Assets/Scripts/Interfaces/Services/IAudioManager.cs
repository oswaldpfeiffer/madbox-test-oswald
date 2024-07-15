public interface IAudioManager : IService
{
    void PlayAudioClip(EAudioClip clip, float pitch = 1, bool retrigger = true);
    void UpdateAudioState();
}
