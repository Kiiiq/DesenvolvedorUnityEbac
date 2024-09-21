using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Actions : MonoBehaviour
{
    [HideInInspector] public enum attacking { Right = 0, Left = 1, Up = 2, Down = 3 };

    [HideInInspector] public Vector3 attackLeft = new Vector3(0, 180, 0);
    [HideInInspector] public Vector3 attackUp = new Vector3(0, 0, 90);
    [HideInInspector] public Vector3 attackRight = new Vector3(0, 0, 0);
    [HideInInspector] public Vector3 attackDown = new Vector3(180, 0, 90);
    
    [Header("References")]
    public Movement movement;
    public StateMachine stateMachine;
    public HealthManager healthManager;

    [Header("\n\nInput Keys")]
    public KeyCode attackKey = KeyCode.X;
    public KeyCode attackUpKey = KeyCode.UpArrow, attackDownKey = KeyCode.DownArrow, spellKey = KeyCode.A, slashKey = KeyCode.C, healKey=KeyCode.LeftControl;

    [Header("\n\nParameters")]
    public int damage;
    public int direction, maxStamina, stamina, staminaToCast;

    public float attackSpeed, timeToCast, timeToHeal;

    [Header("\n\nAnimation")]
    public float healAnimation;
    public float healScaleX, healScaleY;

    void Update()
    {

        if(!stateMachine.isDashing && !stateMachine.isAttacking && !stateMachine.isCasting && !stateMachine.isHealing && !stateMachine.isDead) 
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
                StopAllCoroutines();
                StartCoroutine(HealAnimation());
                StartCoroutine(Heal());
                stateMachine.isHealing = true;
                
            }
            
        }
    }

    IEnumerator Attack()
    {
        if (Input.GetKey(attackUpKey))
        {
            direction = (int)attacking.Up;
            stateMachine.isAttacking = true;
            Instantiate(stateMachine.Hitbox, this.transform.position + new Vector3(0, 1, 0), Quaternion.Euler(attackUp), this.transform);
            yield return new WaitForSeconds(attackSpeed);
            stateMachine.isAttacking = false;

        }
        else if (Input.GetKey(attackDownKey) && !stateMachine.onFloor)
        {
            direction = (int)attacking.Down;
            Debug.Log("Down");
            stateMachine.isAttacking = true;
            Instantiate(stateMachine.Hitbox, this.transform.position + new Vector3(0, -1, 0), Quaternion.Euler(attackDown), this.transform);
            yield return new WaitForSeconds(attackSpeed);

            stateMachine.isAttacking = false;
        }
        else if (stateMachine.facingRight)
        {
            direction = (int)attacking.Right;
            stateMachine.isAttacking = true;
            Instantiate(stateMachine.Hitbox, this.transform.position + new Vector3(0.5f, 0, 0), Quaternion.Euler(attackRight), this.transform);
            yield return new WaitForSeconds(attackSpeed);
            stateMachine.isAttacking = false;
        }
        else
        {
            direction = (int)attacking.Left;
            stateMachine.isAttacking = true;
            Instantiate(stateMachine.Hitbox, this.transform.position + new Vector3(-0.5f, 0, 0), Quaternion.Euler(attackLeft), this.transform);
            yield return new WaitForSeconds(attackSpeed);
            stateMachine.isAttacking = false;
        }
    }

    IEnumerator CastSpell()
    {
        if (stateMachine.facingRight)
        {
            stamina -= staminaToCast;
            Debug.Log("Casting");
            stateMachine.isCasting = true;
            stateMachine.playerRigidbody.velocity = new Vector2(0, 0);
            stateMachine.playerRigidbody.gravityScale = 0;
            yield return new WaitForSeconds(timeToCast);
            Instantiate(stateMachine.Spell, this.transform.position, Quaternion.Euler(0, 0, 0), this.transform);
            stateMachine.playerRigidbody.gravityScale = movement.Gravity;
            stateMachine.isCasting = false;
        }
        else
        {
            stamina -= staminaToCast;
            Debug.Log("Casting");
            stateMachine.isCasting = true;
            stateMachine.playerRigidbody.velocity = new Vector2(0, 0);
            stateMachine.playerRigidbody.gravityScale = 0;
            yield return new WaitForSeconds(timeToCast);
            Instantiate(stateMachine.Spell, this.transform.position, Quaternion.Euler(0, 180, 0), this.transform);
            stateMachine.playerRigidbody.gravityScale = movement.Gravity;
            stateMachine.isCasting = false;
        }
    }

    IEnumerator CastSlash()
    {
        if (stateMachine.facingRight)
        {
            stamina -= staminaToCast;
            Debug.Log("Slashing");
            stateMachine.isCasting = true;
            stateMachine.playerRigidbody.velocity = new Vector2(0, 0);
            stateMachine.playerRigidbody.gravityScale = 0;
            yield return new WaitForSeconds(timeToCast);
            Instantiate(stateMachine.Slash, this.transform.position, Quaternion.Euler(0, 0, 0), this.transform);
            stateMachine.playerRigidbody.gravityScale = movement.Gravity;
            stateMachine.isCasting = false;
        }
        else
        {
            stamina -= staminaToCast;
            Debug.Log("Slashing");
            stateMachine.isCasting = true;
            stateMachine.playerRigidbody.velocity = new Vector2(0, 0);
            stateMachine.playerRigidbody.gravityScale = 0;
            yield return new WaitForSeconds(timeToCast*2f);
            Instantiate(stateMachine.Slash, this.transform.position, Quaternion.Euler(0, 180, 0), this.transform);
            stateMachine.playerRigidbody.gravityScale = movement.Gravity;
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
        stamina-= staminaToCast;
        StopAllCoroutines();
    }

    IEnumerator HealAnimation()
    {
        stateMachine.playerRigidbody.transform.DOScaleY((movement.originalY*healScaleY), healAnimation);
        stateMachine.playerRigidbody.transform.DOScaleX((movement.originalX * healScaleX), healAnimation);
<<<<<<< Updated upstream
        stateMachine.sprite.DOColor(Color.white, healAnimation);
        yield return new WaitForSeconds(healAnimation);
        stateMachine.playerRigidbody.transform.DOScaleY(movement.originalY, healAnimation-timeToHeal);
        stateMachine.playerRigidbody.transform.DOScaleX(movement.originalX, healAnimation - timeToHeal);
        stateMachine.sprite.DOColor(stateMachine.originalColor, timeToHeal - healAnimation);

=======
        yield return new WaitForSeconds(healAnimation);
        stateMachine.playerRigidbody.transform.DOScaleY(movement.originalY, healAnimation-timeToHeal);
        stateMachine.playerRigidbody.transform.DOScaleX(movement.originalX, healAnimation - timeToHeal);
>>>>>>> Stashed changes
    }
}