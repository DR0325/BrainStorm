//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CameraFunctionality : MonoBehaviour
{
    [SerializeField] public static CameraFunctionality CameraFunctionalityInstance;

    public Transform target;
    public Transform target2;
    public GameObject player;

    public bool cameraLocked = false;
    public float speed = 0.125f;
    public Vector3 offset;
    public float transitionSpeed; //speed at which the camera transitions between targets.
    //public int timer;
    //public int timerTracker;
    Vector3 desiredPosition;
    Vector3 smoothedPosition;
    //[SerializeField] Transform destinationPosition;

    Vector2 startingPosition;
   // Vector2 destinationPos;



    // Start is called before the first frame update
    void Start()
    {

        //target =;
        //target2 =;
         player = GameManager.Instance.player;
        target = player.transform;
        //timerTracker = timer;

    }

    public void LockCamera(Transform lockPosition)
    {
        target = lockPosition;
        cameraLocked = true;
    }
    public void UnlockCamera()
    {
        target = player.transform;
        cameraLocked = false;
    }
    void LateUpdate()
    {

        if (!cameraLocked)
        {
            desiredPosition = target.position + offset;
            smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        else if(cameraLocked && Vector3.Distance(transform.position, target.position) >= 0.001f)
        {
            desiredPosition = target.position + offset;
            smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, transitionSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
    // Update is called once per frame
    void Update()
    {

        //if(timerTracker <= 0)
        //{
        //    if(cameraLocked)
        //    {
        //        UnlockCamera();
        //    }
        //    else if(!cameraLocked)
        //    {
        //        LockCamera(target2);
        //    }
        //    timerTracker = timer;
        //}
        //timerTracker--;

    }
}
