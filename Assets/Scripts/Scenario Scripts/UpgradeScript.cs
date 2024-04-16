using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpgradeScript : CollectableScript
{

    public enum Upgrade { Slash, Spell, DoubleJump, ShadowDash }

    public Upgrade upgrade;
    public StateMachine stateMachine;
    public GameObject Player;
    public Transform thisTransform;

    [SerializeField] float floatSpeedY, floatSpeedX;

    private float dir=1;

    public override void CollectableAction()
    {
        Player = GameObject.Find("Player Characther");
        stateMachine = Player.GetComponent<StateMachine>();
        switch (upgrade)
        {
            case (Upgrade)0: stateMachine.slashUpgraded = true; break;
            case (Upgrade)1: stateMachine.spellUpgraded = true; break;
            case (Upgrade)2: stateMachine.doubleJump = true; break;
            case (Upgrade)3: stateMachine.ShadowDash = true; stateMachine.ableToShadowDash=true; break;

        }
    }

    public void Awake()
    {
        thisTransform = this.transform;
        StartCoroutine(FloatingY());
        StartCoroutine(FloatingX());
    }

    IEnumerator FloatingY()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            this.gameObject.transform.DOMoveY(thisTransform.position.y-(floatSpeedY*dir),0.5f);
            if (dir == 1) { dir = -1; } else {  dir = 1; }
        }
    }

    IEnumerator FloatingX()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            this.gameObject.transform.DOMoveX(thisTransform.position.x - (floatSpeedX * dir), 0.2f);
            if (dir == 1) { dir = -1; } else { dir = 1; }
        }
    }
}
