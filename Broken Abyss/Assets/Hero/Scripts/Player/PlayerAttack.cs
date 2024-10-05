using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Melee;
    private bool isAttacking = false;
    float attackDuration = 0.3f;
    float attackTimer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckMeleeTimer();


        if(Input.GetMouseButton(0))
        {
            OnAttack();
        }
    }

    void OnAttack()
    {
        if(!isAttacking)
        {
            Melee.SetActive(true);
            isAttacking = true;
        }
    }

    void CheckMeleeTimer() 
    {
        if(isAttacking)
        {
            attackTimer += Time.deltaTime;
            if(attackTimer >= attackDuration)
            {
                attackTimer = 0;
                isAttacking = false;
                Melee.SetActive(false);
            }
        }
    }
}
