using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxLife;
    public int currentLife=0;

    public Movement movement;

    public float deathAnimation;


    public void Awake()
    {
        currentLife = maxLife;    
    }

    public void Takedamage(int Damage)
    {
        currentLife -= Damage;

        if (currentLife <= 0) {
            StartCoroutine(Kill(movement.isDead));
        }
    }

    public IEnumerator Kill(bool isDead)
    {
        isDead = true;
        yield return new WaitForSeconds(0);
        Destroy(this.gameObject);
    }

}
