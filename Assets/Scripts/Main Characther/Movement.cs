using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReusableScripts;
using Unity.Mathematics;

public class Movement : MonoBehaviour
{
    [Header ("References")]
    public Actions actions;
    public HealthManager healthManager;
    public StateMachine stateMachine;
    public GameObject spawnPoint;
    public GameObject ShadowIndicator;

    [Header ("\n\nMovement")]
    
    public Vector2 lastSafePlace;
    
    public KeyCode Left = KeyCode.LeftArrow, Right = KeyCode.RightArrow, Jump = KeyCode.Z, Dash = KeyCode.LeftShift;

    [Header("\n\nSpeed")]
    
    public float Speed = 5;
    
    [Header("\n\nJump")]
    
    public float JumpDistance = 10;
    public float jumpTime = 5;
    public float Gravity = 10;
    public float SpareJumpTime;

    [Header("\n\nDash")]
    
    public float DashingMultipliyer;
    public float DashDuration;
    public float ShadowDashCD;


    [Header("\n\nAnimation")]


    public float originalY;
    public float originalX;

    public float yDashStretch;
    public float xDashStretch;
    public float DashAnimationDuration;

    public float yJumpingStretch;
    public float xJumpingStretch;

    public float xLandingStretch;
    public float yLandingStretch;


