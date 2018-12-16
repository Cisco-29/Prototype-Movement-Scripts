using System.Collections; using System.Collections.Generic; using UnityEngine;  public class Player : MonoBehaviour
{
    float speed = 5.0f;
    Vector3 location;    // Vector3 is named 'location'
    Transform t;         // Transform is named 't'


    /* 'Transform' is its own datatype.It's a class, which means you can call       * methods with a full stop like Transform.position or  Transform.translate */

    bool leftdir;     bool rightdir;     bool updir;     bool downdir;     bool nodir;      int lastMoveX;     int lastMoveY;
     enum LastKey      {     Up,      Down,      Left,      Right,     None     }      int lk;      int currentmove;             private enum MOVE_DIR
    {
        IDLE, UP, RIGHT, DOWN, LEFT
    }

    // Keep track of what direction the player is moving in 
    private MOVE_DIR

    movementState = MOVE_DIR.IDLE;                  //-------------------------------------------------------------------------- 
    void Start()
    {
        t = transform; // Transform = transform = t                  location = transform.position; // transform.position is the .position method being used on the transform/Transform/t class.                  nodir = true;

         movementState = MOVE_DIR.IDLE;

    }


    //--------------------------------------------------------------------------

    void Update()
    {
        // Last Key System

        HandleKeyDown();
        HandleKeyUp();
        Move(movementState);

    }  
    // Logic here to update movementState when a key is PRESSED DOWN
    // The most recent key press should override whatever the current
    // movementState is. 
    private void HandleKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movementState = MOVE_DIR.UP;
        } 
        if (Input.GetKeyDown(KeyCode.DownArrow))         {             movementState = MOVE_DIR.DOWN;         } 
        if (Input.GetKeyDown(KeyCode.LeftArrow))         {             movementState = MOVE_DIR.LEFT;         } 
        if (Input.GetKeyDown(KeyCode.RightArrow))         {             movementState = MOVE_DIR.RIGHT;         }
    }  
    // Logic here to update movementState whenever a key is RELEASED
    // Here, we should set the movementState to IDLE if AND ONLY IF the key
    // released matches the direction the player is currently moving in.
     private void HandleKeyUp()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) && movementState == MOVE_DIR.UP)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                movementState = MOVE_DIR.DOWN;
            }                     if (Input.GetKey(KeyCode.LeftArrow))             {                 movementState = MOVE_DIR.LEFT;             }
             if (Input.GetKey(KeyCode.RightArrow))             {                 movementState = MOVE_DIR.RIGHT;             }

            if (Input.GetKey(KeyCode.None))             {                 movementState = MOVE_DIR.IDLE;             }         }       
        if (Input.GetKeyUp(KeyCode.DownArrow) && movementState == MOVE_DIR.DOWN)         {
            if (Input.GetKey(KeyCode.UpArrow))             {                 movementState = MOVE_DIR.UP;             }

            if (Input.GetKey(KeyCode.LeftArrow))             {                 movementState = MOVE_DIR.LEFT;             }              if (Input.GetKey(KeyCode.RightArrow))             {                 movementState = MOVE_DIR.RIGHT;             }              if (Input.GetKey(KeyCode.None))             {                 movementState = MOVE_DIR.IDLE;             }         }    
        if (Input.GetKeyUp(KeyCode.LeftArrow) && movementState == MOVE_DIR.LEFT)         {             if (Input.GetKey(KeyCode.UpArrow))             {                 movementState = MOVE_DIR.UP;             }              if (Input.GetKey(KeyCode.DownArrow))             {                 movementState = MOVE_DIR.DOWN;             }              if (Input.GetKey(KeyCode.RightArrow))             {                 movementState = MOVE_DIR.RIGHT;             }              if (Input.GetKey(KeyCode.None))             {                 movementState = MOVE_DIR.IDLE;             }

        } 
        if (Input.GetKeyUp(KeyCode.RightArrow) && movementState == MOVE_DIR.RIGHT)         {
            if (Input.GetKey(KeyCode.UpArrow))             {                 movementState = MOVE_DIR.UP;             }              if (Input.GetKey(KeyCode.DownArrow))             {                 movementState = MOVE_DIR.DOWN;             }              if (Input.GetKey(KeyCode.LeftArrow))             {                 movementState = MOVE_DIR.LEFT;             }              if (Input.GetKey(KeyCode.None))             {                 movementState = MOVE_DIR.IDLE;             }         }
    }







    // This function takes a direction and handles Transforming the player
    // object in the appropriate direction

  private void Move(MOVE_DIR direction)
       {             switch (direction)
            {              case MOVE_DIR.IDLE: 
                break;               case MOVE_DIR.UP:                 if (Input.GetKey(KeyCode.UpArrow) && (t.position == location))                               {                     location += Vector3.up;                 }                 break;
              case MOVE_DIR.DOWN:                 if (Input.GetKey(KeyCode.DownArrow) && (t.position == location))                 
                {
                    location += Vector3.down;
                }
                break;


            case MOVE_DIR.LEFT:
                if (Input.GetKey(KeyCode.LeftArrow) && (t.position == location))
                                  {                     location += Vector3.left;                 }
                break;  
            case MOVE_DIR.RIGHT:
                if (Input.GetKey(KeyCode.RightArrow) && (t.position == location))                                  {                     location += Vector3.right;                 }
                break;
               
              
           }

                transform.position = Vector3.MoveTowards(transform.position, location, Time.deltaTime * speed);
        }  







    /*        *              * System One, Buggy        *               * if (Input.GetKeyDown(KeyCode.UpArrow))          {             lk = (int)LastKey.Up;

          if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.DownArrow)) { lk = 0; }
          if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.LeftArrow))  { lk = 0; }
          if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.RightArrow)) { lk = 0; }         }          if (Input.GetKeyDown(KeyCode.DownArrow))         {             lk = (int)LastKey.Down;

          if (Input.GetKeyUp(KeyCode.DownArrow)) { lk = currentmove; }         }
      if (Input.GetKeyDown(KeyCode.LeftArrow))         {             lk = (int)LastKey.Left;

          if (Input.GetKeyUp(KeyCode.LeftArrow)) { lk = currentmove; }         }
      if (Input.GetKeyDown(KeyCode.RightArrow))         {             lk = (int)LastKey.Right;

          if (Input.GetKeyUp(KeyCode.RightArrow)) { lk = currentmove; }
      }

     */






    // Input

 /*
    { 

        if (Input.GetKey(KeyCode.UpArrow) && (t.position == location) && (movementState == MOVE_DIR.UP))         {
           // if ((leftdir == true) || (nodir == true) || (downdir == true) || (rightdir == true))
            {                 location += Vector3.up;                 currentmove = 0;                 updir = true;             }          }          if (Input.GetKey(KeyCode.DownArrow) && (t.position == location) && (movementState == MOVE_DIR.DOWN))         {
           // if ((leftdir == true) || (updir == true) || (nodir == true) || (rightdir == true))
            {                 location += Vector3.down;                 currentmove = 1;                 downdir = true;             }
        }

        if (Input.GetKey(KeyCode.LeftArrow) && (t.position == location) && (movementState == MOVE_DIR.LEFT))         {
           // if ((nodir == true) || (updir == true) || (downdir == true) || (rightdir == true))
            {                 location += Vector3.left; // // Vector3.left is shorthand for Vector3(-1,0,0)                 currentmove = 2;                 leftdir = true;             }         }          if (Input.GetKey(KeyCode.RightArrow) && (t.position == location) && (movementState == MOVE_DIR.RIGHT))
        {             // if ((leftdir == true) || (updir == true) || (downdir == true) || (nodir == true))
            {
                location += Vector3.right; // Vector3.right is shorthand for Vector3(1,0,0)                 currentmove = 3;                 rightdir = true;

            }
        } 

        transform.position = Vector3.MoveTowards(transform.position, location, Time.deltaTime * speed);
    }
    */
}

