using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{

    public bool aKey = false;
    public bool dKey = false;

    bool started = false;

    public GameObject leftFlipper;
    public GameObject rightFlipper;

    Rigidbody rRigidbody;
    Rigidbody lRigidbody;

    public float speedUp = 16;
    public float speedDown = 8;

    public int leftLimitDown = 195;
    public int leftLimitUp = 165;
    public int rightLimitDown = 165;
    public int rightLimitUp = 195;


    Vector3 eulerAngleVelocity;

    float leftY;
    float rightY;


    private void Start()
    {
        eulerAngleVelocity = new Vector3(0, 100 * speedUp, 0);

        rRigidbody = rightFlipper.GetComponent<Rigidbody>();
        lRigidbody = leftFlipper.GetComponent<Rigidbody>();
    }

    private void Update()
    {
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
        if(Input.GetKey("p"))
        {
            started = true;
        }
        leftY = leftFlipper.transform.eulerAngles.y;
        rightY = rightFlipper.transform.eulerAngles.y;
        
    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        Quaternion nDeltaRotation = Quaternion.Euler(-eulerAngleVelocity * Time.deltaTime);

        if (aKey && dKey && started)
        {
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
            if (leftY > leftLimitUp)
            {
                lRigidbody.MoveRotation(lRigidbody.rotation * nDeltaRotation);
            }
            if (rightY > rightLimitDown)
            {
                rRigidbody.MoveRotation(rRigidbody.rotation * nDeltaRotation);
            }
        }
        else if (dKey && started)
        {

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
