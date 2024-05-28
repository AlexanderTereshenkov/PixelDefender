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
            return;
        }
        backgroundImage.sprite = standartPicture;
        isFunnyPictureShown = false;
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
