using UnityEngine;

public class ShopkeeperTriggerTest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the shopkeeper's area.");
        }
    }
}
