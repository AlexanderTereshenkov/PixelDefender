using UnityEngine;

public class ShowHint : MonoBehaviour
{
    [SerializeField] private MainGameplayObject hintInfoObject;
    [SerializeField] private InformationPanel informationPanel;

    private void OnEnable()
    {
        hintInfoObject.OnValueChanged += UpdateValue;
    }

    private void OnDisable()
    {
        hintInfoObject.OnValueChanged -= UpdateValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMovement playerMovement))
        {
            informationPanel.gameObject.SetActive(true);
            informationPanel.ShowHint(hintInfoObject.GetInfo());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement playerMovement))
        {
            informationPanel.gameObject.SetActive(false);
        }
    }

    private void UpdateValue()
    {
        informationPanel.ShowHint(hintInfoObject.GetInfo());
    }

}
