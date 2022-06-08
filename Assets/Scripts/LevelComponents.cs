using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LevelComponents : MonoBehaviour
{
    public bool doesPlatformMove;
    public bool doesPlatformDisappear;
    public bool returnDirection;
    //public float speed;
    [Range(0, 360)]
    public int direction_360;
    [Range(0, 360)]
    public int direction2_360;//direction 2 is the direction the block goes next, then back direciton one, then 2, 1, ect. 
    public bool showMovePath;
    public int timeLengthMove;
    private int timeLengthTracker;
    private float moveX, moveY;
    private float result, radians;
    public float pauseBetweenDirectionSwitch;
    private float nextMoveTime;
    private Vector3 totalMove, currentPosition;
    private int directionAngleQuadrant;//variable may not be needed.
    private bool direction1Or2 = false;
    public Rigidbody2D rb;
    private Vector3 drawSize = new Vector3(1,1,1);
    //code from class
    [SerializeField] Transform destinationPosition;
    [SerializeField] int speed;

  Vector2 startingPosition;
   Vector2 target;
    Vector2 destinationPos;



    

            void Start()
    {
        if (doesPlatformMove)
        {

            target = destinationPosition.position;
        }
        destinationPos = target;
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        //currentPosition = transform.position; //Setting CurrentPosition to adjust and track.
        //timeLengthTracker = timeLengthMove; //setting a tracker to count down the move time.
       // nextMoveTime = pauseBetweenDirectionSwitch;
       // ChangeTotalMove();
    }

    void MovePlatform()
    {


    }

//    void ChangeTotalMove()
//    {
//            if(direction1Or2 == false)//false is direction2
//            {
                      
//                if (direction2_360 > 0 && direction2_360< 90)
//                {
//                    radians = (float) (direction2_360* Math.PI / 180);
//                    result = (float) Math.Tan(radians);
//                    directionAngleQuadrant = 1;
//                    moveX = 1 / (result + 1);
//                    moveY = result / (result + 1);
//                }
//                else if (direction2_360 > 90 && direction2_360 < 180)
//                {
//                 radians = (float)((180 - direction2_360) * Math.PI / 180);
//                 result = (float)Math.Tan(radians);
//                 directionAngleQuadrant = 2;
//                 moveX = -1 * (1 / (result + 1));
//                 moveY = result / (result + 1);
//                }
//                else if (direction2_360 > 180 && direction2_360 < 270)
//                {
//                radians = (float)((direction2_360 - 180) * Math.PI / 180);
//                result = (float)Math.Tan(radians);
//                directionAngleQuadrant = 3;
//                moveX = -1 * (1 / (result + 1));
//                 moveY = -1 * (result / (result + 1));
//                }
//                else if (direction2_360 > 270 && direction2_360 < 360)
//{
//    directionAngleQuadrant = 4;
//    radians = (float)((360 - direction2_360) * Math.PI / 180);
//    result = (float)Math.Tan(radians);
//    moveX = 1 / (result + 1);
//    moveY = -1 * (result / (result + 1));
//}
//                else if (direction2_360 == 90)
//{
//    directionAngleQuadrant = 5; //Moving Directly Up on the Y Axis ("Quadrant" 5)
//    moveX = 0;
//    moveY = 1;
//}
//                else if (direction2_360 == 180)
//{
//    directionAngleQuadrant = 6; //Moving directly Left on the X Axis ("Quadrant" 6)
//    moveX = -1;
//    moveY = 0;
//}
//                else if (direction2_360 == 270)
//{
//    directionAngleQuadrant = 7; // Moving Directly Down on the Y Axis ("Quadrant" 7)
//    moveX = 0;
//    moveY = 1;
//}
//                else if (direction2_360 == 360 || direction2_360 == 0)
//{
//    directionAngleQuadrant = 8; //Moving directly Right on the X Axis("Quadrant" 8)
//    moveX = 1;
//    moveY = 0;
//}

//                totalMove = new Vector3(moveX, moveY, 0f);
//                direction1Or2 = true; 
//            }

//            else if ( direction1Or2 == true)
//            {
//                if (direction_360 > 0 && direction_360 < 90)
//            {
//                radians = (float)(direction_360 * Math.PI / 180);
//                result = (float)Math.Tan(radians);
//                directionAngleQuadrant = 1;
//                moveX = 1 / (result + 1);
//                moveY = result / (result + 1);
//            }
//                else if (direction_360 > 90 && direction_360 < 180)
//            {
//                radians = (float)((180 - direction_360) * Math.PI / 180);
//                result = (float)Math.Tan(radians);
//                directionAngleQuadrant = 2;
//                moveX = -1 * (1 / (result + 1));
//                moveY = result / (result + 1);
//            }
//                else if (direction_360 > 180 && direction_360 < 270)
//            {
//                radians = (float)((direction_360 - 180) * Math.PI / 180);
//                result = (float)Math.Tan(radians);
//                directionAngleQuadrant = 3;
//                moveX = -1 * (1 / (result + 1));
//                moveY = -1 * (result / (result + 1));
//            }
//                else if (direction_360 > 270 && direction_360 < 360)
//            {
//                directionAngleQuadrant = 4;
//                radians = (float)((360 - direction_360) * Math.PI / 180);
//                result = (float)Math.Tan(radians);

//                moveX = 1 / (result + 1);
//                moveY = -1 * (result / (result + 1));
//            }
//                else if (direction_360 == 90)
//            {
//                directionAngleQuadrant = 5; //Moving Directly Up on the Y Axis ("Quadrant" 5)
//                moveX = 0;
//                moveY = 1;
//            }
//                else if (direction_360 == 180)
//            {
//                directionAngleQuadrant = 6; //Moving directly Left on the X Axis ("Quadrant" 6)
//                moveX = -1;
//                moveY = 0;
//            }
//                else if (direction_360 == 270)
//            {
//                directionAngleQuadrant = 7; // Moving Directly Down on the Y Axis ("Quadrant" 7)
//                moveX = 0;
//                moveY = 1;
//            }
//                else if (direction_360 == 360 || direction_360 == 0)
//            {
//                directionAngleQuadrant = 8; //Moving directly Right on the X Axis("Quadrant" 8)
//                moveX = 1;
//                moveY = 0;
//            }
//                totalMove = new Vector3(moveX, moveY, 0f);
//                direction1Or2 = false;
//            }
            
//     }//sets direction.
    // Update is called once per frame

    //void FixedUpdate()
    //{
    //    currentPosition = transform.position;
    //    if (doesPlatformMove == true)
    //    {
    //        if (timeLengthTracker > 0)
    //        {
                
    //            rb.velocity = totalMove * speed;
    //            timeLengthTracker--;
    //        }
    //        else if (nextMoveTime < Time.deltaTime)
    //        {
    //            Vector3 vel = rb.velocity;
    //            rb.velocity = vel.normalized * 0f;
    //            nextMoveTime = Time.deltaTime + pauseBetweenDirectionSwitch;
    //        }
    //        else if (timeLengthTracker <= 0 && returnDirection == true)
    //        {

    //            Vector3 vel = rb.velocity;
    //            rb.velocity = vel.normalized * 0f;
    //            ChangeTotalMove();
    //            timeLengthTracker = timeLengthMove;
    //        }
    //    }
    //}






    //Shows draws out for direction.

    private void Update()
    {

        if(Vector2.Distance(transform.position, target) <= 0.01f )
        {
            if (returnDirection)
            {
                if (target == destinationPos && nextMoveTime <= 0)
                {
                    target = startingPosition;
                    nextMoveTime = pauseBetweenDirectionSwitch;
                }
                else if (target == startingPosition && nextMoveTime <= 0)
                {
                    target = destinationPos;
                    nextMoveTime = pauseBetweenDirectionSwitch;
                }
                nextMoveTime = nextMoveTime - Time.deltaTime;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }

    //void OnDrawGizmosSelected()
    //{
    //    if (draw)
    //    {
    //        Gizmos.color = Color.red;
    //        for (int i = 0; i < spawnPoints.Length; i++)
    //        {
    //            Gizmos.DrawCube(spawnPoints[i].transform.position, drawSize);
    //        }
    //    }
    //}
    private void OnDrawGizmosSelected()
    {
        if (showMovePath == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(destinationPosition.position, drawSize);
            //Gizmos.DrawLine(this.transform.position, totalMove * 3);
        }
    //    Gizmos.DrawWireSphere();
    }
}
