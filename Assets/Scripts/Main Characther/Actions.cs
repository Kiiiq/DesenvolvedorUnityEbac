using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Actions : MonoBehaviour
{
    public enum attacking { Right = 0, Left = 1, Up = 2, Down = 3 };

    public Vector3 attackLeft = new Vector3(0, 180, 0);
    public Vector3 attackUp = new Vector3(0, 0, 90);
    public Vector3 attackRight = new Vector3(0, 0, 0);
    public Vector3 attackDown = new Vector3(180, 0, 90);

<<<<<<< Updated upstream
    public Vector3 attackLeft = new Vector3(0,0,180);
    public Vector3 attackUp = new Vector3(0,0,90);
    public Vector3 attackRight = new Vector3(0,0,0);
    public Vector3 attackDown = new Vector3(0,0,270);
    
=======
>>>>>>> Stashed changes
    public Movement movement;
    public StateMachine stateMachine;
    public HealthManager healthManager;

<<<<<<< Updated upstream
    public GameObject Hitbox, parent;

    public KeyCode attackKey = KeyCode.X, attackUpKey = KeyCode.UpArrow, attackDownKey = KeyCode.DownArrow;

    public bool isAttacking;
=======
    public GameObject Hitbox, Spell, Slash;

    public KeyCode attackKey = KeyCode.X, attackUpKey = KeyCode.UpArrow, attackDownKey = KeyCode.DownArrow, spellKey = KeyCode.A, slashKey = KeyCode.C, healKey=KeyCode.LeftControl;
>>>>>>> Stashed changes

    public int damage, direction;

<<<<<<< Updated upstream
    public float attackSpeed;
    

    void Update()
    {
       if(Input.GetKeyDown(attackKey) && !movement.isDashing && !isAttacking)
        {
            StartCoroutine(Attack());
=======
    public float attackSpeed, timeToCast, timeToHeal;



    void Update()
    {
        if(!stateMachine.isDashing && !stateMachine.isAttacking && !stateMachine.isCasting && !stateMachine.isHealing) 
        { 
            if (Input.GetKeyDown(attackKey))
            {
                StartCoroutine(Attack());
            }
            else if (Input.GetKeyDown(spellKey) && stamina >= staminaToCast && stateMachine.spellUpgraded)
            {
                StartCoroutine(CastSpell());
            }
            else if (Input.GetKeyDown(slashKey) && stamina >= staminaToCast && stateMachine.slashUpgraded)
            {
                StartCoroutine(CastSlash());
            }
            if (Input.GetKeyDown(healKey) && stamina >= staminaToCast && healthManager.currentLife < healthManager.maxLife)
            {
                StartCoroutine(Heal());
                stateMachine.isHealing = true;
                
            }
            
        }

        if (Input.GetKeyUp(healKey))
        {
            StopAllCoroutines();
            stateMachine.isHealing = false;
>>>>>>> Stashed changes
        }
    }

    IEnumerator Attack()
    {
        if (Input.GetKey(attackUpKey))
        {
            direction = (int)attacking.Up;
            stateMachine.isAttacking = true;
            Instantiate(Hitbox, this.transform.position + new Vector3(0, 1, 0), Quaternion.Euler(attackUp), this.transform);
            yield return new WaitForSeconds(attackSpeed);
            stateMachine.isAttacking = false;

        }
        else if (Input.GetKey(attackDownKey) && !stateMachine.onFloor)
        {
            direction = (int)attacking.Down;
            Debug.Log("Down");
            stateMachine.isAttacking = true;
            Instantiate(Hitbox, this.transform.position + new Vector3(0, -1, 0), Quaternion.Euler(attackDown), this.transform);
            yield return new WaitForSeconds(attackSpeed);

            stateMachine.isAttacking = false;
        }
        else if (stateMachine.facingRight)
        {
            direction = (int)attacking.Right;
            stateMachine.isAttacking = true;
            Instantiate(Hitbox, this.transform.position + new Vector3(0.5f, 0, 0), Quaternion.Euler(attackRight), this.transform);
            yield return new WaitForSeconds(attackSpeed);
            stateMachine.isAttacking = false;
        }
        else
        {
            direction = (int)attacking.Left;
            stateMachine.isAttacking = true;
            Instantiate(Hitbox, this.transform.position + new Vector3(-0.5f, 0, 0), Quaternion.Euler(attackLeft), this.transform);
            yield return new WaitForSeconds(attackSpeed);
            stateMachine.isAttacking = false;
        }
    }
<<<<<<< Updated upstream
}
=======

    IEnumerator CastSpell()
    {
        if (stateMachine.facingRight)
        {
            stamina -= staminaToCast;
            Debug.Log("Casting");
            stateMachine.isCasting = true;
            movement.playerRigidbody.velocity = new Vector2(0, 0);
            movement.playerRigidbody.gravityScale = 0;
            yield return new WaitForSeconds(timeToCast);
            Instantiate(Spell, this.transform.position, Quaternion.Euler(0, 0, 0), this.transform);
            movement.playerRigidbody.gravityScale = movement.Gravity;
            stateMachine.isCasting = false;
        }
        else
        {
            stamina -= staminaToCast;
            Debug.Log("Casting");
            stateMachine.isCasting = true;
            movement.playerRigidbody.velocity = new Vector2(0, 0);
            movement.playerRigidbody.gravityScale = 0;
            yield return new WaitForSeconds(timeToCast);
            Instantiate(Spell, this.transform.position, Quaternion.Euler(0, 180, 0), this.transform);
            movement.playerRigidbody.gravityScale = movement.Gravity;
            stateMachine.isCasting = false;
        }
    }
>>>>>>> Stashed changes

    IEnumerator CastSlash()
    {
        if (stateMachine.facingRight)
        {
            stamina -= staminaToCast;
            Debug.Log("Slashing");
            stateMachine.isCasting = true;
            movement.playerRigidbody.velocity = new Vector2(0, 0);
            movement.playerRigidbody.gravityScale = 0;
            yield return new WaitForSeconds(timeToCast);
            Instantiate(Slash, this.transform.position, Quaternion.Euler(0, 0, 0), this.transform);
            movement.playerRigidbody.gravityScale = movement.Gravity;
            stateMachine.isCasting = false;
        }
        else
        {
            stamina -= staminaToCast;
            Debug.Log("Slashing");
            stateMachine.isCasting = true;
            movement.playerRigidbody.velocity = new Vector2(0, 0);
            movement.playerRigidbody.gravityScale = 0;
            yield return new WaitForSeconds(timeToCast*2f);
            Instantiate(Slash, this.transform.position, Quaternion.Euler(0, 180, 0), this.transform);
            movement.playerRigidbody.gravityScale = movement.Gravity;
            stateMachine.isCasting = false;
        }
    }

    IEnumerator Heal()
    {
        Debug.Log("Healing");
        if (Input.GetKeyUp(healKey) || stateMachine.isDashing || stateMachine.isAttacking)
        {
            StopAllCoroutines();
        }
        yield return new WaitForSeconds(timeToHeal);
        healthManager.currentLife++;
        Debug.Log("Healing Completed");
        stateMachine.isHealing = false;
        StopAllCoroutines();
    }
}