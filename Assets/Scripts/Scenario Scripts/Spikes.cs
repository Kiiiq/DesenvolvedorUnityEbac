using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spikes : MonoBehaviour
{

    
    int Damage = 1;
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthManager>();
    
        if (health != null )
        {
            if (collision.transform.CompareTag("Player"))
            {
                var safePlace = collision.gameObject.GetComponent<Movement>();
                safePlace.TpToSafePlace();
                health.Takedamage(Damage,this.transform.position.x);
                Debug.Log("Damage");
            }
        }
    }
}