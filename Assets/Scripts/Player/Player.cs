using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource ShootSoundEffect;
    [SerializeField] private AudioSource RunSoundEffect;
    [SerializeField] private AudioSource DeathSoundEffect;

    [Header("Health")]
    [SerializeField] public float startingHealth;
    

    [Header("PROPERTIES OF PLAYER")]
    public float speedPlayer;
    public float runSpeed;

    [Header("JUMPING")]
    private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

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
    public Animator swordAnim;

    public BoxCollider2D fight1;
    public BoxCollider2D fight2;
    public BoxCollider2D stuffAttack;

    public LayerMask isGround;
    public LayerMask isEnviroment;
    public LayerMask isStairs;
    
    public bool isItScene1;

    [Header("Weapon")]
    public int selectedWeapon = 0;
    private int prevSelWeapon;
    public Transform weaponHolder;
    public weaponScript currWeapon;
    private float fireRateCooldown;
    public float _offset;
    private GameObject rotationPoint;
    public GameObject gun;
    

    [Header("Melee")]
    private float timebtwAtk;
    public float startTimeBtwAtk;

    public Transform attackPos;
    public float atkRange;
    public LayerMask whatIsEnemy;
    public float swordDmg;

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
    public float groundCheckRadius;

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
    public bool moveLeftBut;

    [HideInInspector]
    public bool moveRightBut;

    [HideInInspector]
    public bool jumpBut;

    [HideInInspector]
    public bool runPlayer;

    private bool _facingRight = true;
    private bool _flipPlayerRight;
    private bool isClipping;

    private float _timeScene;

    private GameObject _whichEnemy;
    private GameObject _gun;
    public PlayerInputActions pImputActions;
    private bool meleeOnly;
    public Transform shootPoint;
    public Collider2D weaponClipCheck;

    public GameObject trail;

    public static Player instance;

    private void Awake()
    {
        currentHealth = startingHealth;
        pImputActions = new PlayerInputActions();
        currMoveSpeed = speedPlayer;
        playerSprite = GetComponent<SpriteRenderer>();
    }


    private void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 9, false);
        meleeOnly = StateNameController.meleeOnly;
        rotationPoint = GameObject.Find("RotationPoint");
        weaponHolder.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = currWeapon.currWeaponSpr;
        SelectWeapon();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //defeatAnimator = defeatAnimator.GetComponent<Animator> ();
        // hurtEffect = hurtEffect.GetComponent<Animator>(); 
        currMoveSpeed = speedPlayer;
        _timeScene = Time.time + 0.5f;
        if(meleeOnly == true)
        {
            selectedWeapon = 1;
            SelectWeapon();
        }
        
    }

    private void Update()
    {
        if (!dead && !paused)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, isGround);

            Vector3 difference = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - rotationPoint.transform.position;
            float zRotat = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            rotationPoint.transform.rotation = Quaternion.Euler(0f, 0f, zRotat + _offsetWeap);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            if (mousePos.x > gameObject.transform.position.x && _facingRight == false)
            {
                _facingRight = true;
                Flip();    
            }
            if (mousePos.x < gameObject.transform.position.x && _facingRight == true)
            {
                _facingRight = false;
                Flip();
            }

            if(currMoveSpeed <= speedPlayer)
            {
                anim.SetBool("Run", false);
                trail.SetActive(false);
            }
            if(currMoveSpeed > speedPlayer)
            {
                trail.SetActive(true);
            }

            //------- Jump --------

            if(isGrounded == true)
            {
                anim.SetBool("Jump", false);
                coyoteTimeCounter = coyoteTime;
            }
            else
            {
                coyoteTimeCounter -= Time.deltaTime;
            }

            if (pImputActions.Player.Jump.IsPressed())
            {
                jumpBufferCounter = jumpBufferTime;
            }
            else
            {
                jumpBufferCounter -= Time.deltaTime;
            }

            if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
            {
                anim.SetBool("Jump", true);
                isJumping = true;
                jumpSoundEffect.Play();
                jumpBufferCounter = 0f;
                coyoteTimeCounter = 0f;
                jumpTimeCount = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
            }
            
            if (pImputActions.Player.Jump.IsPressed() && isJumping == true)
            {
                if (jumpTimeCount > 0)
                {
                    rb.velocity = Vector2.up * (jumpForce * 0.75f);
                    jumpTimeCount -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }
            if (pImputActions.Player.Jump.IsPressed() == false)
            {
                isJumping = false;
            }
            
            //---------------

            if (rollCooldCounter > 0)
            {
                rollCooldCounter -= Time.deltaTime;
            }

            if (runPlayer && GameManager.Instance.uiStaminaBar.GetComponent<PlayerBar>().content.fillAmount <= 0.0f)
            {
                activateEnergy = false;
                runPlayer = false;
                //speedPlayer = 0.6f;
            }

            // -------
            velocityY = rb.velocity.y;

            //------Weapon Switching -----------

            prevSelWeapon = selectedWeapon;

            // ----- Shooting -----

            if (Time.time >= fireRateCooldown && gun.activeSelf && !weaponClipCheck.IsTouchingLayers(isEnviroment))
            {
                if (pImputActions.Player.ShootWeapon.ReadValue<float>() > 0.1f)
                {
                    currWeapon.Shoot();
                    ShootSoundEffect.Play();
                    fireRateCooldown = Time.time + 1 / currWeapon.fireRate;
                }
            }

            // ----- Melee ---------

            if (timebtwAtk <= 0)
            {
                if (pImputActions.Player.ShootWeapon.ReadValue<float>() > 0.1f && selectedWeapon == 1)
                {
                    swordAnim.SetBool("isAttacking", true);
                    Collider2D damageEnemy = Physics2D.OverlapCircle(attackPos.position, atkRange, whatIsEnemy);
                    if (damageEnemy != null)
                    {
                        
                            if (damageEnemy.CompareTag("Enemy") || damageEnemy.CompareTag("CombatEnemy"))
                            {
                                damageEnemy.GetComponent<Enemy>().TakeDamage(swordDmg);
                            }
                        
                    }
                    timebtwAtk = startTimeBtwAtk;
                }
            } else
            {
                swordAnim.SetBool("isAttacking", false);
                timebtwAtk -= Time.deltaTime;
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
                    anim.SetBool("Roll", false);
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


            CollectResources();

            // anim.SetFloat("speed", Mathf.Abs(horizontal));
            // anim.SetBool("Grounded", grounded);
            // anim.SetFloat("vSpeed", rb.velocity.y);
        }

        // if (dead && !bridgeDead) anim.SetBool("Dead", true);
    }

    private void FixedUpdate()
    {
        if (!dead && !paused)
        {
            _moveDir = pImputActions.Player.Move.ReadValue<Vector2>();

            if (_moveDir.x != 0.0f && isGrounded)
            {
                anim.SetBool("Walk", true);
                RunSoundEffect.Play();
            }
            else
            {
                anim.SetBool("Walk", false);
                RunSoundEffect.Stop();
            }

            if(pImputActions.Player.Run.IsPressed() == false && rollCounter <= 0)
            {
                currMoveSpeed = speedPlayer;
            }
           
             horizontal = _moveDir.x;
             rb.velocity = new Vector2(horizontal * currMoveSpeed, rb.velocity.y);
            
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, atkRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(shootPoint.position, 0.1f);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Star"))
        {
            Destroy(other);
        }
        if (other.CompareTag("DeathBarrier"))
        {
            TakeDamage(10f);
            transform.position = GameManager.lastCheckPointPos;
        }
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in weaponHolder)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    public void OnSwitchWeapon(InputValue value)
    {
        if (!dead && !paused)
        {
            if (meleeOnly == false)
            {
                if (value.Get<float>() > 0f)
                {
                    if (selectedWeapon >= weaponHolder.childCount - 1)
                    {
                        selectedWeapon = 0;
                    }
                    else
                        selectedWeapon++;
                }
                if (value.Get<float>() < 0f)
                {
                    if (selectedWeapon <= 0)
                    {
                        selectedWeapon = weaponHolder.childCount - 1;
                    }
                    else
                        selectedWeapon--;
                }

                if (prevSelWeapon != selectedWeapon)
                {
                    SelectWeapon();
                }
            }
        }
    }
    public void OnSwitchWeapon1()
    {
        if (!dead && !paused)
        {
            if (meleeOnly == false)
            {
                selectedWeapon = 0;

                if (prevSelWeapon != selectedWeapon)
                {
                    SelectWeapon();
                }
            }
        }
    }

    public void OnSwitchWeapon2()
    {
        if (!dead && !paused)
        {
            if (meleeOnly == false)
            {
                if (weaponHolder.childCount >= 2)
                    selectedWeapon = 1;

                if (prevSelWeapon != selectedWeapon)
                {
                    SelectWeapon();
                }
            }
        }
    }
    public void OnSwitchWeapon3()
    {
        if (!dead && !paused)
        {
            if (meleeOnly == false)
            {
                if (weaponHolder.childCount >= 3)
                    selectedWeapon = 2;

                if (prevSelWeapon != selectedWeapon)
                {
                    SelectWeapon();
                }
            }
        }
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //anim.SetTrigger("hurt");
            StartCoroutine(IFrames());
        }
        else
        {
            if (!dead)
            {
                pImputActions.Disable();
                rb.velocity = new Vector2(0f,0f);
                DeathSoundEffect.Play();
                playerSprite.color = Color.gray;
                anim.SetBool("Dead", true);
                dead = true;
                StartCoroutine(deadRespawn());
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
    }
    
    public void OnJump(InputValue value)
    {
         
    }

    private void OnRoll()
    {
        if (!dead && !paused)
        {
            if (rollCooldCounter <= 0 && rollCounter <= 0)
            {
                currMoveSpeed = rollSpeed;
                Physics2D.IgnoreLayerCollision(10, 9, true);
                anim.SetBool("Roll", true);
                rollCounter = rollLength;
            }
        }
    }

    private void MoveOnStart()
    {
        //transform.Translate(speedPlayer * Time.deltaTime, 0, 0);
    }

    private void Flip()
    {
        playerSprite.flipX = !playerSprite.flipX;
    }

    public void OnPausePress()
    {
        
    }

    private void CollectResources()
    {
        // if ( && GameManager.Instance.inAreaTrunk) GameManager.Instance.addBrainCells = true;
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

    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;
        while(knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * knockbackPower);
        }
            yield return 0;
    }

    private IEnumerator deadRespawn()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

/// Modifier class which apply some kind of effect to the player during updates
public class Mod
{
}