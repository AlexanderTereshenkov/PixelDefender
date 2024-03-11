using UnityEngine;

public class SingleGameEnterPoint : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerSpawnPosition;
    [SerializeField] private Transform playerParentObject;
    [Header("Camera")]
    [SerializeField] private CameraMovement cameraMovement;

    private void Awake()
    {
        var player = Instantiate(playerPrefab, playerParentObject);
        player.transform.position = playerSpawnPosition.position;

        cameraMovement.transform.position = player.transform.position;
        cameraMovement.Target = player.transform;
    }

}
