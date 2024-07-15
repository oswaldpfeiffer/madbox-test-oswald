using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : BaseService<IAudioManager>, IAudioManager
{
    [SerializeField]
    private AudioMixer GlobalMixer;
    [SerializeField]
    private AudioSource Source;
    [SerializeField]
    private List<SOAudioClip> AudioClips;

    private readonly Dictionary<EAudioClip, SOAudioClip> _audioClips = new Dictionary<EAudioClip, SOAudioClip>();

    private ISettingsManager _settingsManager;
    private ILogger _logger;

    private void Start()
    {
        _settingsManager = ServiceLocator.Instance.GetService<ISettingsManager>();
        _logger = ServiceLocator.Instance.GetService<ILogger>();
        UpdateAudioState();

        foreach(SOAudioClip clipSO in AudioClips)
        {
            _audioClips.Add(clipSO.ClipEnum, clipSO);
        }
    }

    public void UpdateAudioState ()
    {
        bool isOn = _settingsManager.IsAudioOn();
        GlobalMixer.SetFloat("GlobalVolume", isOn ? 0 : -80f);
    }

    public void PlayAudioClip (EAudioClip eclip, float pitch = 1, bool retrigger = true)
    {   SOAudioClip clipSO = _audioClips[eclip];
        if (clipSO == null)
        {
            _logger.Log("Audio clip " + eclip + " not registered!", ELogLevel.Warning);
            return;
        }
        bool canPlayClip = retrigger || Source.clip != clipSO.Clip || !Source.isPlaying;
        if (canPlayClip)
        {
            Source.pitch = pitch;
            Source.clip = clipSO.Clip;
            Source.volume = clipSO.Volume;
            Source.time = 0;
            Source.Play();
        }
    }
}
