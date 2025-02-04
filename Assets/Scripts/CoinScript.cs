using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [Range(0f,60f)]public float speedRotation;
    public GameObject model;

    // Update is called once per frame
    void Update()
    {
        model.transform.Rotate(new Vector3(0,speedRotation*Time.deltaTime,0));
    }
}
