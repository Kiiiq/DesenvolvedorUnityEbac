using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MosquitoScript : MonoBehaviour
{
    bool idle=true;
    Transform player;
    float speedX, speedY, coeficientX, coeficientY;
    [SerializeField]public float totalSpeed;
    Vector2 distance;
    Rigidbody2D mosquito;

    private void Start()
    {
        mosquito = GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
    }
    // Update is called once per frame
    void Update()
    {
        if (!idle)
        {
            DistanceCalculations();
            ChasePlayer(new Vector2(speedX,speedY));
<<<<<<< Updated upstream
        } else
        {
            StartCoroutine(IdleMove());
        }
=======
        } 
>>>>>>> Stashed changes
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
<<<<<<< Updated upstream
=======
            StopAllCoroutines();
>>>>>>> Stashed changes
            idle = false;
            player = collision.GetComponent<Transform>();
        }
    }

    public IEnumerator IdleMove()
<<<<<<< Updated upstream
    {
        transform.DOMoveY(speedX/10, 1);
        yield return new WaitForSeconds(1);
        transform.DOMoveY(-speedX/10, 1);
=======
    { 
        mosquito.velocity = new Vector2(0,- 2);
        yield return new WaitForSeconds(1);
        mosquito.velocity = new Vector2(0, 2);
        StartCoroutine(IdleMove());
        
>>>>>>> Stashed changes
    }

    public void ChasePlayer(Vector2 Velocity)
    {
        mosquito.velocity = Velocity;
    }

    public void DistanceCalculations()
    {
        distance = new Vector2(player.transform.position.x - transform.position.x , player.transform.position.y - transform.position.y);
        var absoluteDistance = math.sqrt(distance.x * distance.x + distance.y * distance.y);
        coeficientY = distance.y / absoluteDistance;
        coeficientX = distance.x / absoluteDistance;
        speedY = totalSpeed*coeficientY;
        speedX = totalSpeed*coeficientX;       
    }
}
