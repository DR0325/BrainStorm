using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LevelComponents : MonoBehaviour
{
    public bool doesPlatformMove;
    public bool doesPlatformDisappear;
    public bool returnDirection;
    public float speed;
    public int direction_360;
    public int direction2_360;//direction 2 is the direction the block goes next, then back direciton one, then 2, 1, ect. 
    public int timeLengthMove;
    private int timeLengthTracker;
    private float moveX, moveY;
    private float result, radians;
    private Vector3 totalMove, currentPosition;
    private int directionAngleQuadrant;//variable may not be needed.
    private bool direction1Or2 = false;


    void Start()
    {
        currentPosition = transform.position; //Setting CurrentPosition to adjust and track.
        timeLengthTracker = timeLengthMove; //setting a tracker to count down the move time.
        ChangeTotalMove();
    }

    void ChangeTotalMove()
    {
            if(direction1Or2 == false)
            {
                
        
                if (direction2_360 > 0 && direction2_360< 90)
                {
                    radians = (float) (direction2_360* Math.PI / 180);
                    result = (float) Math.Tan(radians);
                    directionAngleQuadrant = 1;
                    moveX = 1 / (result + 1);
                    moveY = result / (result + 1);
                }
                else if (direction2_360 > 90 && direction2_360 < 180)
                {
                 radians = (float)((180 - direction2_360) * Math.PI / 180);
                 result = (float)Math.Tan(radians);
                 directionAngleQuadrant = 2;
                 moveX = -1 * (1 / (result + 1));
                 moveY = result / (result + 1);
                }
                else if (direction2_360 > 180 && direction2_360 < 270)
                {
                radians = (float)((direction2_360 - 180) * Math.PI / 180);
                result = (float)Math.Tan(radians);
                directionAngleQuadrant = 3;
                moveX = -1 * (1 / (result + 1));
                 moveY = -1 * (result / (result + 1));
                }
                else if (direction2_360 > 270 && direction2_360 < 360)
{
    directionAngleQuadrant = 4;
    radians = (float)((360 - direction2_360) * Math.PI / 180);
    result = (float)Math.Tan(radians);
    moveX = 1 / (result + 1);
    moveY = -1 * (result / (result + 1));
}
                else if (direction2_360 == 90)
{
    directionAngleQuadrant = 5; //Moving Directly Up on the Y Axis ("Quadrant" 5)
    moveX = 0;
    moveY = 1;
}
                else if (direction2_360 == 180)
{
    directionAngleQuadrant = 6; //Moving directly Left on the X Axis ("Quadrant" 6)
    moveX = -1;
    moveY = 0;
}
                else if (directionAngleQuadrant == 270)
{
    directionAngleQuadrant = 7; // Moving Directly Down on the Y Axis ("Quadrant" 7)
    moveX = 0;
    moveY = 1;
}
                else if (direction2_360 == 360 || direction2_360 == 0)
{
    directionAngleQuadrant = 8; //Moving directly Right on the X Axis("Quadrant" 8)
    moveX = 1;
    moveY = 0;
}

            totalMove = new Vector3(moveX, moveY, 0f);
            direction1Or2 = true; 
            }

            else if ( direction1Or2 == true)
{
                if (direction_360 > 0 && direction_360 < 90)
            {
                radians = (float)(direction_360 * Math.PI / 180);
                result = (float)Math.Tan(radians);
                directionAngleQuadrant = 1;
                moveX = 1 / (result + 1);
                moveY = result / (result + 1);
            }
                else if (direction_360 > 90 && direction_360 < 180)
            {
                radians = (float)((180 - direction_360) * Math.PI / 180);
                result = (float)Math.Tan(radians);
                directionAngleQuadrant = 2;
                moveX = -1 * (1 / (result + 1));
                moveY = result / (result + 1);
            }
                else if (direction_360 > 180 && direction_360 < 270)
            {
                radians = (float)((direction_360 - 180) * Math.PI / 180);
                result = (float)Math.Tan(radians);
                directionAngleQuadrant = 3;
                moveX = -1 * (1 / (result + 1));
                moveY = -1 * (result / (result + 1));
            }
                else if (direction_360 > 270 && direction_360 < 360)
            {
                directionAngleQuadrant = 4;
                radians = (float)((360 - direction_360) * Math.PI / 180);
                result = (float)Math.Tan(radians);

                moveX = 1 / (result + 1);
                moveY = -1 * (result / (result + 1));
            }
                else if (direction_360 == 90)
            {
                directionAngleQuadrant = 5; //Moving Directly Up on the Y Axis ("Quadrant" 5)
                moveX = 0;
                moveY = 1;
            }
                else if (direction_360 == 180)
            {
                directionAngleQuadrant = 6; //Moving directly Left on the X Axis ("Quadrant" 6)
                moveX = -1;
                moveY = 0;
            }
                else if (directionAngleQuadrant == 270)
            {
                directionAngleQuadrant = 7; // Moving Directly Down on the Y Axis ("Quadrant" 7)
                moveX = 0;
                moveY = 1;
            }
                else if (direction_360 == 360 || direction_360 == 0)
            {
                directionAngleQuadrant = 8; //Moving directly Right on the X Axis("Quadrant" 8)
                moveX = 1;
                moveY = 0;
            }
            totalMove = new Vector3(moveX, moveY, 0f);
            direction1Or2 = false;
}
            
     }
    // Update is called once per frame
    void Update()
    {
        if (doesPlatformMove == true)
        {
            if (timeLengthTracker > 0)
            {
                currentPosition += totalMove;
                transform.Translate(currentPosition * speed * Time.deltaTime);
                timeLengthTracker--;
            }
            else if (timeLengthTracker <= 0 && returnDirection == true)
            {
                ChangeTotalMove();
                timeLengthTracker = timeLengthMove;
            }
        }
    }


    //Shows draws out for direction.
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = ConsoleColor.Green;
    //    Gizmos.DrawWireSphere();
    //}
}
