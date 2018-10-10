using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rocketbox.Character;

[RequireComponent(typeof(PlayerInputHandler))]
public class grapple2 : MonoBehaviour
{
	private RigidbodyFirstPersonController rbfc;
    public Transform cam;
    private RaycastHit hit;
    private Rigidbody rb;
    private bool attached = false;
    private bool firstClick = true;
    private float momentum;
    private AirMove airMoveScript;
    public float speed;
    private float step;
    public Transform rocketSpawn;
	private PlayerInputHandler input;
    private LineRenderer line;
    void Start()
    {
        //AirMove airMoveScript = rb.GetComponent<AirMove>();
        rbfc = GetComponent<RigidbodyFirstPersonController>();
        rb = GetComponent<Rigidbody>();
		input = GetComponent<PlayerInputHandler>();
        line = gameObject.AddComponent<LineRenderer>();

    }

    void FixedUpdate()
    {
        if (momentum > 20)
            momentum = 20;
        Ray ray = new Ray(cam.position, cam.forward);
        if (input.GetButtonDown("Grapple"))
        {
            line.positionCount = 2;
                line.SetPosition(0, rocketSpawn.transform.position);
                line.SetPosition(1, rocketSpawn.transform.position + rocketSpawn.transform.forward * 10);
                momentum = 0;
            line.SetPosition(0, rocketSpawn.transform.position);
            Debug.Log(rocketSpawn.transform.position);
            if (Physics.Raycast(ray, out hit,15))
            {
                
                attached = true;
                rb.useGravity = false;
                //airMoveScript.enabled = false;
                //rb.isKinematic = true;

            }
        }

        if(input.GetButton("Grapple"))
        {
            line.SetPosition(0, rocketSpawn.transform.position);
        }
		if (input.GetButtonUp("Grapple"))
        {
            line.positionCount = 0;
            // airMoveScript.enabled = true;
            firstClick = true;
            attached = false;
            rb.useGravity = true;
            rb.velocity = cam.forward * momentum;

        }
        if (attached)
        {
            
            momentum += Time.deltaTime * speed;
            step = momentum * Time.deltaTime;
            rb.MovePosition(Vector3.MoveTowards(transform.position, hit.point, step));
        }
        if (!attached && momentum >= 0)
        {
            momentum -= Time.deltaTime * 6;
            step = 0;

        }
        if(!attached && rbfc.Grounded)
        {
            momentum = 0;
            rb.useGravity = true;
        }
        //Debug.Log(momentum);
    }
}
