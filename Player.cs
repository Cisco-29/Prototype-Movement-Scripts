using System.Collections; using System.Collections.Generic; using UnityEngine;  public class Player : MonoBehaviour
{
    float speed = 5.0f;
    Vector3 location;    // Vector3 is named 'location'
    Transform t;         // Transform is named 't'


    /* 'Transform' is its own datatype.It's a class, which means you can call       * methods with a full stop like Transform.position or  Transform.translate */

    bool leftdir;     bool rightdir;     bool updir;     bool downdir;     bool nodir;      int lastMoveX;     int lastMoveY;
     enum LastKey      {     Up,      Down,      Left,      Right,     None     }      int lk;      int currentmove;   
    void Start()
    {
        t = transform; // Transform = transform = t                  location = transform.position; // transform.position is the .position method being used on the transform/Transform/t class.                  nodir = true;     
    }

    void Update()
    {
        // Last Key System



        if (Input.GetKeyDown(KeyCode.UpArrow))          {             lk = (int)LastKey.Up;

            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.DownArrow)) { lk = 0; }
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.LeftArrow))  { lk = 0; }
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.RightArrow)) { lk = 0; }         }          if (Input.GetKeyDown(KeyCode.DownArrow))         {             lk = (int)LastKey.Down;

            if (Input.GetKeyUp(KeyCode.DownArrow)) { lk = currentmove; }         }
        if (Input.GetKeyDown(KeyCode.LeftArrow))         {             lk = (int)LastKey.Left;

            if (Input.GetKeyUp(KeyCode.LeftArrow)) { lk = currentmove; }         }
        if (Input.GetKeyDown(KeyCode.RightArrow))         {             lk = (int)LastKey.Right;

            if (Input.GetKeyUp(KeyCode.RightArrow)) { lk = currentmove; }
        }

       






        // Input

        if (Input.GetKey(KeyCode.UpArrow) && (t.position == location) && (lk == 0 || lk == 4))         {
           // if ((leftdir == true) || (nodir == true) || (downdir == true) || (rightdir == true))
            {                 location += Vector3.up;                 currentmove = 0;                 updir = true;             }          }          if (Input.GetKey(KeyCode.DownArrow) && (t.position == location) && (lk == 1 || lk == 4))         {
           // if ((leftdir == true) || (updir == true) || (nodir == true) || (rightdir == true))
            {                 location += Vector3.down;                 currentmove = 1;                 downdir = true;             }
        }

        if (Input.GetKey(KeyCode.LeftArrow) && (t.position == location) && (lk == 2 || lk == 4))         {
           // if ((nodir == true) || (updir == true) || (downdir == true) || (rightdir == true))
            {                 location += Vector3.left; // // Vector3.left is shorthand for Vector3(-1,0,0)                 currentmove = 2;                 leftdir = true;             }         }          if (Input.GetKey(KeyCode.RightArrow) && (t.position == location) && (lk == 3 || lk == 4))
        {             // if ((leftdir == true) || (updir == true) || (downdir == true) || (nodir == true))
            {
                location += Vector3.right; // Vector3.right is shorthand for Vector3(1,0,0)                 currentmove = 3;                 rightdir = true;

            }
        } 

        transform.position = Vector3.MoveTowards(transform.position, location, Time.deltaTime * speed);
    }

}

