using UnityEngine;
using UnityEngine.InputSystem;

public class Store : InteractibleObject, IInteractible
{
    [SerializeField] GameObject storeUI;
    [SerializeField] int[] prices;
    [SerializeField] private int smallOil;
    [SerializeField] private int largeOil;
    [SerializeField] private int smallPotion;
    [SerializeField] private int largePotion;


    private SingleGameEnterPoint singleGameEnterPoint;
    private Wallet coin;
    private LampInsanityManager lampInsanityManager;

    private InputActionMap playerMap;
    private InputActionMap systemMap;
    private PlayerInput playerInput;

    public void Action(Inventory inventory)
    {
        storeUI.SetActive(true);
        playerMap.Disable();
        systemMap.Enable();
        playerInput.defaultActionMap = "SystemButtons";
    }

    void Start()
    {
        singleGameEnterPoint = SingleGameEnterPoint.instance;
        coin = singleGameEnterPoint.GetCoin();
        lampInsanityManager = singleGameEnterPoint.GetLampInsanityManager();
        playerMap = SingleGameEnterPoint.instance.GetActionMap("Player");
        systemMap = SingleGameEnterPoint.instance.GetActionMap("SystemButtons");
        playerInput = SingleGameEnterPoint.instance.GetPlayer().GetComponent<PlayerInput>();
    }

    public void Buy(int buttonID)
    {
        switch(buttonID)
        {
            case 0:
                if (lampInsanityManager.isFull(0) && coin.removeCoin(prices[0]))  lampInsanityManager.AddOil(smallOil); 
                break;
            case 1:
                if (lampInsanityManager.isFull(1) && coin.removeCoin(prices[1])) lampInsanityManager.AddOil(largeOil);
                break;
            case 2:
                if (lampInsanityManager.isFull(2) && coin.removeCoin(prices[2])) lampInsanityManager.DecreaseInsanity(smallPotion);
                break;
            case 3:
                if (lampInsanityManager.isFull(3) && coin.removeCoin(prices[3])) lampInsanityManager.DecreaseInsanity(largePotion);
                break;
        }
    }

    public void CloseWindow()
    {
        storeUI.SetActive(false);
        playerMap.Enable();
        systemMap.Disable();
        playerInput.defaultActionMap = "Player";
    }
}
