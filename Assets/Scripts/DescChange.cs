using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using TMPro;

public class DescChange : MonoBehaviour, IPointerEnterHandler
{
    public string _desc;
    public TMP_Text description;

    public void OnPointerEnter(PointerEventData eventData)
    {
        changeMessage();
    }

    private void changeMessage()
    {
        description.text = _desc;
    }
}
