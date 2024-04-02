using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public float attackDuration;
    public Movement movement;
    public Actions actions;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeToDestroy());
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
                case 0: movement.playerRigidbody.velocity = new Vector2(-20,movement.playerRigidbody.velocity.y); break;
                case 1: movement.playerRigidbody.velocity = new Vector2(20, movement.playerRigidbody.velocity.y); break;
                case 2: movement.playerRigidbody.velocity = new Vector2(movement.playerRigidbody.velocity.x, -20); break;
                case 3: movement.playerRigidbody.velocity = new Vector2(movement.playerRigidbody.velocity.x, 30); movement.ableToDash = true; movement.ableToDoubleJump = true; break;
            }
        }
        
    }
}

    