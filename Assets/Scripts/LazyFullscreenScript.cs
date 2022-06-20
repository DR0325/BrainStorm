using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazyFullscreenScript : MonoBehaviour
{
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = Screen.fullScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
