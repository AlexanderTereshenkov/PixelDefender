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
    [SerializeField] private Slider slider;

    public event Action OnAcceptButtonPressed;
    public event Action OnCancelButtonPressed;

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
    }

    public void OpenWindow(string txt)
    {
        if (screen.activeInHierarchy) return;
        screen.SetActive(true);
        text.text = txt;
    }

    public void CloseWindow()
    {
        screen.SetActive(false);
    }

    public void UpdateStatusText(string txt)
    {
        text.text = txt;
    }

    private void AcceptButtonPress()
    {
        OnAcceptButtonPressed?.Invoke();
    }

    private void CancelButtonPress()
    {
        OnCancelButtonPressed?.Invoke(); 
    }
}
