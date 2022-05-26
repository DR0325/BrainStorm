using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] public float startingHealth;
    

    [Header("PROPERTIES OF PLAYER")]
    public float speedPlayer;
    public float runSpeed;

    [Header("JUMPING")]
    public float jumpForce;
    private float jumpTimeCount;
    public float jumpTime;
    public float checkRadius;

    [Header("ROLLING")]

    public float rollSpeed;
    public float rollLength;
    public float rollCooldown;
    private float rollCounter;
    private float rollCooldCounter;

    [Header("OTHERS")]

    public float throwGrenadeForce;
    public float speedStairs;
    public float rateFight;
    public float _offsetWeap;
    public int currentLevel;
    public bool dontMoveOnStart;
    
    private Vector2 _moveDir;

    public Transform groundCheck;
    public Animator hurtEffect;
    public GameObject defeatAnimator;
    public Animator shieldAnim;

    public BoxCollider2D fight1;
    public BoxCollider2D fight2;
    public BoxCollider2D stuffAttack;

    public LayerMask isGround;
    public LayerMask isStairs;
    
    public bool isItScene1;

    [Header("Weapon")]
    public weaponScript currWeapon;
    private float fireRateCooldown;
    public float _offset;
    private GameObject rotationPoint;

    [Header("InviFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField]private int numOfFlashes;
    private SpriteRenderer playerSprite;
    

    [Header("UI LEFT UP BARS")]
    public GameObject staminaBar;

    public GameObject healthBar;
    public GameObject reuptakeBar;

    [HideInInspector]
    public float horizontal;

    [HideInInspector]
    public float currentHealth;

    [HideInInspector]
    public float currMoveSpeed;

    [HideInInspector]
    public float velocityY;

    [HideInInspector]
    public float velocityX;

    [HideInInspector]
    public float defeatTime;

    [HideInInspector]
    public float groundCheckRadius = 0.2f;

    [HideInInspector]
    public float rateThrow = 0.01f;

    [HideInInspector]
    public Animator anim;

    [HideInInspector]
    public bool jump;

    [HideInInspector]
    public Rigidbody2D rb;

    [HideInInspector]
    public int deadEnemy;

    [HideInInspector]
    public bool simpleFight;

    [HideInInspector]
    public float nextFight;

    [HideInInspector]
    public bool dead;

    [HideInInspector]
    public bool checkStairs;

    [HideInInspector]
    public float timerJump;

    [HideInInspector]
    public string whatTypeOfEnemy;

    [HideInInspector]
    private bool isGrounded;

    [HideInInspector]
    public bool isJumping;

    [HideInInspector]
    public bool doubleJumped;

    [HideInInspector]
    public bool stairs;

    [HideInInspector]
    public bool attackPlayerByEnemy;

    [HideInInspector]
    public float rateTimeIdle;

    [HideInInspector]
    public float timeIdle;

    [HideInInspector]
    public bool checkIdle;

    [HideInInspector]
    public bool bridgeDead;

    [HideInInspector]
    public bool collisionPlayerEnemy;

    [HideInInspector]
    public bool caveExitAnim;

    [HideInInspector]
    public bool activateShield;

    [HideInInspector]
    public bool emptyShieldBar;

    [HideInInspector]
    public bool activateEnergy;

    [HideInInspector]
    public bool checkIfPotionIsAddedEnergy;

    [HideInInspector]
    public bool checkIfPotionIsAddedShield;

    [HideInInspector]
    public bool checkIfEpinepherineIsAddedHealth;

    [HideInInspector]
    public float hurtTime;

    [HideInInspector]
    public bool paused;

    [HideInInspector]
    public bool fireArrowAttack;

    public bool kineticGrenadeAttack;
    public bool psycheGrenadeAttack;

    [HideInInspector]
    public bool swordAttackBut;

    [HideInInspector]
    public bool swordAttackBut2;

    [HideInInspector]
    public bool shieldButAndroid;

    [HideInInspector]
    public bool moveLeftBut;

    [HideInInspector]
    public bool moveRightBut;

    [HideInInspector]
    public bool jumpBut;

    [HideInInspector]
    public bool runPlayer;

    private bool _facingRight = true;
    private bool _flipPlayerRight;

    private float _timeDefeat;
    private float _timeFight;
    private float _timeScene;

    private GameObject _whichEnemy;
    private GameObject _gun;
    private GameObject _bulletPrototype;
    private PlayerInputActions pImputActions;

    public GameObject fallDetector;

    private void Awake()
    {
        transform.position = GameManager.lastCheckPointPos;
        currentHealth = startingHealth;
        pImputActions = new PlayerInputActions();
        currMoveSpeed = speedPlayer;
        playerSprite = GetComponent<SpriteRenderer>();
    }


    private void Start()
    {
        _bulletPrototype = GameObject.Find("BulletPrototype");
        rotationPoint = GameObject.Find("RotationPoint");
        rotationPoint.GetComponentInChildren<SpriteRenderer>().sprite = currWeapon.currWeaponSpr;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //defeatAnimator = defeatAnimator.GetComponent<Animator> ();
        // hurtEffect = hurtEffect.GetComponent<Animator>();
        // shieldAnim = shieldAnim.GetComponent<Animator>();
        currMoveSpeed = speedPlayer;
        _timeScene = Time.time + 0.5f;
        
    }

    private void Update()
    {
        if (!dead && !paused)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, isGround);

            Vector3 difference = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - rotationPoint.transform.position;
            float zRotat = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            rotationPoint.transform.rotation = Quaternion.Euler(0f, 0f, zRotat + _offsetWeap);


            if (rollCooldCounter > 0)
            {
                rollCooldCounter -= Time.deltaTime;
            }

            if (runPlayer && GameManager.Instance.uiStaminaBar.GetComponent<PlayerBar>().content.fillAmount <= 0.0f)
            {
                activateEnergy = false;
                runPlayer = false;
                speedPlayer = 0.6f;
            }

            // Fall detection 

            fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

            // -------
            velocityY = rb.velocity.y;    

            // ----- Shooting -----

            if (Time.time >= fireRateCooldown)
            {
                if (pImputActions.Player.ShootWeapon.ReadValue<float>() > 0.1f)
                {
                    currWeapon.Shoot();
                    fireRateCooldown = Time.time + 1 / currWeapon.fireRate;
                }
            }

            // ------- Rolling ----------

            // stop "rolling" and go back to normal move speed once timer hits 0
            if (rollCounter > 0)
            {
                rollCounter -= Time.deltaTime;

                if (rollCounter <= 0)
                {
                    currMoveSpeed = speedPlayer;
                    Physics2D.IgnoreLayerCollision(10, 9, false);
                    rollCooldCounter = rollCooldown;
                }
            }
            // set cooldown for rolling
            if (rollCooldCounter > 0)
            {
                rollCooldCounter -= Time.deltaTime;
            }

            // ------------------

            if (Mathf.Abs(horizontal) < 0.01 && checkIdle == false)
            {
                checkIdle = true;
                timeIdle = rateTimeIdle + Time.time;
            }

            if (Mathf.Abs(horizontal) > 0.01)
            {
                checkIdle = false;
                // anim.SetBool("SecondIdle", false);
            }

            // if (checkIdle && timeIdle < Time.time) anim.SetBool("SecondIdle", true);

            if (stairs)
                MoveOnStairs();
            if (!stairs)
            {
                GetComponent<CircleCollider2D>().isTrigger = false;
                GetComponent<BoxCollider2D>().isTrigger = false;
            }

            CollectResources();

            // anim.SetFloat("speed", Mathf.Abs(horizontal));
            // anim.SetBool("Grounded", grounded);
            // anim.SetFloat("vSpeed", rb.velocity.y);
        }

        // if (dead && !bridgeDead) anim.SetBool("Dead", true);
    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            _moveDir = pImputActions.Player.Move.ReadValue<Vector2>();

            if (_moveDir.x != 0.0f)
            {
                anim.SetBool("Walk", true);
            }
            else
            {
                anim.SetBool("Walk", false);
            }

            if (!stairs)
            {
                horizontal = _moveDir.x;
                rb.velocity = new Vector2(horizontal * currMoveSpeed, rb.velocity.y);

                //Control for mobile devices
                if (moveLeftBut && !moveRightBut)
                {
                    transform.Translate(-currMoveSpeed * Time.deltaTime, 0, 0);
                    horizontal = 1f;
                }

                if (moveRightBut && !moveLeftBut)
                {
                    rb.velocity = new Vector2(horizontal * currMoveSpeed, rb.velocity.y);
                    horizontal = 1f;
                    if (_flipPlayerRight)
                    {
                        var theScale = transform.localScale;

                        theScale.x *= -1;

                        transform.localScale = theScale;

                        _flipPlayerRight = false;
                    }
                }
                // if (!moveLeftBut && !moveRightBut)
                // horizontal = 0f;
            }
        }
    }

    private void OnEnable()
    {
        pImputActions.Player.Enable();
    }

    private void OnDisable()
    {
        pImputActions.Player.Enable();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Addict" || other.gameObject.tag == "Shame" || other.gameObject.tag == "Fear" ||
            other.gameObject.tag == "Calamity" || other.gameObject.tag == "Grief" || other.gameObject.tag == "Depression")
            collisionPlayerEnemy = false;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Addict" || other.gameObject.tag == "Shame" || other.gameObject.tag == "Fear" ||
            other.gameObject.tag == "Calamity" ||
            other.gameObject.tag == "Grief" || other.gameObject.tag == "Depression")
            collisionPlayerEnemy = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DeathBarrier"))
        {
            TakeDamage(10f);
            transform.position = GameManager.lastCheckPointPos;
        }
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //anim.SetTrigger("hurt");
            Debug.Log("ouch");
            StartCoroutine(IFrames());
        }
        else
        {
            if (!dead)
            {
                //anim.SetTrigger("die");
                dead = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void OnRun(InputValue value)
    {
        runPlayer = value.Get<float>() > 0.0f;
        activateEnergy = runPlayer;
        anim.SetBool("Run", runPlayer);
        currMoveSpeed = runPlayer ? runSpeed : 6.0f;
    }
    public void OnMove(InputValue value)
    {
        _moveDir = value.Get<Vector2>();
        
            if (_moveDir.x != 0.0f)
            {
                anim.SetBool("Walk", true);
            }
            else
            {
                anim.SetBool("Walk", false);
            }
    }
    
    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded == true)
        {
            Debug.Log("Jump");
            anim.SetBool("Jump", true);
            isJumping = true;
            jumpTimeCount = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
       
        if (value.isPressed && isJumping == true)
        {
            if (jumpTimeCount > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCount -= Time.deltaTime;
            }
            else
            {
                anim.SetBool("Jump", false);
                isJumping = false;
            }
        }
        if (value.isPressed == false)
        {
            isJumping = false;
        }
    }

    private void OnRoll()
    {
        if (rollCooldCounter <= 0 && rollCounter <= 0) 
        {
            currMoveSpeed = rollSpeed;
            Physics2D.IgnoreLayerCollision(10, 9, true);
            rollCounter = rollLength;
        }
    }

    private void MoveOnStart()
    {
        //transform.Translate(speedPlayer * Time.deltaTime, 0, 0);
    }

    private void Flip(float horizontal)
    {
        if ((horizontal > 0 && !_facingRight) || (horizontal < 0 && _facingRight))
        {
            _facingRight = !_facingRight;

            var theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    public void OnPausePress()
    {
        
    }

    private void CollectResources()
    {
        // if ( && GameManager.Instance.inAreaTrunk) GameManager.Instance.addBrainCells = true;
    }

    private void MoveOnStairs()
    {
        gameObject.GetComponent<Rigidbody2D>().Sleep();
        GetComponent<CircleCollider2D>().isTrigger = true;
        GetComponent<BoxCollider2D>().isTrigger = true;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || jumpBut)
            transform.Translate(0, speedStairs * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            transform.Translate(0, -speedStairs * Time.deltaTime, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //checkStairs = false;
        }
    }

    private void NotStayAboveEnemy()
    {
        if (collisionPlayerEnemy && transform.position.y > -0.6f)
        {
            if (transform.localScale.x > 0)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(50f, 0), ForceMode2D.Force);
            else
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-50f, 0), ForceMode2D.Force);
        }
    }

    private void Down()
    {
        // For downward movement on the control
        return;
    }

    public IEnumerator IFrames()
    {
        Physics2D.IgnoreLayerCollision(10, 9, true);
        for (int i = 0; i < numOfFlashes; i++)
        {
            playerSprite.color = Color.red;
            yield return new WaitForSeconds(iFramesDuration / (numOfFlashes * 2));
            playerSprite.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 9, false);
    }

}

/// Modifier class which apply some kind of effect to the player during updates
public class Mod
{
}