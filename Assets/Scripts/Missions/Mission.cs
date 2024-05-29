using UnityEngine;

public class Mission : MonoBehaviour
{
    [SerializeField] private int missionId;
    [SerializeField] private GameObject missionBanner;

    public int GetMissionId()
    {
        return missionId;
    }

    public void ChangeMissionStatus(bool status)
    {
        missionBanner.SetActive(status);
    }
}
