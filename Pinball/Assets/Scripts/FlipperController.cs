using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{

    public bool aKey = false;
    public bool dKey = false;

    bool started = GlobalStuff.start;

    public GameObject leftFlipper;
    public GameObject rightFlipper;

    Rigidbody rRigidbody;
    Rigidbody lRigidbody;

    public int speed = 16;

    public int leftLimitDown = 195;
    public int leftLimitUp = 165;
    public int rightLimitDown = 165;
    public int rightLimitUp = 195;


    Vector3 eulerAngleVelocity;

    float leftY;
    float rightY;


    private void Start()
    {

        //this allows me to adjust the speed at which the flippers rotate
        eulerAngleVelocity = new Vector3(0, 100 * speed, 0);

        rRigidbody = rightFlipper.GetComponent<Rigidbody>();
        lRigidbody = leftFlipper.GetComponent<Rigidbody>();
    }

    private void Update()
    {

        //this is where\how my code assigns appropriate boolean values to the buttons on the keyboard
        if (Input.GetKey("a"))
        {
            aKey = true;
        }
        else
        {
            aKey = false;
        }

        if (Input.GetKey("d"))
        {
            dKey = true;
        }
        else
        {
            dKey = false;
        }

        //this was put in because of an error that would occur upon starting the game
        //where the right flipper would go below its rotational limit and freak the game out
        if(Input.GetKey("p") && !started)
        {
            GlobalStuff.start = true;
            started = true;

        }

        //this sets the variables to the current rotation of their respective flippers
        //allowing me to use them as references for my if else logic later
        leftY = leftFlipper.transform.eulerAngles.y;
        rightY = rightFlipper.transform.eulerAngles.y;
        
    }

    void FixedUpdate()
    {

        //Quaternions still baffle me, however these allow me to rotate the collider of my flippers
        //rather than their mesh which gives better hit detection
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        Quaternion nDeltaRotation = Quaternion.Euler(-eulerAngleVelocity * Time.deltaTime);

        if (aKey && dKey && started)
        {
            //both flippers up
            if (leftY > leftLimitUp)
            {
                lRigidbody.MoveRotation(lRigidbody.rotation * nDeltaRotation);
            }
            if (rightY < rightLimitUp)
            {
                rRigidbody.MoveRotation(rRigidbody.rotation * deltaRotation);
            }
        }
        else if (aKey && started)
        {
            //left flipper up, right flipper down
            if (leftY > leftLimitUp)
            {
                lRigidbody.MoveRotation(lRigidbody.rotation * nDeltaRotation);
            }
            if (rightY > rightLimitDown)
            {
                rRigidbody.MoveRotation(rRigidbody.rotation * nDeltaRotation);
            }
            GlobalStuff.spinSpeed += 1;
            Debug.Log(GlobalStuff.spinSpeed);
        }
        else if (dKey && started)
        {
            //right flipper up, left flipper down
            if (rightY < rightLimitUp)
            {
                rRigidbody.MoveRotation(rRigidbody.rotation * deltaRotation);
            }
            if (leftY < leftLimitDown)
            {
                lRigidbody.MoveRotation(lRigidbody.rotation * deltaRotation);
            }
        }
        else if(started)
        {
            //both flippers down
            if (rightY > rightLimitDown)
            {
                rRigidbody.MoveRotation(rRigidbody.rotation * nDeltaRotation);
            }
            if (leftY < leftLimitDown)
            {
                lRigidbody.MoveRotation(lRigidbody.rotation * deltaRotation);
            }
        }
    }
}
