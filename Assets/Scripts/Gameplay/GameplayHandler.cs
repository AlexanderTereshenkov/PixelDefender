using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayHandler : MonoBehaviour
{
    private int daysCount;
    private MainWall mainWall;
    private List<IPausable> pausableList = new List<IPausable>();
    private InputActionMap playerMap;
    private SingleGameEnterPoint singleGameEnterPoint;

    public event Action<bool> PauseStatusChanged;

    public bool IsGameFinished { get; set; }

    private void Start()
    {
        singleGameEnterPoint = SingleGameEnterPoint.instance;
        mainWall = singleGameEnterPoint.GetMainWall();
        playerMap = singleGameEnterPoint.GetActionMap("Player");
        mainWall.OnWallBroken += Loose;
        singleGameEnterPoint.GetWorldTime().OnDayPassed += IncreaseDay;
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
        singleGameEnterPoint.GetWorldTime().OnDayPassed -= IncreaseDay;
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
    }

    private void Loose()
    {
        Debug.Log("You loose this game!");
        IsGameFinished = true;
        Time.timeScale = 0;
    }

    private void Win()
    {

    }

    private void IncreaseDay()
    {
        daysCount++;
    }
}
