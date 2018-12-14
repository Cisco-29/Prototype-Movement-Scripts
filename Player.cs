using System.Collections; using System.Collections.Generic; using UnityEngine;  public class Player : Character
{
    float speed = 4.0f;
    Vector3 location;
    Transform tran;
     private bool idle;

    void Start()
    {
        location = transform.position;
        tran = transform;          idle = true;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) && tran.position == location && (idle = true))
        {
            location += Vector3.right;             idle = false;
        }          if (Input.GetKey(KeyCode.LeftArrow) && tran.position == location && (idle = true))
        {
            location += Vector3.left;             idle = false;
        }          if (Input.GetKey(KeyCode.UpArrow) && tran.position == location && (idle = true))
        {
            location += Vector3.up;             idle = false;
        }          if (Input.GetKey(KeyCode.DownArrow) && tran.position == location && (idle = true))
        {
            location += Vector3.down;             idle = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, location, Time.deltaTime * speed);
    }

}

