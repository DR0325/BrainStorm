using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // horizontal movement
    public float speed;
    private float moveInput;
    private Rigidbody2D rb;
    private bool faceRight = true;

    // rolling (essentially a dash)
    private float currMoveSpeed;
    public float rollSpeed;

    public float rollLength;
    public float rollCooldown;

    private float rollCounter;
    private float rollCooldCounter;

    //jumping variables
    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask isGround; //what is ground

    private float jumpTimeCount;
    public float jumpTime;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currMoveSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Horizontal movement
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * currMoveSpeed, rb.velocity.y);

        if(faceRight == false && moveInput > 0){
            FlipChar();  // make character face right if moving right
        } else if(faceRight == true && moveInput < 0){
            FlipChar();  // face left when moving left
        }
    }

    private void Update()
    {
        //determine if char is touching ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, isGround);

        // jump only if touching ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isJumping = true;
            jumpTimeCount = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        // jump cut -- Jump higher on lower based on how long key is pressed

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCount > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCount -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        // rolling
        //when pressing F and while off cooldown move at rolling speed

        //TODO add invis frames while rolling
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (rollCooldCounter <= 0 && rollCounter <= 0)
            {
                currMoveSpeed = rollSpeed;
                rollCounter = rollLength; 
            }
        }
        // stop "rolling" and go back to normal move speed once timer hits 0
        if(rollCounter > 0)
        {
            rollCounter -= Time.deltaTime;

            if(rollCounter <= 0)
            {
                currMoveSpeed = speed;
                rollCooldCounter = rollCooldown;
            }
        }
        // set cooldown for rolling
        if(rollCooldCounter > 0)
        {
            rollCooldCounter -= Time.deltaTime;
        }
    }

    void FlipChar()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;     // Flips the character sprite based on direction they moving
        scaler.x *= -1;
        transform.localScale = scaler;
    }


}
