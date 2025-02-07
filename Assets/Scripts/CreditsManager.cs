using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public Button backButton;
    public AudioSource buttonClickSFX;

    void Start()
    {
        backButton.onClick.AddListener(GoBackToMenu);
    }

    void GoBackToMenu()
    {
        buttonClickSFX.Play();
        Invoke("LoadMenuScene", 0.3f); // Delay to allow sound to play
    }

    void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
