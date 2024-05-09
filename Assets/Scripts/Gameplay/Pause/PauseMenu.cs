using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] otherUIElements;
    [SerializeField] private GameObject pauseMenu;

    private GameplayHandler gameplayHandler;

    private void Start()
    {
        gameplayHandler = SingleGameEnterPoint.instance.GetGameplayHandler();
       gameplayHandler.PauseStatusChanged += OnPauseStatusChaged;
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
        pauseMenu.SetActive(isPaused);
        foreach(var elem in otherUIElements)
        {
            elem.SetActive(!isPaused);
        }
    }
}
