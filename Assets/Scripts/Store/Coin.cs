using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Wallet>().addCoin(value);
        Destroy(gameObject);
    }
}
