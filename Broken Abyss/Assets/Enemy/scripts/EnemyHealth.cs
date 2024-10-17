using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    private Animator myAnim;

    private void Start()
    {
        health = maxHealth;
        myAnim = GetComponent<Animator>();
    }

    public void UpdateHealth(float mod)
    {
        health += mod;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
    public void startHurt()
    {
        myAnim.SetBool("hurt", true);
    }
    public void endHurt()
    {
        myAnim.SetBool("hurt", false);
    }
}
