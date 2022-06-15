using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public static LevelTimer instance;

    public TMP_Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        BeginTimer();
        timeCounter.text = "Time:00:00.00";
        timerGoing = false;

    }

    public void BeginTimer()
    {
        timerGoing = true;
        //startTime = Time.time;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time : " + timePlaying.ToString("mm' : 'ss' . 'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
