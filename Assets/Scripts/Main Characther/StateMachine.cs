using ReusableScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateMachine : MonoBehaviour
{
    [Header("References")]
    
    public Movement movement;
    public HealthManager healthManager;
    public GameObject sprite;
    public GameObject Hitbox, Spell, Slash;
    public Rigidbody2D playerRigidbody;
    public Actions actions;
    public BoxCollider2D boxCollider2D;
    public Animator animator;


    [Header ("Is Able To")]

    public bool ableToDash;
    public bool ableToJump;
    public bool ableToDoubleJump;
    public bool ableToSpell;
    public bool ableToShadowDash;

    [Header("Upgrades")]
    public bool spellUpgraded;
    public bool slashUpgraded;
    public bool doubleJump;
    public bool ShadowDash;

    [Header("Is doing")]   
    public bool isDead;
    public bool isAttacking;
    public bool isCasting;
    public bool isHealing;
    public bool isDashing;
    public bool facingRight;
    public bool onFloor;
    public bool jumping;
    public bool isTakingKnockback;
    public bool isImune;

    public bool gambiarra;

}
