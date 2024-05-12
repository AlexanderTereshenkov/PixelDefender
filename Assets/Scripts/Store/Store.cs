using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : InteractibleObject, IInteractible
{
    [SerializeField] GameObject storeUI;
    [SerializeField] int[] prices;


    private SingleGameEnterPoint singleGameEnterPoint;
    private Coin coin;
    private LampInsanityManager lampInsanityManager;

    public void Action(Inventory inventory)
    {
        storeUI.SetActive(true);
    }

    void Start()
    {
        singleGameEnterPoint = SingleGameEnterPoint.instance;
        coin = singleGameEnterPoint.GetCoin();
        lampInsanityManager = singleGameEnterPoint.GetLampInsanityManager();
    }

    public void Buy(int buttonID)
    {
        switch(buttonID)
        {
            case 0:
                if (lampInsanityManager.isFull(0) && coin.removeCoin(prices[0]))  lampInsanityManager.AddOil(25); 
                break;
            case 1:
                if (lampInsanityManager.isFull(1) && coin.removeCoin(prices[1])) lampInsanityManager.AddOil(50);
                break;
            case 2:
                if (lampInsanityManager.isFull(2) && coin.removeCoin(prices[2])) lampInsanityManager.DecreaseInsanity(25);
                break;
            case 3:
                if (lampInsanityManager.isFull(3) && coin.removeCoin(prices[3])) lampInsanityManager.DecreaseInsanity(50);
                break;
        }
    }
}
