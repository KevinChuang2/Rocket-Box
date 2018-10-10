using UnityEngine;
using System.Collections;
using UnityEngine;
using Rocketbox.Character;
//This script creates a rocket instance
public class Firing : MonoBehaviour {
    public Transform offset;
    public GameObject rocketFired;
    public float cooldownTime;
    private RigidbodyFirstPersonController rbfc;
    private Rigidbody rb;
    public Camera cam;
    void Awake()
    {
        rbfc = gameObject.GetComponent<RigidbodyFirstPersonController>();
        rb = gameObject.GetComponent<Rigidbody>();
        
    }
    public void fire()
    {

        if (!rbfc.Grounded)
        {
            rb.AddForce(-1 * cam.transform.forward * 5000);
        }
        Instantiate(rocketFired, offset.position, offset.rotation);
    }
}
