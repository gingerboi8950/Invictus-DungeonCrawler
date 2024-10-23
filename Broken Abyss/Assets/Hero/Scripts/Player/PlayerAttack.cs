using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Melee;
    public GameObject Melee2;
    private bool isAttacking = false; // Check for light attack
    private bool isAttacking2 = false; // Check for heavy attack
    private float attackDuration = 0.1f; // Light attack
    private float attackDuration2 = 0.3f; // Heavy attack
    private float attackTimer = 0f;

    public float attackPower = 10f;

    private Inventory playerInventory;

    void Awake()
    {
        GameObject playerInventoryObject = GameObject.Find("HeroCanvas/PlayerInventory");
        playerInventory = playerInventoryObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMeleeTimer();


        if(Input.GetMouseButtonDown(0) && playerInventory.activeSlotIndexNum == 0)
        {
            OnAttack();
        }
        if(Input.GetMouseButtonDown(1) && playerInventory.activeSlotIndexNum == 0)
        {
            OnAttack2();
        }
    }

    void OnAttack() // Light Attack
    {
        if(!isAttacking)
        {
            Melee.SetActive(true);
            isAttacking = true;
        }
    }

    void OnAttack2() // Heavy Attack
    {
        if(!isAttacking2)
        {
            Melee2.SetActive(true);
            isAttacking2 = true;
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

        if(isAttacking2)
        {
            attackTimer += Time.deltaTime;
            if(attackTimer >= attackDuration2)
            {
                attackTimer = 0;
                isAttacking2 = false;
                Melee2.SetActive(false);                    
            }
        }
    }
}
