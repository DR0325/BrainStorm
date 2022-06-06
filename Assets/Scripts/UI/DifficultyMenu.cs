using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DifficultyMenu : MonoBehaviour
{
    public GameObject menu;
    private float healthMult;
    private float dmgMult;
    // Start is called before the first frame update

    private void Start()
    {
      
    }

    public void DiffNormal()
    {
        healthMult = 1;
        dmgMult = 1;
        StateNameController.damageMultiplier = dmgMult;
        StateNameController.healthMultiplier = healthMult;
        menu.SetActive(false);
    }

    public void DiffHard()
    {
        healthMult = 1.5f;
        dmgMult = 2;
        StateNameController.damageMultiplier = dmgMult;
        StateNameController.healthMultiplier = healthMult;
        menu.SetActive(false);
    }

    public void DiffMelee()
    {
        healthMult = 1.5f;
        dmgMult = 2;
        StateNameController.damageMultiplier = dmgMult;
        StateNameController.healthMultiplier = healthMult;
        menu.SetActive(false);
    }
}
