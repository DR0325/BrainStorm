using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Player : DestructableObject
{
    [Header("PROPERTIES OF PLAYER")]
    public float speedPlayer;

    public float runSpeed;
    public float jumpDistance;
    public float throwPsycheGrenadeForce;
    public float throwKineticGrenadeForce;
    public float dopamineProjectileForce;
    public float speedStairs;
    public float rateFight;
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

    public LayerMask whatIsGround;
    public LayerMask isStairs;
    
    public bool isItScene1;

    [Header("UI LEFT UP BARS")]
    public GameObject staminaBar;

    public GameObject healthBar;
    public GameObject reuptakeBar;

    [HideInInspector]
    public float horizontal;

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
    public bool grounded;

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

    private bool _checkJump;
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

    private void Awake()
    {
        DeathAction = () => { GameManager.Instance.paused = true; };
        _health = 100;
        _maxHealth = 100;
    }


    private void Start()
    {
        _bulletPrototype = GameObject.Find("BulletPrototype");
        _gun = GameObject.Find("Gun");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //defeatAnimator = defeatAnimator.GetComponent<Animator> ();
        // hurtEffect = hurtEffect.GetComponent<Animator>();
        // shieldAnim = shieldAnim.GetComponent<Animator>();
        stuffAttack = stuffAttack.GetComponent<BoxCollider2D>();
        _pauseMenu = GameObject.FindWithTag("Pause Menu");
        _normalSpeed = speedPlayer;
        _timeScene = Time.time + 0.5f;
    }

    private void Update()
    {
        Vector3 mpos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        var position = transform.position;
        _gun.transform.rotation = Quaternion.LookRotation(Vector3.forward, mpos - position);
        _bulletPrototype.transform.rotation = Quaternion.LookRotation(Vector3.forward, mpos - position);
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

        if (!dead)
        {
            velocityY = rb.velocity.y;

            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

            if (grounded)
            {
                rb.WakeUp();
                doubleJumped = false;
                rb.isKinematic = false;
                checkStairs = true;
            }

            if (timerJump < Time.time && grounded && velocityY < 1f)
            {
                anim.SetBool("Jump", false);
                jumpBut = false;
                _checkJump = false;
            }

            if (attackPlayerByEnemy && _rateAttack < Time.time)
            {
                _whichEnemy = GameObject.FindWithTag(whatTypeOfEnemy);

                Health -= ApplyDamage(_whichEnemy.GetComponent<Enemy>().enemyPower);
                _rateAttack = Time.time + _whichEnemy.GetComponent<Enemy>().attackTime;

                Debug.Log(attackPlayerByEnemy);
            }

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
        Move();
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

    public void OnRun(InputValue value)
    {
        runPlayer = value.Get<float>() > 0.0f;
        activateEnergy = runPlayer;
        anim.SetBool("Run", runPlayer);
        speedPlayer = runPlayer ? runSpeed : 6.0f;
    }
    public void OnMove(InputValue value)
    {
        _moveDir = value.Get<Vector2>();
        // if (!anim.GetBool("Run"))
        // {
            if (_moveDir.x != 0.0f)
            {
                anim.SetBool("Walk", true);
            }
            else
            {
                anim.SetBool("Walk", false);
            }
        // }
    }

    public void OnJump()
    {
        rb.AddForce(new Vector2(0, jumpDistance));

        if (!_checkJump)
        {
            timerJump = Time.time + 0.1f;
            _checkJump = true;
        }

        anim.SetBool("Jump", true);
    }

    public void OnLook(InputValue value)
    {
        // var cursorpos = value.Get<Vector2>();
        // var position = transform.position;
        // var angle = Vector2.Angle(new Vector2(position.x, position.y), cursorpos);
        // GameObject.Find("Gun").transform.eulerAngles = new Vector3(0, 0, angle);
        // Debug.Log(cursorpos);
    }
    private void Move()
    {
        if (!stairs)
        {
            var translation = _moveDir.x * speedPlayer * Time.deltaTime;

            horizontal = _moveDir.x;
            if (horizontal < 0.0f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (horizontal > 0.0f)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            transform.Translate(translation, 0, 0);
            //Control for mobile devices
            if (moveLeftBut && !moveRightBut)
            {
                transform.Translate(-speedPlayer * Time.deltaTime, 0, 0);
                horizontal = 1f;

                if (!_flipPlayerRight)
                {
                    var theScale = transform.localScale;

                    theScale.x *= -1;

                    transform.localScale = theScale;

                    _flipPlayerRight = true;
                }
            }

            if (moveRightBut && !moveLeftBut)
            {
                transform.Translate(speedPlayer * Time.deltaTime, 0, 0);
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
    
    

    private void MoveOnStart()
    {
        transform.Translate(speedPlayer * Time.deltaTime, 0, 0);
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

    public void OnDopamineCannonAttack()
    {
        var clone = GameObject.Instantiate(_bulletPrototype);
        clone.transform.position = transform.position;
        var bscript = clone.GetComponent<projectile>();
        var euler = transform.rotation.eulerAngles;
        bscript.direction = new Vector2(-euler.x, euler.y);
        bscript.enabled = true;

        // if ( !_checkStuff && nextFight < Time.time && !_checkDopamineCannonThrow &&
        //     GameManager.Instance.QtyDopamineCanisters > 0 && !_down && !_psycheGrenadeThrow &&
        //     !anim.GetBool("DopamineCannonAttack"))
        // {
        //     anim.SetBool("DopamineCannonAttack", true);
        //
        //     _checkDopamineCannonThrow = true;
        //     _checkDopamineCannonThrow2 = true;
        //     _notThrowDopamineCannon = true;
        //
        //     _timeFight = Time.time + 0.48f;
        //     nextFight = Time.time + 0.689f;
        //
        //     dopamineCannonAttack = false;
        // }
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

    public void OnSerotoninShotgunAttack()
    {
        if (!_checkStuff && nextFight < Time.time && !_checkSerotoninShells && Mathf.Abs(horizontal) < 0.05f &&
            GameManager.Instance.QtySerotoninShells > 0 && !_psycheGrenadeThrow && 
            // !anim.GetBool("shotgunAttack") &&
            !_down)
        {
            // anim.SetBool("SerotoninShotgun", true);

            _checkSerotoninShells = true;

            _timeFight = Time.time + 0.48f;
            nextFight = Time.time + 0.689f;
        }
    }

    public void OnKineticGrenadeAttack()
    {
        if (!_kineticGrenadeThrow && _timeFight < Time.time && GameManager.Instance.QtyKineticGrenades > 0 && 
            Mathf.Abs(horizontal) < 0.1f && nextFight < Time.time && !_down)
        {
            // anim.SetBool("ThrowKineticGrenade", true);

            _kineticGrenadeThrow = true;

            _grenadeThrowTime = Time.time + 0.25f;
            _timeThrow = Time.time + 0.42f;
            _timeFight = Time.time + 0.578f;
        }
    }

    public void OnPausePress()
    {
        var pm = GameObject.Find("PauseMenu"); 
        pm.SetActive(!pm.activeSelf);
        gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap(_pauseMenu.activeSelf ? "UI" : "Player");
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

        if (_timeThrow < Time.time && _kineticGrenadeThrow && grounded)
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