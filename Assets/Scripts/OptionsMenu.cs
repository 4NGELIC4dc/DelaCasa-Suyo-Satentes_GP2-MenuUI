using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Start()
    {
        if (AudioManager.instance != null)
        {
            bgmSlider.value = AudioManager.instance.bgmSource.volume;
            sfxSlider.value = AudioManager.instance.sfxSource.volume;

            bgmSlider.onValueChanged.AddListener(AudioManager.instance.AdjustBGMVolume);
            sfxSlider.onValueChanged.AddListener(AudioManager.instance.AdjustSFXVolume);
        }
    }
}
