using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokePressurePlate : MonoBehaviour
{
    public GameObject Enemy;
    public Transform Location;
    public bool cooldown;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!cooldown && collision.CompareTag("Player")) {
            StartCoroutine(Invocar());

        }
    }

    IEnumerator Invocar()
    {
        cooldown = true;
        Instantiate(Enemy, Location);
        yield return new WaitForSeconds(5);
        cooldown = false;
    }
}
