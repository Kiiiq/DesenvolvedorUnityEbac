using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    public bool facingRight;
    public float speed, direction;
    public Rigidbody2D Enemy;
    public StateMachine stateMachine;

    void Start()
    {
        Enemy = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    public virtual void Update()
    {

        if (facingRight) { direction = 1; }
        else { direction = -1; }

        Walk(direction);


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
