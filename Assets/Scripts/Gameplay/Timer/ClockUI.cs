using UnityEngine;

public class ClockUI : MonoBehaviour
{
    [SerializeField]private WorldTime worldTime;
    private PlayerUI playerUI;

    private void Start()
    {
        playerUI = SingleGameEnterPoint.instance.GetPlayerUI();
    }

    private void OnEnable()
    {
        worldTime.OnTimeChaged += UpdateTimerUI;
    }

    private void OnDisable()
    {
        worldTime.OnTimeChaged -= UpdateTimerUI;
    }

    private void UpdateTimerUI()
    {
        playerUI.TimerText = worldTime.GetTime();
    }
}
