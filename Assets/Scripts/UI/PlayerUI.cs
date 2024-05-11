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
    [SerializeField] private TextMeshProUGUI coinText;

    [Header("Screen")]
    [SerializeField] private FurnacePlayerInteraction furnaceDialogScreen;
    [SerializeField] private Image iconPlace;

    [Header("UIElements")]
    [SerializeField] private Slider oilSlider;
    [SerializeField] private Slider insanityLevelSlider;

    public int WoodText 
    { 
        set
        {
            woodText.text = "Дерево: " + value.ToString();
        }
    }

    public int StoneText
    {
        set
        {
            stoneText.text = "Камень: " + value.ToString();
        }
    }

    public int IronText
    {
        set
        {
            ironText.text = "Железо: " + value.ToString();
        }
    }

    public int IronIngotText
    {
        set
        {
            ironIngotText.text = "Слитки: " + value.ToString();
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

    public Slider GetOilSlider() => oilSlider;

    public Slider GetInsanitySlider () => insanityLevelSlider;

    public TextMeshProUGUI GetCoinText() => coinText;

}
