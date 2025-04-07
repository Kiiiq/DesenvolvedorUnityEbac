using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject carPrefab;

    public float speed;

    public void spawnCarro()
    {
        Instantiate(carPrefab);
    }

}
