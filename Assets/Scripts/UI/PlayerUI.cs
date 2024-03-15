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
            woodText.text = "Камень: " + value.ToString();
        }
    }

    public int IronText
    {
        set
        {
            woodText.text = "Железо: " + value.ToString();
        }
    }

}
