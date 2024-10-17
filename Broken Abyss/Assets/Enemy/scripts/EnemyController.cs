using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : MonoBehaviour   
{
    public float speed = 3f;
    private float attackDamage = 0f;
    private float attackSpeed = 1f;
    private float canAttack;
    private Transform target;
    public Animator myAnim;
    // Start is called before the first frame update
    private void Start()
    {

        myAnim = GetComponent<Animator>();
        myAnim.SetBool("isAttacking", false);
        myAnim.SetBool("follow", false);
        canAttack = attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            myAnim.SetFloat("moveX", target.position.x - transform.position.x);
            myAnim.SetFloat("moveY", target.position.y - transform.position.y);
        }

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                myAnim.SetBool("isAttacking", true);
                canAttack = 0f;
                //other.gameObject.GetComponent<Health>
                
            }
            else
            {
                
                canAttack += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = other.transform;
            myAnim.SetBool("follow", true);
            canAttack = attackSpeed;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //target = null;
            myAnim.SetBool("follow", false);
        }
    }
    public void endAttack()
    {
        myAnim.SetBool("isAttacking",false);
    }

    
}
