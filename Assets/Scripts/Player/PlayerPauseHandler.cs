using UnityEngine;

public class PlayerPauseHandler : MonoBehaviour, IPausable
{
    private IPausablePlayer[] pausable;

    void Start()
    {
        pausable = GetComponents<IPausablePlayer>();
        SingleGameEnterPoint.instance.GetGameplayHandler().RegisterPausableobject(this);
    }

    private void OnDestroy()
    {
        SingleGameEnterPoint.instance.GetGameplayHandler().DeletePausableObject(this);
    }

    public void Pause()
    {
        foreach(var pausableObj in pausable)
        {
            pausableObj.Pause();
        }
    }

    public void Resume()
    {
        foreach (var pausableObj in pausable)
        {
            pausableObj.Resume();
        }
    }

}
