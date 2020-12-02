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

        if (isGrounded && Input.GetButtonDown("Jump")) 
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimeCounter = jumpTime;
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
