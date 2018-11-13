using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public bool     key             = false;
    public string   keyName;
    public int      speed           = 16;
    public int      releaseSpeed    = 10;
    public int      up              = 195;
    public int      down            = 165;
    float           y;

    public GameObject flipper;

    Rigidbody rb;
    Vector3 eulerAngleVelocity;


    private void Start()
    {

        //this allows me to adjust the speed at which the flippers rotate
        eulerAngleVelocity = new Vector3(0, 10 * speed, 0);

        rb = flipper.GetComponent<Rigidbody>();
    }

    private void Update()
    {

        //this is where\how my code assigns appropriate boolean values to the buttons on the keyboard
        if (Input.GetKey(keyName))
        {
            key = true;
        }
        else
        {
            key = false;
        }

        //this sets the variables to the current rotation of their respective flippers
        //allowing me to use them as references for my if else logic later
        y = flipper.transform.eulerAngles.y;

    }

    void FixedUpdate()
    {

        //Quaternions still baffle me, however these allow me to rotate the collider of my flippers
        //rather than their mesh which gives better hit detection
        Quaternion deltaRotation    = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        Quaternion nDeltaRotation   = Quaternion.Euler(-eulerAngleVelocity * Time.deltaTime);

        if (key)
        {
            if (y < up)
            {
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
        }
        else
        {
            if (y > down)
            {
                rb.MoveRotation(rb.rotation * nDeltaRotation);
            }
        }
        

    }
}

