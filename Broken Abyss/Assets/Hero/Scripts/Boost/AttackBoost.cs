using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoost : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            var playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            Destroy(gameObject);
            playerHealth.TakeDamage(damageAmount);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
