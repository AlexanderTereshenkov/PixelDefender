using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseScreen : MonoBehaviour
{
    [SerializeField] private GameObject[] otherUIElements;
    [SerializeField] private GameObject looseScreen;

    private GameplayHandler gameplayHandler;

    private void Start()
    {
        gameplayHandler = SingleGameEnterPoint.instance.GetGameplayHandler();
        gameplayHandler.OnGameEnded += ShowLooseScreen;
    }

    private void OnEnable()
    {
        if (gameplayHandler != null)
        {
            gameplayHandler.OnGameEnded += ShowLooseScreen;
        }
    }

    private void OnDisable()
    {
        gameplayHandler.OnGameEnded -= ShowLooseScreen;
    }

    private void ShowLooseScreen()
    {
        foreach (var elem in otherUIElements)
        {
            elem.SetActive(false);
        }
        looseScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
