using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : EnemyBase
{
    public bool ableToJump, ableToWalk;
    public float jumpingRange, timeToJump, jumpTime, jumpDistance;

    void Start()
    {
        isPatrol = true;
        Enemy = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<StateMachine>();
        ableToJump = true;
    }

    // Update is called once per frame
    public override void Update()
    { 
        ChasePlayer();
        
        if (facingRight) { direction = 1; }
        else { direction = -1; }
        if (ableToWalk)
        {
            Walk(direction);
        }
    }

    public override void ChasePlayer()
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

            if (playerPosition.position.x - this.transform.position.x <= Mathf.Abs(jumpingRange) && ableToJump)
            {
                StartCoroutine(jumpAttack(direction));
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Floor")){
            
            ableToWalk = true;
            StartCoroutine(recoverFromJump());
            if (!ableToJump)
            {
                speed *= 2;
            }
        }
    }

    public IEnumerator jumpAttack(float direction) {
        ableToJump = false;
        ableToWalk = false;
        Enemy.velocity = Vector2.zero;
        yield return new WaitForSeconds(timeToJump);
        ableToWalk = true;
        speed /= 2;
        Enemy.gravityScale = 0;
        Enemy.velocity = new Vector2(speed * direction, jumpDistance);
        yield return new WaitForSeconds(jumpTime);
        Enemy.gravityScale = 10;
    }

    public IEnumerator recoverFromJump()
    {
        yield return new WaitForSeconds(jumpTime);
        ableToJump = true;
    }
}
