using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSource targetAudioSource; 
    public Slider volumeSlider;           

    void Start()
    {
        
        if (targetAudioSource != null && volumeSlider != null)
        {
            volumeSlider.value = targetAudioSource.volume;

            
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    void SetVolume(float value)
    {
        if (targetAudioSource != null)
        {
            targetAudioSource.volume = value;
        }
    }
}
