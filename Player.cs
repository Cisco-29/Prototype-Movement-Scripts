using System.Collections; using System.Collections.Generic; using UnityEngine;  public class Player : Character
{
    float speed = 4.0f;
    Vector3 location;    // Vector3 is named 'location'
    Transform t;         // Transform is named 't'      /* 'Transform' is its own datatype.It's a class, which means you can call       * methods with a full stop like Transform.position or  Transform.translate */
     private bool idle;

    void Start()
    {
        t = transform; // Transform = transform = t         location = transform.position; // transform.position is the .position method being used on the transform/Transform/t class.          idle = true;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) && t.position == location && (idle = true))
        {
            location += Vector3.right;             idle = false;
        }          if (Input.GetKey(KeyCode.LeftArrow) && t.position == location && (idle = true))
        {
            location += Vector3.left;             idle = false;
        }          if (Input.GetKey(KeyCode.UpArrow) && t.position == location && (idle = true))
        {
            location += Vector3.up;             idle = false;
        }          if (Input.GetKey(KeyCode.DownArrow) && t.position == location && (idle = true))
        {
            location += Vector3.down;             idle = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, location, Time.deltaTime * speed);
    }

}

