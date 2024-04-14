using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectableAction();
            Destroy(this.gameObject);
        }
    }
    
    public virtual void CollectableAction() { }
}
