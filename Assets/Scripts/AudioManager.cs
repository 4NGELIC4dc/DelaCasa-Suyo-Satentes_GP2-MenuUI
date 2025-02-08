using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep audio alive in all scenes

            if (bgmSource != null)
                DontDestroyOnLoad(bgmSource.gameObject);

            if (sfxSource != null)
                DontDestroyOnLoad(sfxSource.gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        bgmSource.volume = PlayerPrefs.GetFloat("BGM_Volume", 1.0f);
        sfxSource.volume = PlayerPrefs.GetFloat("SFX_Volume", 1.0f);
    }

    public void AdjustBGMVolume(float volume)
    {
        if (bgmSource != null)
        {
            bgmSource.volume = volume;
            PlayerPrefs.SetFloat("BGM_Volume", volume);
        }
    }

    public void AdjustSFXVolume(float volume)
    {
        if (sfxSource != null)
        {
            sfxSource.volume = volume;
            PlayerPrefs.SetFloat("SFX_Volume", volume);
        }
    }

    public void PlayButtonSFX()
    {
        if (sfxSource != null && sfxSource.clip != null)
        {
            sfxSource.Play();
        }
    }
}
