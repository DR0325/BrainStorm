using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The actual Game Manager instance protected behind a public getter
    /// </summary>
    private static GameManager _instance;
    /// <summary>
    /// Global getter which returns the instance
    /// </summary>
    public static GameManager Instance { get { return _instance; } }
    /// <summary>
    /// The number of enemies on screen which combat areas use to determine when to allow player progression
    /// </summary>
    public UInt64 EnemiesCount;
    /// <summary>
    /// Bool for pausing execution and presenting the pause menu 
    /// </summary>
    public bool Paused;
    /// <summary>
    /// Bool for controlling whether the player is inside a combat room (prevents player from going outside bounds of
    /// camera frustum)
    /// </summary>
    public bool InsideCombatRoom;
    

    // Coffee for the brain storm :-)
    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(gameObject);
        else _instance = this;
    }
}
