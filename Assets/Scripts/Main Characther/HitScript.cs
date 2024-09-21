using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public float attackDuration;
    public Movement movement;
    public Actions actions;
    public HealthManager healthManager;
    public Rigidbody2D hittedRigbody;
    public StateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeToDestroy());
        stateMachine = GetComponentInParent<StateMachine>();    
        actions= GetComponentInParent<Actions>();
        movement= GetComponentInParent<Movement>();
    }

    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(attackDuration);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes") || collision.CompareTag("Enemy")) { 
            switch (actions.direction) {
                case 0: stateMachine.playerRigidbody.velocity = new Vector2(-10,stateMachine.playerRigidbody.velocity.y); break;
                case 1: stateMachine.playerRigidbody.velocity = new Vector2(10, stateMachine.playerRigidbody.velocity.y); break;
                case 2: stateMachine.playerRigidbody.velocity = new Vector2(stateMachine.playerRigidbody.velocity.x, -10); break;
                case 3: stateMachine.playerRigidbody.velocity = new Vector2(stateMachine.playerRigidbody.velocity.x, 30); stateMachine.ableToDash = true; stateMachine.ableToDoubleJump = true; break;
            }
        }

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            hittedRigbody=collision.GetComponent<Rigidbody2D>();
            healthManager=collision.GetComponent<HealthManager>();
            if (actions.maxStamina > actions.stamina)
            {
                actions.stamina++;
            }
            healthManager.Takedamage(actions.damage, movement.transform.position.x);
            
        }
        
    }
}

    