using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("References")]

    [SerializeField] public Transform targetPosition;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] public GameObject CoinCollector;
    [SerializeField] public Rigidbody playerRigidbody;
    [SerializeField] public BoxCollider Collider;
    
    

    [Header("Parameters")]

    [Range(1f, 20f)] public float positionDivisor=1;
    [Range(0f, 50f)] public float fowardSpeed;
    [Range(0f, 5f)] public float sideSpeed;
    [SerializeField]private bool _isDead;
    public bool started = false;
    public bool Invincible;

    private void Start()
    {
        _isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDead||!started) return;
    
        playerRigidbody.velocity = new Vector3(sideSpeed*targetPosition.transform.position.x/positionDivisor,0,fowardSpeed);

       
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            _isDead = true;
            deathScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.CompareTag("FinishingLine")){
            _isDead = true;
            deathScreen.SetActive(true);
        }
    }

    public void StartGame()
    {
        started = true;
    }
}
