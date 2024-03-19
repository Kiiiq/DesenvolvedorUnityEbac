using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Collider2D PlayerCollider;

    public Rigidbody2D playerRigidbody;

    public KeyCode Left = KeyCode.LeftArrow, Right = KeyCode.RightArrow, Jump = KeyCode.Z;

    public float Speed = 5;
    public float JumpDistance =10;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(Left))
        {
            playerRigidbody.velocity = new Vector2(-Speed, playerRigidbody.velocity.y);
        }
        else if (Input.GetKey(Right))
        {
            playerRigidbody.velocity = new Vector2(Speed,playerRigidbody.velocity.y);           
        }
        

    }

    
}
