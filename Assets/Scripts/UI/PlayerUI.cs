using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI ironText;
    [SerializeField] private TextMeshProUGUI ironIngotText;
    [SerializeField] private TextMeshProUGUI timerText;

    [Header("Screen")]
    [SerializeField] private FurnacePlayerInteraction furnaceDialogScreen;
    [SerializeField] private Image iconPlace;

    public int WoodText 
    { 
        set
        {
            woodText.text = "������: " + value.ToString();
        }
    }

    public int StoneText
    {
        set
        {
            stoneText.text = "������: " + value.ToString();
        }
    }

    public int IronText
    {
        set
        {
            ironText.text = "������: " + value.ToString();
        }
    }

    public int IronIngotText
    {
        set
        {
            ironIngotText.text = "������: " + value.ToString();
        }
    }

    public string TimerText 
    {
        set
        {
            timerText.text = value;
        }
    }

    public FurnacePlayerInteraction GetFurnanceDialogScreen() => furnaceDialogScreen;

    public Image GetIconPlace() => iconPlace;

}
