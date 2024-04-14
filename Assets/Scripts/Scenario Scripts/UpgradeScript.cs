using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : CollectableScript
{

    public enum Upgrade { Slash, Spell, DoubleJump, ShadowDash }

    public Upgrade upgrade;
    public StateMachine stateMachine;
    public GameObject Player;

    public override void CollectableAction()
    {
        Player = GameObject.Find("Player Characther");
        stateMachine = Player.GetComponent<StateMachine>();
        switch (upgrade)
        {
            case (Upgrade)0: stateMachine.slashUpgraded = true; break;
            case (Upgrade)1: stateMachine.spellUpgraded = true; break;
            case (Upgrade)2: stateMachine.doubleJump = true; break;
            case (Upgrade)3: stateMachine.ShadowDash = true; break;

        }
    }

}
