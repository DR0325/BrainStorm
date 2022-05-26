using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform targetPos;
    private Vector3 originalPos;
    public float maxDist;

    private void Start()
    {
        originalPos = transform.position;
    }

    private void Update()
    {
       
    }

    public void MoveDoors()
    {
        Vector3 a = transform.position;
        Vector3 b = new Vector3(transform.position.x ,targetPos.position.y);
        transform.position = Vector3.MoveTowards(a, b, maxDist);
    }

    public void OpenDoors()
    {
        transform.position = originalPos;
    }
}
