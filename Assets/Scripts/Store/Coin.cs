using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{   
    [SerializeField] private int coins;
    

    private TextMeshProUGUI textCoin;
    void Start()
    {
       textCoin = SingleGameEnterPoint.instance.GetPlayerUI().GetCoinText();
       textCoin.text = coins.ToString();
    }

    public void addCoin(int coin)
    {
        coins += coin;
        textCoin.text = coin.ToString();
    }

    public bool removeCoin(int coin)
    {
        if(coins >= coin) {
            coins -= coin; 
            textCoin.text = coins.ToString();
            return true;
        }
        return false;
    }
}
