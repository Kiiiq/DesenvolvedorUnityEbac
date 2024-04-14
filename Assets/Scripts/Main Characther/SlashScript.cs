using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    public float attackDuration;
    public int damageMultipliyer;
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
        actions = GetComponentInParent<Actions>();
        movement = GetComponentInParent<Movement>();
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
            healthManager.Takedamage(actions.damage*damageMultipliyer, movement.transform.position.x);

        }

    }
}

