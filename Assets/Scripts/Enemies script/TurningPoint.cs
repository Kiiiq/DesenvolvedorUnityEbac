using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningPoint : MonoBehaviour
{
    EnemyBase enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemy = collision.GetComponent<EnemyBase>();
            if (enemy.isPatrol)
            {
                enemy.TurnEnemy();
            }
        }
    }
}
