using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{

    public bool aKey = false;
    public bool dKey = false;
    public GameObject leftFlipper;
    public GameObject rightFlipper;
    public float speedUp = 16;
    public float speedDown = -8;
    public int leftLimitDown = 195;
    public int leftLimitUp = 165;
    public int rightLimitDown = 165;
    public int rightLimitUp = 195;
    float leftY;
    float rightY;


    private void Start()
    {
        
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
        leftY = leftFlipper.transform.eulerAngles.y;
        rightY = rightFlipper.transform.eulerAngles.y;
    }

    void FixedUpdate()
    {

        if (aKey && dKey)
        {
            if (leftY > leftLimitUp)
            {
                leftFlipper.transform.Rotate(0, -speedUp, 0 * Time.deltaTime);
            }
            if (rightY < rightLimitUp)
            {
                rightFlipper.transform.Rotate(0, speedUp, 0 * Time.deltaTime);
            }
        }
        else if (aKey)
        {
            if (leftY > leftLimitUp)
            {
                leftFlipper.transform.Rotate(0, -speedUp, 0 * Time.deltaTime);
            }
            if (rightY > rightLimitDown)
            {
                rightFlipper.transform.Rotate(0, speedDown, 0 * Time.deltaTime);
            }
        }
        else if (dKey)
        {

            if (rightY < rightLimitUp)
            {
                rightFlipper.transform.Rotate(0, speedUp, 0 * Time.deltaTime);
            }
            if (leftY < leftLimitDown)
            {
                leftFlipper.transform.Rotate(0, -speedDown, 0 * Time.deltaTime);
            }
        }
        else
        {
            if (rightY > rightLimitDown)
            {
                rightFlipper.transform.Rotate(0, speedDown, 0 * Time.deltaTime);
            }
            if (leftY < leftLimitDown)
            {
                leftFlipper.transform.Rotate(0, -speedDown, 0 * Time.deltaTime);
            }
        }
    }
}
