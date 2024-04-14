using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public float attackDuration;
    public Movement movement;
    public Actions actions;
<<<<<<< Updated upstream
=======
    public HealthManager healthManager;
    public Rigidbody2D hittedRigbody;
    public StateMachine stateMachine;
>>>>>>> Stashed changes

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
        if (collision.CompareTag("Spikes")) { 
            switch (actions.direction) {
<<<<<<< Updated upstream
                case 0: movement.playerRigidbody.velocity = new Vector2(-20,movement.playerRigidbody.velocity.y); break;
                case 1: movement.playerRigidbody.velocity = new Vector2(20, movement.playerRigidbody.velocity.y); break;
                case 2: movement.playerRigidbody.velocity = new Vector2(movement.playerRigidbody.velocity.x, -20); break;
                case 3: movement.playerRigidbody.velocity = new Vector2(movement.playerRigidbody.velocity.x, 30); movement.ableToDash = true; movement.ableToDoubleJump = true; break;
            }
        }
=======
                case 0: movement.playerRigidbody.velocity = new Vector2(-10,movement.playerRigidbody.velocity.y); break;
                case 1: movement.playerRigidbody.velocity = new Vector2(10, movement.playerRigidbody.velocity.y); break;
                case 2: movement.playerRigidbody.velocity = new Vector2(movement.playerRigidbody.velocity.x, -10); break;
                case 3: movement.playerRigidbody.velocity = new Vector2(movement.playerRigidbody.velocity.x, 30); stateMachine.ableToDash = true; stateMachine.ableToDoubleJump = true; break;
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
>>>>>>> Stashed changes
        
    }
}

    