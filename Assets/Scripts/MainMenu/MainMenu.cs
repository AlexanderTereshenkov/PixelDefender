using UnityEngine;
using UnityEngine.SceneManagement;  

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Texture2D defaultCursor;

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
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
