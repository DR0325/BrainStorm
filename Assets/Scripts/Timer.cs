using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    bool timerActive;
    float currentTime;
    
    public float multiplierForScore;
    public int timeToDepreciateTimeScore;
    public int possibleTimeScore;
   private float depretiationMultiplier;
    public TMP_Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        startTime();
        //currentTime = startMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive)
        {
            currentTime += Time.deltaTime;
        }
        //string timePlayingStr = "Time : " + currentTime.ToString("mm' : 'ss' . 'ff");
        currentTimeText.text = currentTime.ToString();
        if(timeToDepreciateTimeScore < currentTime)
        {
            GameManager.Instance.totalTimeScore = (int)(possibleTimeScore - (possibleTimeScore * (multiplierForScore * depretiationMultiplier)));
                depretiationMultiplier += Time.deltaTime;
        }
        GameManager.Instance.time = currentTime;
    }

    public void startTime()
    {
        timerActive = true;

    }

    public void stopTime()
    {
        timerActive = false;

    }
}
