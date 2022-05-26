using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // horizontal movement
    public float speed;
    private float moveInput;
    private Rigidbody2D rb;

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

    //Weapons

    public weaponScript currWeapon;
    private float fireRateCooldown;
    public float _offset;
    private GameObject rotationPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currMoveSpeed = speed;
        rotationPoint = GameObject.Find("RotationPoint");
        rotationPoint.GetComponentInChildren<SpriteRenderer>().sprite = currWeapon.currWeaponSpr;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Horizontal movement
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * currMoveSpeed, rb.velocity.y); 
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

        //Shooting
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - rotationPoint.transform.position;
        float zRotat = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotationPoint.transform.rotation = Quaternion.Euler(0f, 0f, zRotat + _offset);

        if (Time.time >= fireRateCooldown)
        {
            if (Input.GetMouseButton(0))
            {
                currWeapon.Shoot();
                fireRateCooldown = Time.time + 1 / currWeapon.fireRate;
            }
        }
    }


}
