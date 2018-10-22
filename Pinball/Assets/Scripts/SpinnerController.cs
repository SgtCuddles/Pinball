using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerController : MonoBehaviour {

    public GameObject spinner;


    public int speed = 1;

    public int pastSpeed;

    Vector3 eulerAngleVelocity;

    private void Start()
    {
        GlobalStuff.spinSpeed = speed;
        eulerAngleVelocity = new Vector3(0, 100 * speed, 0);
    }

    void FixedUpdate () {

        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);

        //rotates the spinner according to the speed set in GlobalStuff
		if(speed != pastSpeed){
            pastSpeed = speed;
            eulerAngleVelocity = new Vector3(0, 100 * speed);
        }
        spinner.GetComponent<Rigidbody>().MoveRotation(spinner.GetComponent<Rigidbody>().rotation * deltaRotation);
        speed = GlobalStuff.spinSpeed;
	}
}
