using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScript : MonoBehaviour
{
    Vector3 pos;
    Vector3 offset;
   public float minX;
   public float maxX;
   public float minY;
   public float maxY;
    public GameObject[] spawnObject;
    public GameObject[] spawnParemeter;
    //public int tempCheckForBounds = 0;
    // Start is called before the first frame update
    void Start()
    {
        //maxX = _terrain.transform.position.x + _terrain.transform.localScale.x / 2;
        //minX = _terrain.transform.position.x - _terrain.transform.localScale.x / 2;
        //maxY = _terrain.transform.position.y + _terrain.transform.localScale.y / 2;
        //minY = _terrain.transform.position.y - _terrain.transform.localScale.y / 2;


        //offset = transform.up * (transform.localScale.y / 2f) * -1f;
        //pos = transform.position + offset; //This is the position
        //pos = new Vector3(Random.Range(minY, maxY), Random.Range(minX, maxX), 0f);
    }
    // Update is called once per frame
    void Update()
    {
        //pos = new Vector3(Random.Range(minY, maxY), Random.Range(minX, maxX), 0f);

        //CheckIfSpawnPointIsInBounds(pos);

       //Instantiate(spawnObject, pos, Quaternion.identity);
        //transform.position = transform.position + transform.right * -transform.localScale / 2;
    }
}
