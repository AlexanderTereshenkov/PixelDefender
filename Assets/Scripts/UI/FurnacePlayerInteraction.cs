using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FurnacePlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button acceptButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private Button takeResourcesButton;
    [SerializeField] private Slider slider;

    public event Action OnAcceptButtonPressed;
    public event Action OnCancelButtonPressed;
    public event Action OnTakeResourcesButtonPressed;

    public float SliderValue
    {
        get
        {
            return slider.value;
        }
    }

    private void Start()
    {
        acceptButton.onClick.AddListener(AcceptButtonPress);
        cancelButton.onClick.AddListener(CancelButtonPress);
        takeResourcesButton.onClick.AddListener(AddResourcesButtonPress);
    }

    public void OpenWindow(string txt, bool isDone)
    {
        if (screen.activeInHierarchy) return;
        if (isDone)
        {
            ShowAddButton();
        }
        else
        {
            HideAddButton();
        }
        screen.SetActive(true);
        text.text = txt;
    }

    public void CloseWindow()
    {
        screen.SetActive(false);
        HideAddButton();
    }

    public void UpdateStatusText(string txt)
    {
        text.text = txt;
    }

    public void ShowAddButton()
    {
        takeResourcesButton.gameObject.SetActive(true);
    }

    public void HideAddButton()
    {
        takeResourcesButton.gameObject.SetActive(false);
    }

    private void AcceptButtonPress()
    {
        OnAcceptButtonPressed?.Invoke();
    }

    private void CancelButtonPress()
    {
        OnCancelButtonPressed?.Invoke(); 
    }

    private void AddResourcesButtonPress()
    {
        OnTakeResourcesButtonPressed?.Invoke();
    }
}
