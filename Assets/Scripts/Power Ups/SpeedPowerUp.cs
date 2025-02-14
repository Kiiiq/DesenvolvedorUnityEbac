using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUpBase
{
    [Header("Power Up Speed Up")]
    public float amountToSpeedUp;
    

    protected override void StartPowerUp()
    {
        base.StartPowerUp();       
        characterMovement.fowardSpeed += amountToSpeedUp;
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        characterMovement.fowardSpeed -= amountToSpeedUp;
    }
}
