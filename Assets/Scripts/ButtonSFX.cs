using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonSFX : MonoBehaviour
{
    public string sceneToLoad = ""; 
    public bool isExitButton = false;
    public bool isStartButton = false;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(PlaySoundAndAct()));
    }

    IEnumerator PlaySoundAndAct()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayButtonSFX();
            yield return new WaitForSeconds(AudioManager.instance.sfxSource.clip.length);
        }

        if (isStartButton)
        {
            Debug.Log("The game is starting..."); // Show in Unity console
        }
        else if (isExitButton)
        {
            Application.Quit();
        }
        else if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
