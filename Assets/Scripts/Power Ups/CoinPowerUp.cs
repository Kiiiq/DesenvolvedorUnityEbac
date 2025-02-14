using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPowerUp : PowerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        characterMovement.CoinCollector.transform.localScale = new Vector3(20,20, 20);
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        characterMovement.CoinCollector.transform.localScale = new Vector3(1, 1, 1);
    }
}
