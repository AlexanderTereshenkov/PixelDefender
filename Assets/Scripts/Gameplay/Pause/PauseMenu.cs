using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject[] otherUIElements;

    private GameplayHandler gameplayHandler;

    private void Start()
    {
        gameplayHandler = SingleGameEnterPoint.instance.GetGameplayHandler();
        gameplayHandler.PauseStatusChanged += OnPauseStatusChaged;
    }

    private void OnEnable()
    {
        if(gameplayHandler != null)
        {
            gameplayHandler.PauseStatusChanged += OnPauseStatusChaged;
        }
    }

    private void OnDisable()
    {
        gameplayHandler.PauseStatusChanged -= OnPauseStatusChaged;
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        foreach (var elem in otherUIElements)
        {
            elem.SetActive(true);
        }
        gameplayHandler.Resume();
    }

    private void OnPauseStatusChaged(bool isPaused)
    {
        foreach(var elem in otherUIElements)
        {
            elem.SetActive(!isPaused);
        }
        pauseMenu.SetActive(isPaused);
    }
}
