using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Actions : MonoBehaviour
{
    public enum attacking { Right=0, Left=1, Up=2, Down=3 };

    public Vector3 attackLeft = new Vector3(0,0,180);
    public Vector3 attackUp = new Vector3(0,0,90);
    public Vector3 attackRight = new Vector3(0,0,0);
    public Vector3 attackDown = new Vector3(0,0,270);
    
    public Movement movement;

    public GameObject Hitbox, parent;

    public KeyCode attackKey = KeyCode.X, attackUpKey = KeyCode.UpArrow, attackDownKey = KeyCode.DownArrow;

    public bool isAttacking;

    public int damage, direction;

    public float attackSpeed;
    

    void Update()
    {
       if(Input.GetKeyDown(attackKey) && !movement.isDashing && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        if(Input.GetKey(attackUpKey))
        {           
            direction = (int)attacking.Up;
            isAttacking = true;
            Instantiate(Hitbox, this.transform.position + new Vector3(0, 1, 0), Quaternion.Euler(attackUp), this.transform);
            yield return new WaitForSeconds(attackSpeed);
            isAttacking = false;
        
        } else if(Input.GetKey(attackDownKey) && !movement.onFloor) 
        {
            direction = (int)attacking.Down;
            Debug.Log("Down");
            isAttacking = true;
            Instantiate(Hitbox, this.transform.position + new Vector3(0, -1, 0), Quaternion.Euler(attackDown), this.transform);
            yield return new WaitForSeconds(attackSpeed);
            
            isAttacking = false;
        }
        else if (movement.facingRight)
        {
            direction = (int)attacking.Right;
            isAttacking = true;
            Instantiate(Hitbox, this.transform.position+new Vector3(0.5f,0,0), Quaternion.Euler(attackRight), this.transform);
            yield return new WaitForSeconds(attackSpeed);
            isAttacking = false;
        } 
        else
        {
            direction = (int)attacking.Left;
            isAttacking = true;
            Instantiate(Hitbox, this.transform.position + new Vector3(-0.5f, 0, 0), Quaternion.Euler(attackLeft), this.transform);
            yield return new WaitForSeconds(attackSpeed);
            isAttacking = false;
        }
    }
}


