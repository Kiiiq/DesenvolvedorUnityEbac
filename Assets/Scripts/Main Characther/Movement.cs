using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReusableScripts;

public class Movement : MonoBehaviour
{

    [Header ("Movement")]
    public Rigidbody2D playerRigidbody;
<<<<<<< Updated upstream

    public Vector2 lastSafePlace;

=======
    public Actions actions;
    public HealthManager healthManager;
    public StateMachine stateMachine;
    public BoxCollider2D boxCollider2D;
    public GameObject spawnPoint;

    [Header ("\n\nMovement")]
    
    public Vector2 lastSafePlace;
    
>>>>>>> Stashed changes
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


<<<<<<< Updated upstream
    [Header("\n\nStates")]
    public bool isDead;
    public bool onFloor;
    public bool jumping;
    public bool facingRight;
    public bool ableToDash;
    public bool isDashing;
    public bool ableToJump;

    [Header("\n\nUpgrades")]
    public bool doubleJump=false;
    public bool ableToDoubleJump;
    public bool ShadowDash;


=======
>>>>>>> Stashed changes
    [Header("\n\nAnimation")]


    public float originalY;
    public float originalX;

    public float yDashStretch;
    public float xDashStretch;
    public float DashAnimationDuration;


    private void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
        this.transform.position = spawnPoint.transform.position;
    }

    void Update()
    {
<<<<<<< Updated upstream
        if (!isDead)
=======
        if (!stateMachine.isDead && !stateMachine.isHealing)
>>>>>>> Stashed changes
        {
            HorizontalMove();
            if (!stateMachine.doubleJump) {JumpFunction();} else { DoubleJumpFunction();}
            DashChecker();
            
        }
    }

    public void TpToSafePlace()
    {
        transform.position = lastSafePlace;
    }

    private void DashChecker()
    {
<<<<<<< Updated upstream
        if (Input.GetKeyDown(Dash) && ableToDash && !isDashing)
=======
        if (Input.GetKeyDown(Dash) && stateMachine.ableToDash && !stateMachine.isDashing && !stateMachine.isCasting && !stateMachine.isTakingKnockback)
>>>>>>> Stashed changes
        {
            if (stateMachine.ShadowDash)
            {
                StartCoroutine(ShadowDashing());
            }
            else { 
                StartCoroutine(Dashing()); 
            }
            
            StartCoroutine(DashingAnimation());
        }
    }

    private void HorizontalMove()
    {
<<<<<<< Updated upstream
        if (!isDashing)
=======
        if (!stateMachine.isDashing && !stateMachine.isCasting && !stateMachine.isTakingKnockback)
>>>>>>> Stashed changes
        {
            if (Input.GetKey(Left))
            {
                playerRigidbody.velocity = new Vector2(-Speed, playerRigidbody.velocity.y);
                stateMachine.facingRight = false;
            }
            else if (Input.GetKey(Right))
            {
                playerRigidbody.velocity = new Vector2(Speed, playerRigidbody.velocity.y);
                stateMachine.facingRight = true;
            }
        }
    }
    //Funcao pra pular sem o upgrade de double jump
    protected virtual void JumpFunction()
    {
<<<<<<< Updated upstream
        if (!isDashing)
=======
        if (!stateMachine.isDashing && !stateMachine.isCasting && !stateMachine.isTakingKnockback)
>>>>>>> Stashed changes
        {
            if (Input.GetKey(Jump) && stateMachine.onFloor == true && stateMachine.ableToJump)
            {
                stateMachine.ableToJump =true;
                stateMachine.jumping = true;
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, JumpDistance);
                playerRigidbody.gravityScale = 0;
            }
            else
            {
                stateMachine.jumping = false;
                playerRigidbody.gravityScale = Gravity;
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
<<<<<<< Updated upstream
        if (Input.GetKey(Jump) && onFloor == true && ableToJump)
        {
            ableToJump = true;
            jumping = true;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, JumpDistance);
            playerRigidbody.gravityScale = 0;
        } else if (!ableToJump && ableToDoubleJump && Input.GetKey(Jump))
        {
            StartCoroutine(StopDoubleJump());
            jumping = true;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, JumpDistance);
            playerRigidbody.gravityScale = 0;
        }
        else
        {
            jumping = false;
            playerRigidbody.gravityScale = Gravity;
        }

        if (Input.GetKeyUp(Jump) && ableToJump)
=======
        if(!stateMachine.isCasting && !stateMachine.isDashing && !stateMachine.isTakingKnockback)
        {
            if (Input.GetKey(Jump) && stateMachine.onFloor == true && stateMachine.ableToJump)
            {
                stateMachine.ableToJump = true;
                stateMachine.jumping = true;
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, JumpDistance);
                playerRigidbody.gravityScale = 0;
            } else if (!stateMachine.ableToJump && stateMachine.ableToDoubleJump && Input.GetKey(Jump))
            {
                StartCoroutine(StopDoubleJump());
                stateMachine.jumping = true;
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, JumpDistance);
                playerRigidbody.gravityScale = 0;
            }
            else
            {
                stateMachine.jumping = false;
                playerRigidbody.gravityScale = Gravity;
            }
        }
        
        if (Input.GetKeyUp(Jump) && stateMachine.ableToJump)
>>>>>>> Stashed changes
        {
            stateMachine.ableToJump = false;
        } else if (Input.GetKeyUp(Jump) && !stateMachine.ableToJump && stateMachine.ableToDoubleJump) {
            stateMachine.ableToDoubleJump = false;
        }

    }

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
        playerRigidbody.gravityScale = 0;
        playerRigidbody.velocity = new Vector2(Speed*direction * DashingMultipliyer, 0);
        yield return new WaitForSeconds(DashDuration);
        playerRigidbody.gravityScale = Gravity;
        playerRigidbody.velocity = new Vector2(Speed, 0);
        stateMachine.isDashing = false;
    }

    protected virtual IEnumerator ShadowDashing()
    {
        if (stateMachine.facingRight)
        {
            StartCoroutine (ReallyShadowDashing(1));
        }
        else
        {
            StartCoroutine(ReallyShadowDashing(-1));

        }
        yield return null;
    }

    IEnumerator ReallyShadowDashing(int direction)
    {
        boxCollider2D.isTrigger = true;
        stateMachine.isDashing = true;
        stateMachine.ableToDash = false;
        playerRigidbody.gravityScale = 0;
        playerRigidbody.velocity = new Vector2(Speed*direction * DashingMultipliyer, 0);
        yield return new WaitForSeconds(DashDuration);
        playerRigidbody.gravityScale = Gravity;
        playerRigidbody.velocity = new Vector2(Speed, 0);
        boxCollider2D.isTrigger = false;
        stateMachine.isDashing = false;
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


    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Spikes") || collision.gameObject.CompareTag("Floor"))
        {
            boxCollider2D.isTrigger = false; 
            stateMachine.isDashing = false;
        }
        if (collision.gameObject.CompareTag("SafePlace"))
        {
            lastSafePlace = playerRigidbody.position;
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
