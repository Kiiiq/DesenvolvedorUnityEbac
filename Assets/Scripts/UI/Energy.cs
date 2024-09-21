using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField]Actions actions;
    [SerializeField] GameObject energyPoint;
    [SerializeField]List<GameObject> EnergyPoints = new List<GameObject>();
    int energyCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (energyCount > actions.stamina)
        {
            Destroy(EnergyPoints[energyCount - 1]);
            EnergyPoints.Remove(EnergyPoints[energyCount - 1]);
            energyCount--;
        }

        if (energyCount < actions.stamina)
        {
            var obj = Instantiate(energyPoint, this.transform);
            EnergyPoints.Add(obj);
            energyCount++;
        }
    }
}
