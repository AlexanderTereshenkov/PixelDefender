using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int wood;
    private int stone;
    private int iron;
    private int ironIngot;
    private PlayerUI playerUI;
    public int Wood 
    {
        get
        {
            return wood;
        }
        set
        {
            wood = value;
            OnUIChanged(0, wood);
        }
    }
    public int Stone
    {
        get
        {
            return stone;
        }
        set
        {
            stone = value;
            OnUIChanged(1, stone);
        }
    }

    public int Iron
    {
        get
        {
            return iron;
        }
        set
        {
            iron = value;
            OnUIChanged(2, iron);
        }
    }

    public int IronIngot
    {
        get
        {
            return ironIngot;
        }
        set
        {
            ironIngot = value;
            OnUIChanged(3, ironIngot);
        }
    }

    private void Start()
    {
        playerUI = SingleGameEnterPoint.instance.GetPlayerUI();
    }


    private void OnUIChanged(int type, int value)
    {
        switch (type)
        {
            case 0:
                playerUI.WoodText = value;
                break;
            case 1:
                playerUI.StoneText = value;
                break;
            case 2:
                playerUI.IronText = value;
                break;
            case 3:
                playerUI.IronText = value;
                break;

        }
    }
}
