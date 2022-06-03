using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    GameObject[] enemies;
    public Text enemyCountText;
    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemyCountText.text = "Enemies: " + enemies.Length.ToString();
    }
}
