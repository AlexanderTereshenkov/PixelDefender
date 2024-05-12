using UnityEngine;

public class PlayerInTownChecker : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out LampInsanityManager lampManager))
        {
            lampManager.SetLightCalculating(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out LampInsanityManager lampManager))
        {
            lampManager.SetLightCalculating(true);
        }
    }
}
