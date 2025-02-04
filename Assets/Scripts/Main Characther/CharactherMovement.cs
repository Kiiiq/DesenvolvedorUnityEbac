using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarachterMovement : MonoBehaviour
{
    [SerializeField] public Transform targetPosition;
    [Range(0f,5f)] public float LerpSpeed;
    [SerializeField] private GameObject DeathScreen;

    private bool _isDead;

    private void Start()
    {
        _isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDead) return;

        this.transform.position = Vector3.Lerp(this.transform.position,targetPosition.position, LerpSpeed*Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy")) _isDead = true;
        DeathScreen.SetActive(true);
    }
}
