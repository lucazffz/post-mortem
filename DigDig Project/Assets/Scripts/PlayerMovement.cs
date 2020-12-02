using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    private float moveInput;
    public float speed = 6f;

    private bool isGrounded;
    private bool isJumping;
    public float jumpForce = 10f;

    private float jumpTimeCounter;
    public float jumpTime;

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
        //jump
        if(Input.GetButton("Jump") && jumpTimeCounter > 0 && isJumping)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;

            isGrounded = false;
        }

        if (isGrounded)
        {
            jumpTimeCounter = jumpTime;
        }
    
            


        if (Input.GetButtonUp("Jump")) isJumping = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = true;
        }
    }
}
