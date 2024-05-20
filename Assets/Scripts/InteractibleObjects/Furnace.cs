using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Furnace : InteractibleObject, IInteractible
{
    [SerializeField] private string status = "";
    [SerializeField] private float onePieceTime = 10;
    [SerializeField] private Sprite fireFurnace;
    [SerializeField] private Light2D fireLight;

    private FurnacePlayerInteraction furnacePlayerInteraction;
    private Inventory playerInventory;
    private bool isWorking;
    private bool isDone;
    private bool isOpened = false;
    private float ironOre;
    private float tempTime;
    private float resultIronIngot;
    private SpriteRenderer spriteRenderer;
    private Sprite defaultFurnace;
    private InputActionMap playerMap;
    private InputActionMap systemMap;
    private PlayerInput playerInput;

    private void Start()
    {
        furnacePlayerInteraction = SingleGameEnterPoint.instance.GetPlayerUI().GetFurnanceDialogScreen();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultFurnace = spriteRenderer.sprite;
        playerInventory = SingleGameEnterPoint.instance.GetPlayerInventory();
        playerMap = SingleGameEnterPoint.instance.GetActionMap("Player");
        systemMap = SingleGameEnterPoint.instance.GetActionMap("SystemButtons");
        playerInput = SingleGameEnterPoint.instance.GetPlayer().GetComponent<PlayerInput>();
        fireLight.intensity = 0;
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
                status = "Готово! Забрать слитки: " + ironOre.ToString();
                isDone = true;
                if (isOpened)
                {
                    furnacePlayerInteraction.UpdateStatusText(status);
                    furnacePlayerInteraction.ShowAddButton();
                }
                spriteRenderer.sprite = defaultFurnace;
                resultIronIngot = 0;
                fireLight.intensity = 0;
            }
        }
    }


    public void Action(Inventory inventory)
    {
        furnacePlayerInteraction.OpenWindow(status, isDone);
        playerMap.Disable();
        systemMap.Enable();
        isOpened = true;
        playerInput.defaultActionMap = "SystemButtons";
        furnacePlayerInteraction.OnAcceptButtonPressed += BeginAction;
        furnacePlayerInteraction.OnCancelButtonPressed += CancelAction;
        furnacePlayerInteraction.OnTakeResourcesButtonPressed += AddIngotsToInventory;
    }

    private void BeginAction()
    {
        if (isDone || isWorking) return;
        float wishfulIronCount = furnacePlayerInteraction.SliderValue;
        float playerIron = playerInventory.Iron;
        if (wishfulIronCount <= 0 || playerIron <= 0)
        {
            CancelAction();
            return;
        }
        float iron = playerIron < wishfulIronCount ? playerIron : wishfulIronCount;
        ironOre = iron;
        playerInventory.Iron = Convert.ToInt32(playerIron - iron);
        isWorking = true;
        status = "В процессе";
        spriteRenderer.sprite = fireFurnace;
        furnacePlayerInteraction.UpdateStatusText(status);
        fireLight.intensity = 5;
    }

    private void CancelAction()
    {
        furnacePlayerInteraction.CloseWindow();
        playerMap.Enable();
        systemMap.Disable();
        isOpened = false;
        playerInput.defaultActionMap = "Player";
        furnacePlayerInteraction.OnAcceptButtonPressed -= BeginAction;
        furnacePlayerInteraction.OnCancelButtonPressed -= CancelAction;
        furnacePlayerInteraction.OnTakeResourcesButtonPressed -= AddIngotsToInventory;
    }

    private void AddIngotsToInventory()
    {
        playerInventory.IronIngot += Convert.ToInt32(ironOre);
        ironOre = 0;
        isDone = false;
        furnacePlayerInteraction.HideAddButton();
        status = "";
        furnacePlayerInteraction.UpdateStatusText(status);
    }
}
