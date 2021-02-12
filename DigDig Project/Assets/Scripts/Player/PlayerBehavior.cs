using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    #region Variables

    Rigidbody2D rb;
    public Animator animator;

    public GrabController grabController;

    [HideInInspector] public bool canMove = true;

    //X-axis movement
    float moveInput;

    public float speed = 4f;
    private float currentSpeed;
    public float holdingSpeed = 2f;
    

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
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
    }

    private void FixedUpdate() 
    {
        //x-axis movement
        if (canMove) moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);
    }

    private void Update() 
    {
        if (FindObjectOfType<DialogueManager>().inConversaion) canMove = false;
        else canMove = true;

        if (FindObjectOfType<GrabController>().holding) holding = true;
        else holding = false;

        if (holding) currentSpeed = holdingSpeed;
        else currentSpeed = speed;

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
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
            jumpBufferCounter = 0;
            isJumping = true;
        }

        //different jump height
        if (Input.GetButton("Jump") && jumpTimeCounter > 0 && isJumping) 
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
            hangTimeCounter = 0;
        } 
        else isJumping = false;

        if (Input.GetButtonUp("Jump")) isJumping = false;



        #endregion

        #region Animations
       animator.SetBool("isGrounded", isGrounded);
      

        if (!isGrounded && gameObject.GetComponent<Rigidbody2D>().velocity.y > 0) animator.SetFloat("Jump", 1);
        else if (!isGrounded && gameObject.GetComponent<Rigidbody2D>().velocity.y < 0) animator.SetFloat("Jump", -1);
        else animator.SetFloat("Jump", 0);

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if(!holding)
        {
            if (facingRight == false && moveInput < 0) Flip();
            else if (facingRight == true && moveInput > 0) Flip();
        }
        

        void Flip()
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);
        }

        #endregion
    }
}
