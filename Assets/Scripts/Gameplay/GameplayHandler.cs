using UnityEngine;

public class GameplayHandler : MonoBehaviour
{
    private int daysCount;
    private MainWall mainWall;

    private void Start()
    {
        mainWall = SingleGameEnterPoint.instance.GetMainWall();
        mainWall.OnWallBroken += Loose;
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
    }

    private void Loose()
    {
        Debug.Log("You loose this game!");
        Time.timeScale = 0;
    }

    private void Win()
    {

    }
}
