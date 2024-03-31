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

    [Header("\n\nSpeed")]
    public float Speed = 5;
    
    [Header("\n\nJump")]
    public float JumpDistance = 10;
    public float jumpTime = 5;
    private float Gravity = 10;
    public float SpareJumpTime;

    [Header("\n\nDash")]
    public float DashingMultipliyer;
    public float DashDuration;


    [Header("\n\nStates")]
    public bool isDead;
    public bool onFloor;
    public bool jumping;
    public bool facingRight;
    public bool ableToDash;
    public bool isDashing;
    public bool ableToJump;

    [Header("\n\nAnimation")]


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
            JumpFunction();
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

    protected virtual void JumpFunction()
    {
        if (!isDashing)
        {
            if (Input.GetKey(Jump) && onFloor == true && ableToJump)
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

    //Verifica a direcao que o personagem ta olhando, Mostra que ele esta dashando, e desabilita a habilidade de Dashar dnv
    protected virtual IEnumerator Dashing()
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

    //Animacao pra o dash
    IEnumerator DashingAnimation() 
    {
        playerRigidbody.transform.DOScaleX(originalX*xDashStretch, DashAnimationDuration);
        playerRigidbody.transform.DOScaleY(originalY*yDashStretch, DashAnimationDuration);
        yield return new WaitForSeconds(DashAnimationDuration);
        playerRigidbody.transform.DOScaleX(originalX, DashDuration - DashAnimationDuration);
        playerRigidbody.transform.DOScaleY(originalY, DashDuration - DashAnimationDuration);
    }

    //Verifica se ele ta em colisao
    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ceilling"))
        {
            //Checa o tipo de colisao que ele ta tendo
            if (collision.gameObject.CompareTag("Floor"))
            {
                onFloor = true;
            }

            ableToDash = true;
            ableToJump = true;

            if (collision.gameObject.CompareTag("Floor"))
            {
                lastSafePlace = playerRigidbody.position;
            }
        }
    }

    //Invoca as co-rotinas de limite de pulo
    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            StartCoroutine(FloorExit());
            StartCoroutine(SpareTimetojump());
        }
    }
    //Os dois seguem a mesma logica, limita o tanto que o personagem vai pular
    IEnumerator FloorExit()
    {
        yield return new WaitForSeconds(jumpTime);
        onFloor=false;
    }



    //Da um tempo pra o player pular mesmo que ja tenha saido do chao
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
