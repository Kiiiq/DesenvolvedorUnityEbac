using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePointUI : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private GameObject gameObject;
    int actualLife;
    [SerializeField] List<GameObject>LifePoints = new List<GameObject>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < healthManager.maxLife; i++)
        {
            var obj = Instantiate(gameObject, this.transform);
            LifePoints.Add(obj);
        }

        actualLife = healthManager.currentLife;

    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (actualLife > healthManager.currentLife)
        {
            Destroy(LifePoints[actualLife-1]);
            LifePoints.Remove(LifePoints[actualLife-1]);
            actualLife--;
        }

        if (actualLife < healthManager.currentLife) {
            var obj = Instantiate(gameObject, this.transform);
            LifePoints.Add(obj);
            actualLife++;
        }
    }
}
