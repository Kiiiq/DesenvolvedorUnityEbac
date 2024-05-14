using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
    Rigidbody2D Fly;
    Transform player;
    public float Xspeed, Yspeed;

    void Start()
    {
        Fly = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Fly.velocity = new Vector2(Xspeed, Yspeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Floor") || collision.transform.CompareTag("Ceilling"))
        {
            Yspeed = -Yspeed;
        }
        if (collision.transform.CompareTag("Wall"))
        {
            Xspeed = -Xspeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Attack") )
        {
            if (player == null)
            {
                player = collision.GetComponentInParent<Transform>();
            }

            if (math.abs(player.transform.position.y - this.transform.position.y) > 0.7f)
            {
                if(player.transform.position.y > this.transform.position.y)
                {
                    Yspeed = -(math.abs(Yspeed));
                }
                else
                {
                    Yspeed = (math.abs(Yspeed));
                }
            }
            else
            {
                if (player.transform.position.x > this.transform.position.x)
                {
                    Xspeed = -(math.abs(Xspeed));
                }
                else
                {
                    Xspeed = (math.abs(Xspeed));
                }
            }
        }

        

    }
}
