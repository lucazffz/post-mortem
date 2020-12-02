using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    //x-axis movement
    private float moveInput;
    public float speed = 6f;

   //jump
    public float jumpForce = 10f;
    private bool isJumping;

    private float jumpTimeCounter;
    public float jumpTime;

    private float jumpBufferCounter;
    public float jumpBuffer = 0.1f;

    private float hangTimeCounter;
    public float hangTime = 0.2f;

    private bool isGrounded;
    public float checkRadius;
    public Transform feetPos;
    public LayerMask whatIsGround;

    Rigidbody2D rb;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        jumpTimeCounter = jumpTime;
    }

    private void FixedUpdate()
    {
        //x-axis movement
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        //Jump
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

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
            isJumping = true;
            jumpTimeCounter = jumpTime;
            jumpBufferCounter = 0;
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


      
    }
}
