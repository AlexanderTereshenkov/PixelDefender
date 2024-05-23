using TMPro;
using UnityEngine;

public class InformationPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI infoText;

    public void ShowHint(string text)
    {
        infoText.text = text;
    }

}