    private void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
        this.transform.position = spawnPoint.transform.position;
    }

    void Update()
    {
        if (!stateMachine.isDead && !stateMachine.isHealing)
        {
            HorizontalMove();
            if (!stateMachine.doubleJump) {JumpFunction();} else { DoubleJumpFunction();}
            DashChecker();
            
        }

    }

    //Tp pra uma posicao segura, quando ele cai em algum lugar que da dano
    public void TpToSafePlace()
    {
        transform.position = lastSafePlace;
    }

    //Checa se o personagem tem shadow dash ou nao
    private void DashChecker()
    {
        if (Input.GetKeyDown(Dash) && stateMachine.ableToDash && !stateMachine.isDashing && !stateMachine.isCasting && !stateMachine.isTakingKnockback)
        {
            if (stateMachine.ShadowDash && stateMachine.ableToShadowDash)
            {
                StartCoroutine(ShadowDashing());
                StartCoroutine(ShadowDashingAnimation());
            }
            else { 
                StartCoroutine(Dashing());
                StartCoroutine(DashingAnimation());
            }
            
            
        }
    }
   
    
    //--------------------------------------------------------------------------------- // WALK ZONE // -----------------------------------------------------------------------------
    private void HorizontalMove()
    {
        if (!stateMachine.isDashing && !stateMachine.isCasting && !stateMachine.isTakingKnockback)
        {
            if (Input.GetKey(Left))
            {
                stateMachine.playerRigidbody.velocity = new Vector2(-Speed, stateMachine.playerRigidbody.velocity.y);
                stateMachine.facingRight = false;
            }
            else if (Input.GetKey(Right))
            {
                stateMachine.playerRigidbody.velocity = new Vector2(Speed, stateMachine.playerRigidbody.velocity.y);
                stateMachine.facingRight = true;
            }
        }
    }

    
    
    ////------------------------------------------------------------------------------------ // JUMP ZONE // -----------------------------------------------------------------------------
    //Funcao pra pular sem o upgrade de double jump
    protected virtual void JumpFunction()   
    {
        if (!stateMachine.isDashing && !stateMachine.isCasting && !stateMachine.isTakingKnockback)
        {
            if (Input.GetKey(Jump) && stateMachine.onFloor == true && stateMachine.ableToJump)
            {
                stateMachine.ableToJump =true;
                stateMachine.jumping = true;
                stateMachine.playerRigidbody.velocity = new Vector2(stateMachine.playerRigidbody.velocity.x, JumpDistance);
                stateMachine.playerRigidbody.gravityScale = 0;
            }
            else
            {
                stateMachine.jumping = false;
                stateMachine.playerRigidbody.gravityScale = Gravity;
            }

            if (Input.GetKeyUp(Jump))
            {
                stateMachine.ableToJump = false;
            }
        }
    }
    
    
    //Funcao pra pular com o upgrade de double jump
    protected virtual void DoubleJumpFunction() 
    {
        if(!stateMachine.isCasting && !stateMachine.isDashing && !stateMachine.isTakingKnockback)
        {
            if (Input.GetKey(Jump) && stateMachine.onFloor == true && stateMachine.ableToJump)
            {
                stateMachine.ableToJump = true;
                stateMachine.jumping = true;
                stateMachine.playerRigidbody.velocity = new Vector2(stateMachine.playerRigidbody.velocity.x, JumpDistance);
                stateMachine.playerRigidbody.gravityScale = 0;
            } else if (!stateMachine.ableToJump && stateMachine.ableToDoubleJump && Input.GetKey(Jump))
            {
                StartCoroutine(StopDoubleJump());
                stateMachine.jumping = true;
                stateMachine.playerRigidbody.velocity = new Vector2(stateMachine.playerRigidbody.velocity.x, JumpDistance);
                stateMachine.playerRigidbody.gravityScale = 0;
            }
            else
            {
                stateMachine.jumping = false;
                stateMachine.playerRigidbody.gravityScale = Gravity;
            }
        }
        
        if (Input.GetKeyUp(Jump) && stateMachine.ableToJump)
        {
            stateMachine.ableToJump = false;
        } else if (Input.GetKeyUp(Jump) && !stateMachine.ableToJump && stateMachine.ableToDoubleJump) {
            stateMachine.ableToDoubleJump = false;
        }

    }
    
    
    
    
    //------------------------------------------------------------------------------------- // DASH ZONE // -----------------------------------------------------------------------------
    //Verifica a direcao que o personagem ta olhando, Mostra que ele esta dashando, e desabilita a habilidade de Dashar dnv
    protected virtual IEnumerator Dashing()
    {
        if (stateMachine.facingRight){

            StartCoroutine(ReallyDashing(1));

        } else {

            StartCoroutine(ReallyDashing(-1));

        }
        yield return null;
    }

    IEnumerator ReallyDashing(int direction)
    {
        stateMachine.isDashing = true;
        stateMachine.ableToDash = false;
        stateMachine.playerRigidbody.gravityScale = 0;
        stateMachine.playerRigidbody.velocity = new Vector2(Speed*direction * DashingMultipliyer, 0);
        yield return new WaitForSeconds(DashDuration);
        stateMachine.playerRigidbody.gravityScale = Gravity;
        stateMachine.playerRigidbody.velocity = new Vector2(Speed, 0);
        stateMachine.isDashing = false;
    }


    //--------------------------------------------------------------------------------- // SHADOW DASH ZONE // -----------------------------------------------------------------------------
    protected virtual IEnumerator ShadowDashing()
    {
        if (stateMachine.facingRight)
        {
            StartCoroutine (ReallyShadowDashing(1));
            StartCoroutine(ShadowCooldown());
        }
        else
        {
            StartCoroutine(ReallyShadowDashing(-1));
            StartCoroutine(ShadowCooldown());
        }
        yield return null;
    }

    IEnumerator ReallyShadowDashing(int direction)
    {
        stateMachine.boxCollider2D.isTrigger = true;
        stateMachine.isDashing = true;
        stateMachine.ableToDash = false;
        stateMachine.playerRigidbody.gravityScale = 0;
        stateMachine.playerRigidbody.velocity = new Vector2(Speed*direction * DashingMultipliyer, 0);
        yield return new WaitForSeconds(DashDuration);
        stateMachine.playerRigidbody.gravityScale = Gravity;
        stateMachine.playerRigidbody.velocity = new Vector2(Speed, 0);
        stateMachine.boxCollider2D.isTrigger = false;
        stateMachine.isDashing = false;

    }

    IEnumerator ShadowCooldown()
    {
        ShadowIndicator.SetActive(false);
        stateMachine.ableToShadowDash = false;
        yield return new WaitForSeconds(ShadowDashCD);
        stateMachine.ableToShadowDash = true;
        ShadowIndicator.SetActive(true);
    }

    //--------------------------------------------------------------------------------- // ANIMATION ZONE // -----------------------------------------------------------------------------
    //Animacao pra o dash
    IEnumerator DashingAnimation() 
    {
        stateMachine.playerRigidbody.transform.DOScaleX(originalX*xDashStretch, DashAnimationDuration);
        stateMachine.playerRigidbody.transform.DOScaleY(originalY*yDashStretch, DashAnimationDuration);
        yield return new WaitForSeconds(DashAnimationDuration);
        stateMachine.playerRigidbody.transform.DOScaleX(originalX, DashDuration - DashAnimationDuration);
        stateMachine.playerRigidbody.transform.DOScaleY(originalY, DashDuration - DashAnimationDuration);
    }

    IEnumerator ShadowDashingAnimation()
    {
        stateMachine.sprite.DOColor(Color.black, 0);
        stateMachine.playerRigidbody.transform.DOScaleX(originalX * xDashStretch, DashAnimationDuration);
        stateMachine.playerRigidbody.transform.DOScaleY(originalY * yDashStretch, DashAnimationDuration);
        yield return new WaitForSeconds(DashAnimationDuration);
        stateMachine.playerRigidbody.transform.DOScaleX(originalX, DashDuration - DashAnimationDuration);
        stateMachine.playerRigidbody.transform.DOScaleY(originalY, DashDuration - DashAnimationDuration);
        stateMachine.sprite.DOColor(stateMachine.originalColor, DashDuration - DashAnimationDuration);
    }

    //--------------------------------------------------------------------------------- // COLLISIONS ZONE // -----------------------------------------------------------------------------
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Spikes") || collision.gameObject.CompareTag("Floor"))
        {
            stateMachine.boxCollider2D.isTrigger = false; 
            stateMachine.isDashing = false;
        }
        if (collision.gameObject.CompareTag("SafePlace"))
        {
            lastSafePlace = stateMachine.playerRigidbody.position;
        }
    }
    //Verifica se ele ta em colisao

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthManager.Takedamage(1, collision.transform.position.x);
        }
    }

    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {            
            stateMachine.onFloor = true;
            stateMachine.ableToDash = true;
            stateMachine.ableToJump = true;
            stateMachine.ableToDoubleJump = true;            
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

    //--------------------------------------------------------------------------------- // STOP JUMP ZONE // -----------------------------------------------------------------------------
    IEnumerator FloorExit()
    {
        yield return new WaitForSeconds(jumpTime);
        stateMachine.onFloor =false;
    }

    //Da um tempo pra o player pular mesmo que ja tenha saido do chao
    IEnumerator SpareTimetojump()
    {
        if (!stateMachine.jumping)
        {
            yield return new WaitForSeconds(SpareJumpTime);
            stateMachine.ableToJump = false;
        }
        yield return null;
    }

    IEnumerator StopDoubleJump()
    {
        yield return new WaitForSeconds(jumpTime/1.3f);
        stateMachine.ableToDoubleJump = false;
    }

    
}
