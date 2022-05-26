using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("GAME MANAGER GLOBALS")] 
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameOverScreen gameOverScreen;

    public GameObject player;
    private Player _player;

    public Transform levelStartPos;
    public static Vector2 lastCheckPointPos = new Vector2(30,15);

    [Header("LEVEL STATE")] 
    [HideInInspector] public int enemiesCount;
    [HideInInspector] public bool paused = false;
    [HideInInspector] public bool insideCombatRoom;
    [HideInInspector] public int score;
    [HideInInspector] public string sceneName;
    [HideInInspector] public bool trunkOpen;
    [HideInInspector] public bool battleSound;
    [HideInInspector] public bool addBrainCells;
    [HideInInspector] public bool inAreaTrunk;
    [HideInInspector] public bool empty;
    [HideInInspector] public bool brainCellsAdded = false;
    [HideInInspector] public bool attack1Sound;
    [HideInInspector] public bool throwPsycheGrenadeSound;
    [HideInInspector] public bool attack2Sound;
    [HideInInspector] public bool healthPotion;
    [HideInInspector] public bool woodBreakingSound;
    [HideInInspector] public bool collectBrainCellsSound;
    [HideInInspector] public bool checkShotgunSound;
    [HideInInspector] public bool checkStuffSound;
    [HideInInspector] public bool shieldPotionSound;
    [HideInInspector] public bool energyPotionSound;
    [HideInInspector] public bool crystalSound;
    [HideInInspector] public bool checkShieldSound;
    [HideInInspector] public bool checkShieldSound2;
    [HideInInspector] public bool magicBlastSound;
    [HideInInspector] public bool checkDefeatedSound;
    [HideInInspector] public bool checkBattleSound2;
    [HideInInspector] public bool checkFireExplosion;
    [HideInInspector] public int numberOfEnemy;
    [HideInInspector] public bool lookedTrunk;
    [HideInInspector] public bool openTrunk;

    [Header("GAME SOUNDS")] 
    public AudioSource musicSource;
    public AudioSource audioSource;
    [Header("PLAYER RESOURCES")] 
    private int _qtyEpinepherine;
    private int _qtyReuptakeInhibitor;
    private int _qtyDopamineCanisters;
    private int _qtyExperience;
    private int _qtyPsycheGrenades;
    private int _qtyKineticGrenades;
    private int _qtySerotoninShells;
    /// <summary>
    /// Healing Item
    /// </summary>
    public int QtyEpinepherine
    {
        get => _qtyEpinepherine;
        set
        {
            const int max = 5;
            _qtyEpinepherine = Math.Clamp(value, 0, max);
            uiQtyEpinepherine.text = $"{_qtyEpinepherine}/{max}";
        }
    }
    /// <summary>
    /// Slow Motion Item
    /// </summary>
    public int QtyReuptakeInhibitor
    {
        get => _qtyReuptakeInhibitor;
        set
        {
            const int max = 5;
            _qtyReuptakeInhibitor = Math.Clamp(value, 0, max);
            uiQtyReuptakeInhibitor.text = $"{_qtyReuptakeInhibitor}/{max}";
        }
    }
    /// <summary>
    /// Dopamine cannon ammo
    /// </summary>
    public int QtyDopamineCanisters
    {
        get => _qtyDopamineCanisters;
        set
        {
            const int max = 5;
            _qtyDopamineCanisters = Math.Clamp(value, 0, max);
            uiQtyDopamineCanisters.text = $"{_qtyDopamineCanisters}/{max}";
        }
    }
    /// <summary>
    /// For player upgrades
    /// </summary>
    public int QtyExperience
    {
        get => _qtyExperience;
        set
        {
            const int max = int.MaxValue;
            _qtyExperience = Math.Clamp(value, 0, max);
            uiQtyExperience.text = $"{_qtyExperience}";
        }
    }
    /// <summary>
    /// Like fire grenades but for the mind
    /// </summary>
    public int QtyPsycheGrenades
    {
        get => _qtyPsycheGrenades;
        set
        {
            const int max = 3;
            _qtyPsycheGrenades = Math.Clamp(value, 0, max);
            uiQtyPsycheGrenades.text = $"{_qtyPsycheGrenades}/{max}";
        }
    }
    /// <summary>
    /// Grenades that go BOOM
    /// </summary>
    public int QtyKineticGrenades
    {
        get => _qtyKineticGrenades;
        set
        {
            const int max = 3;
            _qtyKineticGrenades = Math.Clamp(value, 0, max);
            uiQtyKineticGrenades.text = $"{_qtyKineticGrenades}/{max}";
        }
    }
    /// <summary>
    /// Like shotgun shells but feels better
    /// </summary>
    public int QtySerotoninShells
    {
        get => _qtySerotoninShells;
        set
        {
            const int max = 20;
            _qtySerotoninShells = Math.Clamp(value, 0, max);
            uiQtySerotoninShells.text = $"{_qtySerotoninShells}/{max}";
        }
    }

    [Header("PLAYER RESOURCE UI")] 
    public Text uiQtyEpinepherine;
    public Text uiQtyReuptakeInhibitor;
    public Text uiQtyDopamineCanisters;
    public Text uiQtySerotoninShells;
    public Text uiQtyExperience;
    public Text uiQtyPsycheGrenades;
    public Text uiQtyKineticGrenades;
    public GameObject uiHealthBar;
    public GameObject uiStaminaBar;
    public GameObject uiReuptakeBar;
    [Header("UI Objects")] 
    public GameObject upgrades;
    public GameObject pauseMenu;
    public GameObject lvlClearMenu;
    

    private float _timeScale;

    /// Coffee for the brain storm :-)
    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(gameObject);
        else _instance = this;
    }

    private void Start()
    {
        lastCheckPointPos = levelStartPos.position;
        Time.timeScale = 1f;
        uiHealthBar = GameObject.FindWithTag("HealthBar");
        uiStaminaBar = GameObject.FindWithTag("StaminaBar");
        uiReuptakeBar = GameObject.FindWithTag("ReuptakeBar");
    }

    private void Update()
    {
        
    }


    public void Restart()
    {
        gameHasEnded = false;
        paused = false;
        Time.timeScale = 1f;
        lastCheckPointPos = levelStartPos.position;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        //gameOverScreen.gameObject.SetActive(false);
    }

    public void OnPausePress(InputValue value)
    {
        if (gameHasEnded == false)
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        player.GetComponent<Player>().paused = false;
        Time.timeScale = 1f;
        paused = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        player.GetComponent<Player>().paused = true;
        Time.timeScale = 0f;
        paused = true;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelComplete()
    {
        lastCheckPointPos = levelStartPos.position;
        gameHasEnded = true;
        Time.timeScale = 0f;
        lvlClearMenu.SetActive(true);
        lvlClearMenu.GetComponent<LevelClearInfo>().Setup(score);

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}