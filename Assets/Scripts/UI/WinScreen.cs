using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] otherUIElements;
    [SerializeField] private GameObject winScreen;

    private GameplayHandler gameplayHandler;
    void Start()
    {
        gameplayHandler = SingleGameEnterPoint.instance.GetGameplayHandler();
        gameplayHandler.OnGameWin += ShowWinScreen;
    }

    private void OnEnable()
    {
        if (gameplayHandler != null)
        {
            gameplayHandler.OnGameWin += ShowWinScreen;
        }
    }

    private void OnDisable()
    {
        gameplayHandler.OnGameWin -= ShowWinScreen;
    }

    private void ShowWinScreen()
    {
        foreach (var elem in otherUIElements)
        {
            elem.SetActive(false);
        }
        winScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
