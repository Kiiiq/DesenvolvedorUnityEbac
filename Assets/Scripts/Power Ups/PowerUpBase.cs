using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : CollectableBase
{
    [SerializeField] public float powerUpDuration;
    
    protected override void OnCollect() { 
        base.OnCollect();
        StartPowerUp();
    }
    
    protected virtual void StartPowerUp()
    {
        Debug.Log("Power Up started");
        Invoke(nameof(EndPowerUp),powerUpDuration);
    }

    protected virtual void EndPowerUp()
    {
        Debug.Log("Power Up ended");
    }

}

