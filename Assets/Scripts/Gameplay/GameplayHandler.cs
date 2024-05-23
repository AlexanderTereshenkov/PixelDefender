using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayHandler : MonoBehaviour
{

    private MainGameplayObject mainWall;
    private List<IPausable> pausableList = new List<IPausable>();
    private InputActionMap playerMap;
    private InputActionMap systemButtonsMap;
    private SingleGameEnterPoint singleGameEnterPoint;

    public event Action<bool> PauseStatusChanged;
    public event Action OnGameEnded;
    public event Action OnGameWin;

    public bool IsGameFinished { get; set; }

    private void Start()
    {
        singleGameEnterPoint = SingleGameEnterPoint.instance;
        mainWall = singleGameEnterPoint.GetMainWall();
        playerMap = singleGameEnterPoint.GetActionMap("Player");
        systemButtonsMap = singleGameEnterPoint.GetActionMap("SystemButtons");
        mainWall.OnWallBroken += Loose;
        singleGameEnterPoint.GetMobSpawner().OnDayPassed += IncreaseDay;
    }
    private void OnEnable()
    {
        if(mainWall != null)
        {
            mainWall.OnWallBroken += Loose;
        }
    }
    private void OnDisable()
    {
        mainWall.OnWallBroken -= Loose;
        singleGameEnterPoint.GetMobSpawner().OnDayPassed -= IncreaseDay;
    }

    public void RegisterPausableobject(IPausable pausable)
    {
        pausableList.Add(pausable);
    }

    public void DeletePausableObject(IPausable pausable)
    {
        pausableList.Remove(pausable);
    }

    public void Pause()
    {
        foreach(var obj in pausableList)
        {
            obj.Pause();
        }
        Time.timeScale = 0;
        PauseStatusChanged?.Invoke(true);
        playerMap.Disable();
        systemButtonsMap.Enable();
    }

    public void Resume()
    {
        foreach (var obj in pausableList)
        {
            obj.Resume();
        }
        Time.timeScale = 1;
        PauseStatusChanged?.Invoke(false);
        playerMap.Enable();
        systemButtonsMap.Disable();
    }

    public void Loose()
    {
        IsGameFinished = true;
        Time.timeScale = 0;
        OnGameEnded?.Invoke();
    }

    private void Win()
    {
        IsGameFinished = true;
        Time.timeScale = 0;
        OnGameWin?.Invoke();
    }

    private void IncreaseDay(int days)
    {
        if (days >= 3)
            Win(); 
    }
}
