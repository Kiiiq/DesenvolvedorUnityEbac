using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.Mathematics;
using UnityEngine;

public class ChasingSpell : MonoBehaviour
{
    GameObject player;
    Rigidbody2D Spell;
    public int Damage;
    public float maxSpeed, TotalAcceleration;
    Vector2 distance;
    float accelerationX, accelerationY, coeficientY, coeficientX;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Spell = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceCalculations();
        ChasePlayer(new Vector2(accelerationX, accelerationY));
    }

    public void DistanceCalculations()
    {
        distance = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        var absoluteDistance = math.sqrt(distance.x * distance.x + distance.y * distance.y);
        coeficientY = distance.y / absoluteDistance;
        coeficientX = distance.x / absoluteDistance;
        accelerationY = TotalAcceleration * coeficientY;
        accelerationX = TotalAcceleration * coeficientX;
    }

    public void ChasePlayer(Vector2 acceleration)
    {
        Spell.velocity = new Vector2(math.clamp(Spell.velocity.x+accelerationX,-maxSpeed, maxSpeed), math.clamp(Spell.velocity.y + acceleration.y,-maxSpeed,maxSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthManager healthManager;
        if (collision.transform.CompareTag("Player"))
        {
            healthManager = player.GetComponent<HealthManager>();
            healthManager.Takedamage(Damage, this.transform.position.x);
        }
        Destroy(this.gameObject);
    }
}
