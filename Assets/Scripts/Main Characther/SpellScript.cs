using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    public StateMachine stateMachine;
    public Rigidbody2D SpellRigidbody;
    public Rigidbody2D hittedRigbody;
    public HealthManager healthManager;
    public Movement movement;
    public Actions actions;
    public float speed, attackDuration;
    public int damageMultipliyer;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponentInParent<StateMachine>();
        actions= GetComponentInParent<Actions>();
        movement = GetComponentInParent<Movement>();
        SpellRigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(TimeToDestroy());
        
        if (stateMachine.facingRight)
        {
            SpellRigidbody.velocity = new Vector2(speed, 0);
        }
        else
        {
            SpellRigidbody.velocity = new Vector2(-speed, 0);
        }

    }

    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(attackDuration);
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            hittedRigbody = collision.GetComponent<Rigidbody2D>();
            healthManager = collision.GetComponent<HealthManager>();
            healthManager.Takedamage(actions.damage * damageMultipliyer, movement.transform.position.x);

        }

    }

}
