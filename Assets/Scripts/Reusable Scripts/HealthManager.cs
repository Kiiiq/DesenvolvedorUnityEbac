using DG.Tweening;
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

    public float deathAnimation, knockbackTime;


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
        if (this.gameObject.CompareTag("Player"))
        {
            if (!stateMachine.isImune) {
                StartCoroutine(ImunityFrames());
                currentLife -= Damage;
            }                      
        }
        else { currentLife -= Damage; }


        if (currentLife <= 0) {
            StartCoroutine(Kill(isDead));
        }
    }

    public IEnumerator Kill(bool isDead)
    {
        isDead = true;
        yield return new WaitForSeconds(deathAnimation);
        if (stateMachine != null && this.gameObject.CompareTag("Player"))
        {
            stateMachine.isDead = isDead;
        }
        else
        {
            Destroy(this.gameObject);
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

    public IEnumerator ImunityFrames()
    {
        stateMachine.sprite.DOBlendableColor(Color.red, 0.3f);
        stateMachine.isImune = true;
        yield return new WaitForSeconds(0.3f);
        stateMachine.sprite.DOColor(stateMachine.originalColor, 0.2f);
        yield return new WaitForSeconds(0.2f);
        stateMachine.isImune = false;
        
    }
}
