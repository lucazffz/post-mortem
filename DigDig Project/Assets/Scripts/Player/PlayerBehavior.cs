using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    #region Variables

    Rigidbody2D rigidBody;

    public Animator animator;
    public Animator heightAnimator;

    public SpriteRenderer spriteRenderer;

   

    public bool canMove = true;

    //X-axis movement
    float moveInput;

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
    bool isGrounded;
    public float checkRadius = 0.1f;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    bool facingRight;

    bool holding;

    #endregion

    void Start() 
    {
        rigidBody = GetComponent<Rigidbody2D>();
       
      
    }

    private void FixedUpdate() 
    {
        //x-axis movement
        if (canMove) moveInput = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(moveInput * speed, rigidBody.velocity.y);
    }

    private void Update() 
    {
        if (DialogueManager.inConversaion || PauseMenu.isPaused) canMove = false;
        else canMove = true;

        if (GrabController.holding) holding = true;
        else holding = false;

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
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetFloat("Jump", rigidBody.velocity.normalized.y);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, 1, Time.deltaTime * 20), transform.localScale.y);

            //transform.localScale = new Vector3(1, 1);

        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, -1, Time.deltaTime * 20), transform.localScale.y);

            //transform.localScale = new Vector3(-1, 1);
        }


        #endregion
    }
}
