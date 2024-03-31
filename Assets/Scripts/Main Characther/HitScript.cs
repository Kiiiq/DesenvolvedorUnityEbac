using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public float attackDuration;
    public Actions actions;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeToDestroy());
        GetComponentInParent<Actions>();
    }

    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(attackDuration);
        Destroy(this.gameObject);
    }
}

    