using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI ironText;
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

}
