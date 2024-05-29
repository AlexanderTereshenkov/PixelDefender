using UnityEngine;

public class ShowHint : MonoBehaviour
{
    [SerializeField] private InformationPanel pannel;
    [SerializeField] private string message;

    private void OnMouseEnter()
    {
        pannel.ShowHint(message);
    }

    private void OnMouseExit()
    {
        pannel.HideHint();
    }
}
