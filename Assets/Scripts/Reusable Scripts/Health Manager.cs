using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthManager : MonoBehaviour
{

    public Transform thisTransform;
    public Rigidbody2D thisRigidbody;
    public StateMachine stateMachine;

    public bool isDead;
    public int maxLife;
    public int currentLife=0;

<<<<<<< Updated upstream:Assets/Scripts/Reusable Scripts/Health Manager.cs
    public Movement movement;

    public float deathAnimation;
=======
    public float deathAnimation, knockbackTime;
>>>>>>> Stashed changes:Assets/Scripts/Reusable Scripts/HealthManager.cs


    public void Awake()
    {
        thisTransform = GetComponent<Transform>();
        thisRigidbody = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<StateMachine>();
        currentLife = maxLife;    
    }

    public void Takedamage(int Damage, float positionX)
    {
        StartCoroutine(TakeKnockback(positionX));
        currentLife -= Damage;

        if (currentLife <= 0) {
            StartCoroutine(Kill(movement.isDead));
        }
    }

    public IEnumerator Kill(bool isDead)
    {
        isDead = true;
        yield return new WaitForSeconds(deathAnimation);
        Destroy(this.gameObject);
        if (stateMachine!= null ) { 
            stateMachine.isDead = isDead;
        }
    }

    public IEnumerator TakeKnockback(float positionX)
    {
        if (positionX < thisTransform.position.x)
        {
            stateMachine.isTakingKnockback = true;
            thisRigidbody.velocity = new Vector2(10, 10);
            yield return new WaitForSeconds(knockbackTime);
            stateMachine.isTakingKnockback = false;
        }
        else
        {
            stateMachine.isTakingKnockback = true;
            thisRigidbody.velocity = new Vector2(-10, 10);
            yield return new WaitForSeconds(knockbackTime);
            stateMachine.isTakingKnockback = false;
        }
    }
}
