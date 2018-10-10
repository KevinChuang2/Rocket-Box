using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rocketbox.Character;

//todo: cancel all momentum when you switch directions.

public class AirMove : MonoBehaviour {

    private RigidbodyFirstPersonController rbfc;
    private Rigidbody rb;
    public float thrust = 50f;

	private PlayerInputHandler input;
	// Use this for initialization
	void Start () {
        rbfc = GetComponent<RigidbodyFirstPersonController>();
        rb = GetComponent<Rigidbody>();
		input = GetComponent<PlayerInputHandler>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!rbfc.Grounded)
        {
           if(input.GetAxis("Horizontal")>0)
            {
                rb.AddForce(rb.transform.right * thrust);
            }
           if(input.GetAxis("Horizontal")<0)
            {
                
                rb.AddForce(-1*rb.transform.right * thrust);
            }
           if(input.GetAxis("Vertical")>0)
            {
                rb.AddForce(rb.transform.forward * thrust);
            }
           if(input.GetAxis("Vertical")<0)
            {
                rb.AddForce(-1 * rb.transform.forward * thrust);
            }
        }
	}
}
