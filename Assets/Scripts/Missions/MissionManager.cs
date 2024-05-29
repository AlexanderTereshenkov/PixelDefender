using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private Mission[] missions;

    private bool isMissionSet = false;
    private Mission currentMission;

    public void SetUpMission(int missionId)
    {
        foreach(var mission in missions) 
        {
            if(!isMissionSet && mission.GetMissionId() == missionId)
            {
                mission.ChangeMissionStatus(true);
                StartCoroutine(ShowMissionCoroutine(mission));
            }
        }
    }

    public void MissionCompleted(int missionId)
    {
        foreach (var mission in missions)
        {
            if (isMissionSet && mission.GetMissionId() == missionId)
            {
                mission.ChangeMissionStatus(false);
                currentMission = null;
                isMissionSet = false;
            }
        }
    }

    private IEnumerator ShowMissionCoroutine(Mission mission)
    {
        yield return new WaitForSeconds(3f);
        mission.ChangeMissionStatus(false);
        currentMission = mission;
        isMissionSet = true;
    }

    public void OnShowMission(InputAction.CallbackContext context)
    {
        if (currentMission != null && isMissionSet)
        {
            if (context.performed)
            {
                currentMission.ChangeMissionStatus(true);
            }
            else if (context.canceled)
            {
                currentMission.ChangeMissionStatus(false);
            }
        }
        
    }

}
