using UnityEngine;

public class Furnace : InteractibleObject, IInteractible
{
    [SerializeField] private string status = "";
    [SerializeField] private float onePieceTime = 10;
    private FurnacePlayerInteraction furnacePlayerInteraction;
    private Inventory playerInventory;
    private bool isWorking;
    private float ironOre;
    private float tempTime;
    private float resultIronIngot;

    private void Start()
    {
        furnacePlayerInteraction = SingleGameEnterPoint.instance.GetPlayerUI().GetFurnanceDialogScreen();
        
        playerInventory = SingleGameEnterPoint.instance.GetPlayerInventory();
    }

    private void Update()
    {
        if (!isWorking) return;
        tempTime += Time.deltaTime;
        if(tempTime >= onePieceTime)
        {
            resultIronIngot++;
            tempTime = 0;
            if(resultIronIngot == ironOre)
            {
                isWorking = false;
                status = "Готово!";
                furnacePlayerInteraction.UpdateStatusText(status);
            }
        }
    }


    public void Action(Inventory inventory)
    {
        furnacePlayerInteraction.OpenWindow(status);
        furnacePlayerInteraction.OnAcceptButtonPressed += BeginAction;
        furnacePlayerInteraction.OnCancelButtonPressed += CancelAction;
    }

    private void BeginAction()
    {
        float wishfulIronCount = furnacePlayerInteraction.SliderValue;
        float playerIron = playerInventory.Iron;
        if (wishfulIronCount <= 0 || playerIron <= 0)
        {
            CancelAction();
            return;
        }
        if(playerIron <= wishfulIronCount)
        {
            ironOre = playerIron;
            isWorking = true;
            status = "В процессе";
            furnacePlayerInteraction.UpdateStatusText(status);
        }
    }

    private void CancelAction()
    {
        furnacePlayerInteraction.CloseWindow();
        furnacePlayerInteraction.OnAcceptButtonPressed -= BeginAction;
        furnacePlayerInteraction.OnCancelButtonPressed -= CancelAction;
    }
}
