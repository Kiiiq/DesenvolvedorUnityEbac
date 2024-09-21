using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<healthManager.maxLife; i++)
        {
            Instantiate(gameObject, this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
