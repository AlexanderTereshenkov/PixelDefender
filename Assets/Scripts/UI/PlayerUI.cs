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

}
