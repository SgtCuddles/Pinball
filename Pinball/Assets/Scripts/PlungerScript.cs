using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerScript : MonoBehaviour {


    public GameObject   plunger;
    Rigidbody           rb;
    double              initPosition;
    double              position;

    public bool         key;
    public string       keyName;
    public int          speed;
    Vector3             velocity;
    Vector3             nVelocity;



    void Start ()
    {
        rb = plunger.GetComponent<Rigidbody>();
        initPosition = rb.position.z;
        velocity = new Vector3(0, 0, speed);
        nVelocity = new Vector3(0, 0, speed/4 * -1);

    }
	
	void Update ()
    {
        if(Input.GetKey(keyName))
        {
            key = true;
        }
        else
        {
            key = false;
        }
        position = rb.position.z;
        
	}

    private void FixedUpdate()
    {
        if(key)
        {
            rb.AddForce(nVelocity);
        }
        else if(initPosition >= position)
        {
            rb.AddForce(velocity);
        }
        else if(initPosition <= position && initPosition != position)
        {
            rb.AddForce(nVelocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "plungerStop")
        {
            rb.velocity = Vector3.zero;
        }
    }
}
