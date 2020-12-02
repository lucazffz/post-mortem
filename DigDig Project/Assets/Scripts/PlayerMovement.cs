using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    Rigidbody2D rb;

    //x-axis movement
    private float moveInput;
    public float speed = 6f;

    //Jump
    public float jumpForce = 15f;

    private bool isJumping;
    public float jumpTime = 0.2f;
    private float jumpTimeCounter;

    public float jumpBuffer = 0.1f;
    private float jumpBufferCounter;

    public float hangTime = 0.2f;
    private float hangTimeCounter;
    
    //ground check
    private bool isGrounded;
    public float checkRadius = 0.1f;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //x-axis movement
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        #region Jump

        //ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //hang time
        if (isGrounded) hangTimeCounter = hangTime;
        else hangTimeCounter -= Time.deltaTime;

        //jump buffer
        if (Input.GetButtonDown("Jump")) jumpBufferCounter = jumpBuffer;
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


    }
}
