using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    private GameManager gm;
    private Slider sliderInfo;
    private float initHealth;
    bool fixHealth = false;

    // Start is called before the first frame update
    void Start()
    {
        fixHealth = false;
        gm = FindObjectOfType<GameManager>();
        sliderInfo = gm.uiBossBar.GetComponent<Slider>();
        sliderInfo.maxValue = gameObject.GetComponentInChildren<Enemy>().health;
        Activate();
    }

    // Update is called once per frame
    void Update()
    {
        if (sliderInfo != null)
        {
            if (sliderInfo.maxValue != gameObject.GetComponentInChildren<Enemy>().health && fixHealth == false)
            {
                sliderInfo.maxValue = gameObject.GetComponentInChildren<Enemy>().health;
                fixHealth = true;
            }
            else
            {
                sliderInfo.value = gameObject.GetComponentInChildren<Enemy>().health;
                fixHealth = true;
            }
        }
    }

    public void Activate()
    {
        gm.uiBossBar.SetActive(true);
    }

    public void Deactivate()
    {
        gm.uiBossBar.SetActive(false);
    }
}
