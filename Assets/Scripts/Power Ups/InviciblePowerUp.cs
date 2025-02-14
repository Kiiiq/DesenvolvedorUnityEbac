using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviciblePowerUp : PowerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        characterMovement.Invincible = true;
        characterMovement.Collider.isTrigger = true;
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        characterMovement.Invincible = false;
        characterMovement.Collider.isTrigger = false;
    }
}
