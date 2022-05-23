using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Player : DestructableObject
{
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

    public float throwPsycheGrenadeForce;
    public float throwKineticGrenadeForce;
    public float dopamineProjectileForce;
    public float speedStairs;
    public float rateFight;
    public float _offsetWeap;
    public int currentLevel;
    public bool dontMoveOnStart;
    
    private Vector2 _moveDir;

   

    [Header("OBJECTS OF PLAYER")]
    public Rigidbody2D throwPsycheGrenade;

    public Rigidbody2D throwKineticGrenade;
    public Rigidbody2D throwDopamineProjectileRight;
    public Rigidbody2D throwDopamineProjectileLeft;
    public Rigidbody2D shootSerotoninProjectileRight;
    public Rigidbody2D shootSerotoninProjectileLeft;

    public Transform posPsycheGrenade;
    public Transform dopamineProjectilePosition;
    public Transform groundCheck;
    public Transform stairsCheck;
    public Transform obstacleCheck;
    public Transform energyPotionPrefab;
    public Transform healthPotionPrefab;
    public Transform shieldPotionPrefab;

    public Animator hurtEffect;
    public GameObject defeatAnimator;
    private GameObject _pauseMenu;
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

    [Header("UI LEFT UP BARS")]
    public GameObject staminaBar;

    public GameObject healthBar;
    public GameObject reuptakeBar;

 
    
    [HideInInspector]
    public float horizontal;

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


//Android and IOS control,variables which check which buttons was touched
[HideInInspector]
    public bool dopamineCannonAttack;

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

    private bool _check2;
    private bool _checkAndroidSword;
    private bool _checkAttack;
    private bool _checkDefeat;
    private bool _checkDefeat2;
    private bool _checkDefeat3;
    private bool _checkDopamineCannonThrow;
    private bool _psycheGrenadeThrow;
    private bool _checkDopamineCannonThrow2;

    private bool _checkSerotoninShells;
    private bool _checkFireArrow1;
    private bool _checkHurt;

    private bool _checkPotion;
    private bool _checkSound;
    private bool _checkStopSound;
    private bool _checkStopSound2;
    private bool _checkStuff;
    private bool _checkThrowArrow3;
    private bool _comma4;
    private bool _comma5;
    private bool _down;
    private bool _facingRight = true;
    private bool _flipPlayerRight;

    private bool _h;

    private bool _h1;

    private bool _h4;

    private bool _h5;
    private float _hurtTime2;
    private bool _i1;
    private bool _i2;
    private bool _i3;
    private bool _j;
    private bool _j1;
    private bool _j4;
    private bool _j5;
    private bool _k;
    private bool _k1;
    private bool _k4;
    private bool _k5;
    private bool _l;
    private bool _l1;
    private bool _l4;
    private bool _l5;
    private bool _leftSqureBracket1;
    private bool _leftSqureBracket2;
    private bool _leftSqureBracket3;
    private bool _leftSqureBracket4;
    private bool _leftSqureBracket5;
    private string _name = "";
    private float _nextAttackSound;
    private float _nextFightSound;
    private float _nextPotion;
    private float _nextThrow;
    private float _normalSpeed;

    private bool _notThrowDopamineCannon;
    private bool _runFight;
    private float _rateAttack;
    private bool _kineticGrenadeThrow;
    private float _grenadeThrowTime;
    private float _stopMoveTimeThrow;
    private bool _stuffAttackBut;
    private float _randomPositionPotion;
    private float _timeBowAnim;
    private float _timeDefeat;
    private float _timeFight;
    private float _timeScene;
    private float _timeStuffAttack;
    private float _timeThrow;
    private float _timeThrow2;
    private GameObject _whichEnemy;
    private GameObject _gun;
    private GameObject _bulletPrototype;
    private PlayerInputActions pImputActions;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    private void Awake()
    {
        respawnPoint = transform.position;
        pImputActions = new PlayerInputActions();
        currMoveSpeed = speedPlayer;
        DeathAction = () => { GameManager.Instance.paused = true; };
        _health = 100;
        _maxHealth = 100;
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
        stuffAttack = stuffAttack.GetComponent<BoxCollider2D>();
        _pauseMenu = GameObject.FindWithTag("Pause Menu");
        currMoveSpeed = speedPlayer;
        _timeScene = Time.time + 0.5f;
        
    }

    private void Update()
    {

    //    Vector3 mpos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        var position = transform.position;
      //  _gun.transform.rotation = Quaternion.LookRotation(Vector3.forward, mpos - position);
       // _bulletPrototype.transform.rotation = Quaternion.LookRotation(Vector3.forward, mpos - position);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, isGround);

        Vector3 difference = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - rotationPoint.transform.position;
        float zRotat = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotationPoint.transform.rotation = Quaternion.Euler(0f, 0f, zRotat + _offsetWeap);


        if (rollCooldCounter > 0)
        {
            rollCooldCounter -= Time.deltaTime;
        }


        if (Health <= 0f) dead = true;
        if (hurtTime < Time.time && _checkHurt)
        {
            // hurtEffect.SetBool("Hurt", true);
            _hurtTime2 = Time.time + 0.05f;

            _checkHurt = false;
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

        if (!dead)
        {
            velocityY = rb.velocity.y;    

            if (attackPlayerByEnemy && _rateAttack < Time.time)
            {
                _whichEnemy = GameObject.FindWithTag(whatTypeOfEnemy);

                Health -= ApplyDamage(_whichEnemy.GetComponent<Enemy>().enemyPower);
                _rateAttack = Time.time + _whichEnemy.GetComponent<Enemy>().attackTime;

                Debug.Log(attackPlayerByEnemy);
            }

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
            transform.position = respawnPoint;
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

    public void OnSwordAttack()
    {
        if (nextFight < Time.time && !_psycheGrenadeThrow && !_checkDopamineCannonThrow && !_checkStuff && !_down &&
            !anim.GetBool("Run"))
        {
            anim.SetBool("Fight", true);
            anim.SetBool("Attack2", false);

            fight1.enabled = true;

            simpleFight = true;

            checkIdle = true;
            timeIdle = rateTimeIdle + Time.time;

            if (_nextAttackSound < Time.time)
            {
                GameManager.Instance.attack1Sound = true;
                _nextAttackSound = Time.time + 0.32f;
                _checkAttack = true;
            }

            nextFight = Time.time + rateFight;
            _timeFight = Time.time + 0.1f;
            swordAttackBut = false;
        }
    }

    public void OnPsycheGrenadeAttack()
    {
        if (!_psycheGrenadeThrow && _timeFight < Time.time && GameManager.Instance.QtyPsycheGrenades > 0 &&
            Mathf.Abs(horizontal) < 0.1 && nextFight < Time.time && !_down)
        {
            anim.SetBool("ThrowPsycheGrenade", true);

            _psycheGrenadeThrow = true;

            _grenadeThrowTime = Time.time + 0.25f;
            _timeThrow = Time.time + 0.42f;
            _timeFight = Time.time + 0.578f;
        }
    }


    public void OnPausePress()
    {
        
    }

    private void Fight()
    {
        

        if (_timeFight < Time.time && !_down)
        {
            anim.SetBool("Fight", false);
            fight1.enabled = false;
        }

        if (_nextFightSound < Time.time)
            _checkSound = false;
        if (_nextAttackSound < Time.time)
            _checkAttack = false;

        

        if (_timeFight < Time.time && _checkDopamineCannonThrow2 && !_checkStuff)
        {
            ThrowDopamineProjectile();

            anim.SetBool("DopamineCannonAttack", false);

            _checkDopamineCannonThrow = false;
            _checkDopamineCannonThrow2 = false;
            _notThrowDopamineCannon = false;

            dopamineCannonAttack = false;
        }

        if (nextFight < Time.time && !_checkStuff && !_psycheGrenadeThrow && !_checkDopamineCannonThrow && !_down &&
            !_down && !anim.GetBool("Run"))
        {
            anim.SetBool("Attack2", true);
            anim.SetBool("Fight", false);

            fight2.enabled = true;
            GameManager.Instance.attack2Sound = true;

            simpleFight = true;
            swordAttackBut2 = false;

            checkIdle = true;
            timeIdle = rateTimeIdle + Time.time;

            nextFight = Time.time + 0.45f;
            _timeThrow = Time.time + 0.25f;
        }

        if (_timeThrow < Time.time)
        {
            anim.SetBool("Attack2", false);
            fight2.enabled = false;
            swordAttackBut2 = false;
        }

        

        if (_grenadeThrowTime < Time.time)
        {
            anim.SetBool("ThrowPsycheGrenade", false);
            anim.SetBool("ThrowKineticGrenade", false);
        }

        if (_timeThrow < Time.time && _psycheGrenadeThrow)
        {
            ThrowPsycheGrenade();

            _psycheGrenadeThrow = false;
            psycheGrenadeAttack = false;

            GameManager.Instance.throwPsycheGrenadeSound = true;
        }

        if (!_checkStuff && _timeFight < Time.time &&
            Mathf.Abs(horizontal) < 0.1f && !anim.GetBool("StuffAttack") && !_checkDopamineCannonThrow &&
            staminaBar.GetComponent<PlayerBar>().content.fillAmount > 0 && !_down)
        {
            anim.SetBool("StuffAttack", true);
            GameManager.Instance.checkStuffSound = true;

            activateEnergy = true;

            _checkStuff = true;

            _timeThrow = Time.time + 0.65f;
            _timeFight = Time.time + 0.95f;
        }

        if (_timeThrow < Time.time && _checkStuff)
        {
            anim.SetBool("StuffAttack", false);

            stuffAttack.enabled = true;
            _stuffAttackBut = false;

            _timeStuffAttack = Time.time + 0.1f;

            _checkStuff = false;
        }

        if (_timeStuffAttack < Time.time) stuffAttack.enabled = false;

        

        if (_timeFight < Time.time && _checkSerotoninShells)
        {
            if (Mathf.Abs(horizontal) < 0.1f)
                ShootSerotonin();

            anim.SetBool("SerotoninShotgun", false);

            _checkSerotoninShells = false;
            fireArrowAttack = false;
        }

        if (!_kineticGrenadeThrow && _timeFight < Time.time && GameManager.Instance.QtyKineticGrenades > 0 && 
            Mathf.Abs(horizontal) < 0.1f && nextFight < Time.time && !_down)
        {
            anim.SetBool("ThrowKineticGrenade", true);

            _kineticGrenadeThrow = true;

            _grenadeThrowTime = Time.time + 0.25f;
            _timeThrow = Time.time + 0.42f;
            _timeFight = Time.time + 0.578f;
        }

        if (_timeThrow < Time.time && _kineticGrenadeThrow && isGrounded)
        {
            ThrowKineticGrenade();

            _kineticGrenadeThrow = false;
            kineticGrenadeAttack = false;

            GameManager.Instance.throwPsycheGrenadeSound = true;
        }
    }

    public float ApplyDamage(float power)
    {
        float damage;

        damage = power / 20f;

        Health -= damage;

        _checkHurt = true;

        return damage;
    }

    private void ThrowPsycheGrenade()
    {
        Rigidbody2D clone;
        clone = Instantiate(throwPsycheGrenade, posPsycheGrenade.position, Quaternion.identity);

        GameManager.Instance.QtyPsycheGrenades--;

        if (transform.localScale.x > 0)
            clone.AddForce(new Vector2(throwPsycheGrenadeForce, throwPsycheGrenadeForce / 10f));
        else
            clone.AddForce(new Vector2(-throwPsycheGrenadeForce, throwPsycheGrenadeForce / 10f));
    }

    private void ThrowKineticGrenade()
    {
        Rigidbody2D clone;
        clone = Instantiate(throwKineticGrenade, posPsycheGrenade.position, Quaternion.identity);

        GameManager.Instance.QtyKineticGrenades--;

        if (transform.localScale.x > 0)
            clone.AddForce(new Vector2(throwKineticGrenadeForce, throwKineticGrenadeForce / 10f));
        else
            clone.AddForce(new Vector2(-throwKineticGrenadeForce, throwKineticGrenadeForce / 10f));
    }

    private void ThrowDopamineProjectile()
    {
        Rigidbody2D clone;

        GameManager.Instance.QtyDopamineCanisters--;
        GameManager.Instance.checkShotgunSound = true;

        if (transform.localScale.x > 0)
        {
            clone = Instantiate(throwDopamineProjectileRight, dopamineProjectilePosition.position, Quaternion.identity);
            clone.AddForce(new Vector2(dopamineProjectileForce, dopamineProjectileForce / 17f));
        }
        else
        {
            clone = Instantiate(throwDopamineProjectileLeft, dopamineProjectilePosition.position, Quaternion.identity);
            clone.AddForce(new Vector2(-dopamineProjectileForce, dopamineProjectileForce / 17f));
        }
    }

    private void ShootSerotonin()
    {
        Rigidbody2D clone;

        GameManager.Instance.QtySerotoninShells--;
        GameManager.Instance.checkShotgunSound = true;

        if (transform.localScale.x > 0)
        {
            clone = Instantiate(shootSerotoninProjectileRight, dopamineProjectilePosition.position, Quaternion.identity);
            clone.AddForce(new Vector2(dopamineProjectileForce, dopamineProjectileForce / 17f));
        }
        else
        {
            clone = Instantiate(shootSerotoninProjectileLeft, dopamineProjectilePosition.position, Quaternion.identity);
            clone.AddForce(new Vector2(-dopamineProjectileForce, dopamineProjectileForce / 17f));
        }
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

}

/// Modifier class which apply some kind of effect to the player during updates
public class Mod
{
}