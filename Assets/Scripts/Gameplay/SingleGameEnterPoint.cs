using UnityEngine;
using UnityEngine.InputSystem;

public class SingleGameEnterPoint : MonoBehaviour
{
    public static SingleGameEnterPoint instance;

    [Header("Player")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerSpawnPosition;
    [SerializeField] private InputActionAsset inputActionAsset;

    [Header("Camera")]
    [SerializeField] private CameraMovement cameraMovement;
    [Header("UI")]
    [SerializeField] private PlayerUI playerUI;
    [Header("PathManagment")]
    [SerializeField] private EnemyPathManager enemyPathManager;
    [Header("End Point")]
    [SerializeField] private Transform[] endPoints;
    [Header("Gameplay")]
    [SerializeField] private MainGameplayObject mainWall;
    [SerializeField] private GameplayHandler gameplayHandler;
    [SerializeField] private WorldTime worldTime;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private MobSpapwner mobSpawner;

    private GameObject player;
    private Inventory playerInventory;
    private Coin playerCoin;
    private LampInsanityManager lampInsanityManager;

    private void Awake()
    {
        Time.timeScale = 1;

        player = Instantiate(playerPrefab, playerSpawnPosition.position, Quaternion.identity);

        playerInventory = player.GetComponent<Inventory>();
        playerCoin = player.GetComponent<Coin>();
        lampInsanityManager = player.GetComponent<LampInsanityManager>();

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

    public Transform GetRandomPoint() => endPoints[Random.Range(0, endPoints.Length)];

    public MainGameplayObject GetMainWall() => mainWall;

    public GameplayHandler GetGameplayHandler() => gameplayHandler;

    public Inventory GetPlayerInventory() => playerInventory;

    public WorldTime GetWorldTime() => worldTime;

    public InputActionMap GetActionMap(string name) => inputActionAsset.FindActionMap(name);

    public Transform GetExitPoint() => exitPoint;

    public Coin GetCoin() => playerCoin;

    public LampInsanityManager GetLampInsanityManager() => lampInsanityManager;

    public MobSpapwner GetMobSpawner() => mobSpawner;
}
