using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float currentHealth = 100f;
    [SerializeField]
    private float maxHealth = 100f;
    
    public float RemainingHealthPercent
    {
        get
        {
            return currentHealth/maxHealth;
        }
    }

    public UnityEvent OnHealthChanged;

    public void TakeDamage(float damageAmount)
    {
        if(currentHealth == 0)
        {
            return;
        }

        currentHealth -= damageAmount;

        OnHealthChanged.Invoke();

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void AddHealth(float addAmount)
    {
        if(currentHealth == maxHealth)
        {
            return;
        }

        currentHealth += addAmount;

        OnHealthChanged.Invoke();

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
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
