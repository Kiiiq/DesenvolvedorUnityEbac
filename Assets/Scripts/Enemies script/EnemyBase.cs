using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public bool isPatrol, facingRight;
    public float speed, direction;
    public Rigidbody2D Enemy;
    public Transform playerPosition;
    public StateMachine stateMachine;

    void Start()
    {
        isPatrol = true;
        Enemy=GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        ChasePlayer();

        if (facingRight) { direction = 1; }
        else { direction = -1; }
        
        Walk(direction); 
        

    }

    public virtual void ChasePlayer()
    {
        if (playerPosition != null)
        {
            if (playerPosition.position.x > this.transform.position.x)
            {
                facingRight = true;
            }
            else
            {
                facingRight = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isPatrol)
        {
            playerPosition = collision.GetComponent<Transform>();
            isPatrol=false;
            speed *= 2;
        }
    }

    public virtual void TurnEnemy()
    {
        if (facingRight) { facingRight = false; transform.rotation = Quaternion.Euler(0, 180, 0); }
        else { facingRight = true; transform.rotation = Quaternion.Euler(0, 0, 0); }
    }

    public virtual void Walk(float direction)
    {
        Enemy.velocity = new Vector2(speed * direction, Enemy.velocity.y);
    }
}
