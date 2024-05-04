using UnityEngine;

public class SingleGameEnterPoint : MonoBehaviour
{
    public static SingleGameEnterPoint instance;

    [Header("Player")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerSpawnPosition;
    [Header("Camera")]
    [SerializeField] private CameraMovement cameraMovement;
    [Header("UI")]
    [SerializeField] private PlayerUI playerUI;
    [Header("PathManagment")]
    [SerializeField] private EnemyPathManager enemyPathManager;
    [Header("End Point")]
    [SerializeField] private Transform[] endPoints;
    [Header("Gameplay")]
    [SerializeField] private MainWall mainWall;

    private GameObject player;

    private void Awake()
    {
        player = Instantiate(playerPrefab, playerSpawnPosition.position, Quaternion.identity);

        cameraMovement.transform.position = player.transform.position;
        cameraMovement.Target = player.transform;

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            return;
        }
        Destroy(instance.gameObject);
    }

    public PlayerUI GetPlayerUI()
    {
        return playerUI;
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public EnemyPathManager GetEnemyPathManager() => enemyPathManager;

    public Transform GetRandomPoint() => endPoints[Random.RandomRange(0, endPoints.Length)];

    public MainWall GetMainWall() => mainWall;

}
