using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretArea : MonoBehaviour
{
    [SerializeField] GameObject Wall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Wall.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
