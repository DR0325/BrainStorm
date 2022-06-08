using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PickUpManager : MonoBehaviour
{
    public static PickUpManager instance;
    public TMP_Text starsText;
    public int stars;
    private void awake()
    {
        instance = this;
    }

    public void addStar()
    {
        stars++;
        starsText.text = stars.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
