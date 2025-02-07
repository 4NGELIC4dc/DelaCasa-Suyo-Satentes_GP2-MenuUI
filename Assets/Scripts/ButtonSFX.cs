using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonSFX : MonoBehaviour
{
    public AudioSource audioSource;
    public string sceneToLoad = ""; // Leave empty for buttons that don't change scenes
    public bool isExitButton = false; // Mark this as true for exit button

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(PlaySoundAndAct()));
    }

    IEnumerator PlaySoundAndAct()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length); // Wait for the sound to finish

        if (isExitButton)
        {
            Application.Quit(); // Quit the game after the sound plays
        }
        else if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad); // Load the scene after the sound plays
        }
    }
}
