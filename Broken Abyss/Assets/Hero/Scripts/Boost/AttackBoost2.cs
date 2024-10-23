using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoost2 : MonoBehaviour
{
    //public float boost = 10f;
    //public float timer = 0f;

    [SerializeField] private float addAmount;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            var playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            Destroy(gameObject);
            playerHealth.AddHealth(addAmount);

            //GameObject player = collision.gameObject;
            //PlayerAttack playerScript = player.GetComponent<PlayerAttack>();

            //Destroy(gameObject);
            //playerScript.attackPower += boost;

            //while(timer != 10)
            //{
            //    timer += Time.deltaTime;
            //}

            //playerScript.moveSpeed -= boost;
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
