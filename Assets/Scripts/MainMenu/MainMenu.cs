using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite monkeyPicture;
    [SerializeField] private Sprite standartPicture;
    [SerializeField] private AudioClip standartMusic;
    [SerializeField] private AudioClip monkeyMusic;
    [SerializeField] private AudioSource backgroundMusic;

    private bool isFunnyPictureShown = false;

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void ShowCoolPicture()
    {
        if (!isFunnyPictureShown)
        {
            backgroundImage.sprite = monkeyPicture;
            isFunnyPictureShown = true;
            backgroundMusic.clip = monkeyMusic;
            backgroundMusic.Play();
            return;
        }
        backgroundImage.sprite = standartPicture;
        isFunnyPictureShown = false;
        backgroundMusic.clip = standartMusic;
        backgroundMusic.Play();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void ExitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
