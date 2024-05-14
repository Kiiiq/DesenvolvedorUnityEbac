using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRanges : MonoBehaviour
{
    public Transform boss;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = boss.position;
    }
}
