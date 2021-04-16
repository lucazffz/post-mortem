using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    #region Variables

    Rigidbody2D rigidBody;

    [Header("Animation")]
    public Animator animator;
    public Animator heightAnimator;
    public Animator lanternPosAnimatior;

    bool facingRight;

    [Header("Movement")]

    public float gravity = 7;
    bool canMove = true;
    bool holding;

    //X-axis movement
    public float moveInput;
    public float speed = 4f;
   
    //Jump
    public float jumpForce = 15f;

    bool isJumping;
    public float jumpTime = 0.2f;
    float jumpTimeCounter;

    public float jumpBuffer = 0.1f;
    float jumpBufferCounter;

    public float hangTime = 0.2f;
    float hangTimeCounter;
    
    //ground check
    public static bool isGrounded;
    public float checkRadius = 0.1f;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    [Header("Ladder")]
    public float climbSpeed;
    public float climbCheckDistance = 2;
    public LayerMask whatIsLadder;
   
    private float inputVertical;
    private Vector2 climbPos;
    private GameObject platform;
    
    public static bool isClimbing;
    static RaycastHit2D climbCheck;

    #endregion
  

    void Start() 
    {
        rigidBody = GetComponent<Rigidbody2D>();
        canMove = true;

        isClimbing = false;
    }

    private void FixedUpdate() 
    {
        //x-axis movement
        if (canMove) moveInput = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(moveInput * speed, rigidBody.velocity.y);

        #region Climbing

        climbCheck = Physics2D.Raycast(transform.position, Vector2.up, climbCheckDistance, whatIsLadder);

        if(isClimbing == true)
        {
            rigidBody.gravityScale = 0;

            inputVertical = Input.GetAxisRaw("Vertical");
            rigidBody.velocity = new Vector2(0, inputVertical * climbSpeed);

            climbPos = new Vector2(climbCheck.collider.transform.position.x, transform.position.y);
            transform.position = Vector3.MoveTowards(transform.position, climbPos, 5 * Time.deltaTime);

            platform = climbCheck.collider.transform.GetChild(0).gameObject;

            if (rigidBody.velocity.y > 0 && groundCheck.position.y > platform.transform.position.y)
            {
                platform.transform.GetComponent<BoxCollider2D>().enabled = true;
                isClimbing = false;
            }
            else if (rigidBody.velocity.y < 0 && isGrounded)
            {
                isClimbing = false;


                platform.transform.GetComponent<BoxCollider2D>().enabled = true;
            }
            else platform.transform.GetComponent<BoxCollider2D>().enabled = false;
        }
        else rigidBody.gravityScale = gravity;

        #endregion
    }

    private void Update() 
    {
        if (DialogueManager.inConversaion || PauseMenu.pauseMenuActivated || isClimbing || EndScenecut.playingCutscene) canMove = false;
        else canMove = true;

        if (GrabController.grabbing) holding = true;
        else holding = false;

        if (LanternController.holdingLantern) GetComponent<BoxCollider2D>().enabled = true;
        else GetComponent<BoxCollider2D>().enabled = false;

        if (!canMove && isGrounded) moveInput = 0;

        #region Jump

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded) hangTimeCounter = hangTime;
        else hangTimeCounter -= Time.deltaTime;

        if (Input.GetButtonDown("Jump") && canMove && !holding) jumpBufferCounter = jumpBuffer;
        else jumpBufferCounter -= Time.deltaTime;

        //normal jump
        if (hangTimeCounter > 0 && jumpBufferCounter > 0)
        {
            rigidBody.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
            jumpBufferCounter = 0;
            isJumping = true;

            FindObjectOfType<AudioManager>().PlaySound("Jump");
        }

        //different jump height
        if (Input.GetButton("Jump") && jumpTimeCounter > 0 && isJumping) 
        {
            rigidBody.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
            hangTimeCounter = 0;
        } 
        else isJumping = false;

        if (Input.GetButtonUp("Jump")) isJumping = false;

        #endregion

        #region Animations

        heightAnimator.SetBool("isGrounded", isGrounded);
        heightAnimator.SetFloat("Speed", Mathf.Abs(moveInput));
        heightAnimator.SetFloat("Jump", rigidBody.velocity.normalized.y);

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("Jump", rigidBody.velocity.normalized.y);
        animator.SetBool("Holding", LanternController.holdingLantern);

        lanternPosAnimatior.SetFloat("Speed", Mathf.Abs(moveInput));
        lanternPosAnimatior.SetBool("Holding", LanternController.holdingLantern);

        animator.SetBool("Climbing", isClimbing);
        if (isClimbing) animator.speed = Mathf.Abs(rigidBody.velocity.normalized.y);
        else animator.speed = 1;

        

        animator.SetBool("Grabbing", GrabController.grabbing);
        animator.SetFloat("Speed", moveInput * transform.localScale.x);

        if(moveInput == 0 && isGrounded) animator.SetBool("Idle", true);
        else animator.SetBool("Idle", false);


        if (!GrabController.grabbing && !isClimbing)
        {
            if (!facingRight && moveInput > 0) Flip();
            else if (facingRight && moveInput < 0) Flip();
        }
       

        void Flip()
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
        }
       
        #endregion
    }
    public void Climb()
    {
        Debug.Log(climbCheck.collider);
        if(climbCheck.collider != null)
        {
            isClimbing = true;
            Debug.Log("climb");
        }
    }
}

