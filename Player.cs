using System.Collections; using System.Collections.Generic; using UnityEngine;  public class Player : Character
{      private bool idle;
    float speed = 4.0f;
    Vector3 location;    // Vector3 is named 'location'
    Transform t;         // Transform is named 't'      /* 'Transform' is its own datatype.It's a class, which means you can call       * methods with a full stop like Transform.position or  Transform.translate */
    

    void Start()
    {
        t = transform; // Transform = transform = t         location = transform.position; // transform.position is the .position method being used on the transform/Transform/t class. 
    }

    void Update()
    {          if (t.position == location)
        {
            switch (Input.inputString)
            {
                case "w":
                case "W":
                location += Vector3.up;
                    idle = false;
                    break;
                case "a":
                case "A":
                    location += Vector3.left;
                    idle = false;
                    break;
                case "s":
                case "S":
                    location += Vector3.down;
                    idle = false;
                    break;
                case "d":
                case "D":
                    location += Vector3.down;
                    idle = false;
                    break;
                default:
                    idle = true;                     break;
            }
        }

      /*  if (Input.GetKey(KeyCode.RightArrow) && t.position == location)
        {
            location += Vector3.right; // Vector3.right is shorthand for Vector3(1,0,0)         
        }          else if (Input.GetKey(KeyCode.LeftArrow) && t.position == location)
        {
            location += Vector3.left; // // Vector3.left is shorthand for Vector3(-1,0,0)

        }          else if (Input.GetKey(KeyCode.UpArrow) && t.position == location)
        {
            location += Vector3.up;         
        }          else if (Input.GetKey(KeyCode.DownArrow) && t.position == location)
        {
            location += Vector3.down;          
        }*/

        transform.position = Vector3.MoveTowards(transform.position, location, Time.deltaTime * speed);
    }

}

