using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    GameObject[] enemies;
    public TMP_Text enemyCountText;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("CombatEnemy");

        enemyCountText.text = "Enemies: " + enemies.Length.ToString();
    }
}
