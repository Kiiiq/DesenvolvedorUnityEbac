using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public bool longRange, midRange, shortRange, isAttacking;
    public Rigidbody2D Boss;
    public Transform BossTransform;
    public int RNG;
    public float attackCooldown;


    private void Start()
    {
        Boss = GetComponent<Rigidbody2D>();
        BossTransform = GetComponent<Transform>();
    }

    public void Update()
    {
        if (!isAttacking)
        {
            RNG = Random.Range(1, 7);
            if (RNG <= 2 && longRange)
            {
                DecideLongAttack();
            }
            else if (RNG >= 5 && shortRange)
            {
                DecideShortAttack();
            }
            else if (midRange)
            {
                DecideMidAttack();
            }
        }
       
    }

    public void DecideLongAttack()
    {
        isAttacking = true;
        RNG = RNG = Random.Range(1, 3);
        if (RNG == 1)
        {
            StartCoroutine(LongRange1());
        } else
        {
            StartCoroutine(LongRange2());
        }
    }

    public void DecideMidAttack()
    {
        isAttacking = true;
        RNG = RNG = Random.Range(1, 3);
        if (RNG == 1)
        {
            StartCoroutine(MidRange1());
        }
        else
        {
            StartCoroutine(MidRange2());
        }
    }

    public void DecideShortAttack()
    {
        isAttacking = true;
        RNG = RNG = Random.Range(1, 3);
        if (RNG == 1)
        {
            StartCoroutine(ShortRange1());
        }
        else
        {
            StartCoroutine(ShortRange2());
        }
    }

    private IEnumerator LongRange1()
    {
        Debug.Log("Long Range 1");
        yield return null;
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator LongRange2()
    {
        Debug.Log("Long Range 2");
        yield return null;
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator MidRange1()
    {
        Debug.Log("Mid Range 1");
        yield return null;
        StartCoroutine(AttackCooldown());
    }
    private IEnumerator MidRange2()
    {
        Debug.Log("Mid Range 2");
        yield return null;
        StartCoroutine(AttackCooldown());
    }
    private IEnumerator ShortRange1()
    {
        Debug.Log("Short Range 1");
        yield return null;
        StartCoroutine(AttackCooldown());
    }
    private IEnumerator ShortRange2()
    {
        Debug.Log("Short Range 2");
        yield return null;
        StartCoroutine(AttackCooldown());
    }

    public IEnumerator AttackCooldown()
    {
        attackCooldown = 2 + (Random.Range(1, 11)/8f);
        yield return new WaitForSeconds(attackCooldown);
        isAttacking=false;
    }
}
