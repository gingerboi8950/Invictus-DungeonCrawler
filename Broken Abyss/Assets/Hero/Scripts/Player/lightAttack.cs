using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().UpdateHealth(-10f);
            collision.gameObject.GetComponent<EnemyHealth>().startHurt();
        }
    }
}
