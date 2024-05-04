using TMPro;
using UnityEngine;

public class SliderText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterSliderText;

    public void OnSliderValueChaged(float value)
    {
        counterSliderText.text = "Положить железо в печь: " + value.ToString();
    }
}
