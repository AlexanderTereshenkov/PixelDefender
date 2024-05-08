using System;
using System.Collections.Generic;
using UnityEngine;

public class GameplayHandler : MonoBehaviour
{
    private int daysCount;
    private MainWall mainWall;

    private List<IPausable> pausableList = new List<IPausable>();

    public event Action<bool> PauseStatusChanged;

    private void Start()
    {
        mainWall = SingleGameEnterPoint.instance.GetMainWall();
        mainWall.OnWallBroken += Loose;
        SingleGameEnterPoint.instance.GetWorldTime().OnDayPassed += IncreaseDay;
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
        SingleGameEnterPoint.instance.GetWorldTime().OnDayPassed -= IncreaseDay;
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
    }

    public void Resume()
    {
        foreach (var obj in pausableList)
        {
            obj.Resume();
        }
        Time.timeScale = 1;
        PauseStatusChanged?.Invoke(false);
    }

    private void Loose()
    {
        Debug.Log("You loose this game!");
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
