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
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        //Jump
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (Input.GetButtonDown("Jump")) jumpBufferCounter = jumpBuffer;
        else jumpBufferCounter -= Time.deltaTime;

        if (isGrounded && jumpBufferCounter >= 0) 
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            jumpBufferCounter = 0;
        }

        if (Input.GetButton("Jump") && jumpTimeCounter > 0 && isJumping)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
        }
        else isJumping = false;

        if (Input.GetButtonUp("Jump")) isJumping = false;


      
    }
}
