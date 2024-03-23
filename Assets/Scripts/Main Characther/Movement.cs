using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [Header ("Movement")]
    public Rigidbody2D playerRigidbody;

    public Vector2 lastSafePlace;

    public KeyCode Left = KeyCode.LeftArrow, Right = KeyCode.RightArrow, Jump = KeyCode.Z, Dash = KeyCode.LeftShift;

    public float Speed = 5;
    public float JumpDistance = 10;
    public float jumpTime = 5;
    public float Gravity = 10;
    public float DashingMultipliyer;
    public float DashDuration;
    public float SpareJumpTime;


    public bool isDead;
    private bool onCollision;
    private bool jumping;
    private bool facingRight;
    private bool ableToDash;
    private bool isDashing;
    private bool ableToJump;

    [Header("Animation")]


    public float originalY;
    public float originalX;

    public float yDashStretch;
    public float xDashStretch;
    public float DashAnimationDuration;
    


    void Update()
    {
        if (!isDead)
        {
            HorizontalMove();
            VerticalMove();
            DashChecker();
        }
    }

    public void TpToSafePlace()
    {
        transform.position = lastSafePlace;
    }

    private void DashChecker()
    {
        if (Input.GetKeyDown(Dash) && ableToDash && !isDashing)
        {
            StartCoroutine(Dashing());
            StartCoroutine(DashingAnimation());
        }
    }

    private void HorizontalMove()
    {
        if (!isDashing)
        {
            if (Input.GetKey(Left))
            {
                playerRigidbody.velocity = new Vector2(-Speed, playerRigidbody.velocity.y);
                facingRight = false;
            }
            else if (Input.GetKey(Right))
            {
                playerRigidbody.velocity = new Vector2(Speed, playerRigidbody.velocity.y);
                facingRight = true;
            }
        }
    }

    private void VerticalMove()
    {
        if (!isDashing)
        {
            if (Input.GetKey(Jump) && onCollision == true && ableToJump)
            {
                ableToJump=true;
                jumping = true;
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, JumpDistance);
                playerRigidbody.gravityScale = 0;
            }
            else
            {
                jumping = false;
                playerRigidbody.gravityScale = Gravity;
            }

            if (Input.GetKeyUp(Jump))
            {
                ableToJump = false;
            }
        }
    }

    IEnumerator Dashing()
    {
        if (facingRight){
            
            isDashing = true;
            ableToDash = false;
            playerRigidbody.gravityScale = 0;
            playerRigidbody.velocity = new Vector2(Speed * DashingMultipliyer, 0);
            yield return new WaitForSeconds(DashDuration);
            playerRigidbody.gravityScale = Gravity;
            playerRigidbody.velocity= new Vector2(Speed, 0);
            isDashing = false;

        } else if (!facingRight){

            isDashing = true;
            ableToDash = false;
            playerRigidbody.gravityScale = 0;
            playerRigidbody.velocity = new Vector2(-Speed * DashingMultipliyer, 0);
            yield return new WaitForSeconds(DashDuration);
            playerRigidbody.gravityScale = Gravity;
            playerRigidbody.velocity = new Vector2(-Speed, 0);
            isDashing = false;

        }
        yield return null;
    }

    IEnumerator DashingAnimation() 
    {
        playerRigidbody.transform.DOScaleX(originalX*xDashStretch, DashAnimationDuration);
        playerRigidbody.transform.DOScaleY(originalY*yDashStretch, DashAnimationDuration);
        yield return new WaitForSeconds(DashAnimationDuration);
        playerRigidbody.transform.DOScaleX(originalX, DashDuration - DashAnimationDuration);
        playerRigidbody.transform.DOScaleY(originalY, DashDuration - DashAnimationDuration);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ceilling"))
        {


            onCollision = true;
            ableToDash = true;
            ableToJump = true;

            if (collision.gameObject.CompareTag("Floor"))
            {
                lastSafePlace = playerRigidbody.position;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(CollisionExit());
        StartCoroutine(SpareTimetojump());
    }

    IEnumerator CollisionExit()
    {
        yield return new WaitForSeconds(jumpTime);
        onCollision=false;
    }

    IEnumerator SpareTimetojump()
    {
        if (!jumping)
        {
            yield return new WaitForSeconds(SpareJumpTime);
            ableToJump = false;
        }
        yield return null;
    }

}
