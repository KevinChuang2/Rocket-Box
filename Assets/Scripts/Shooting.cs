using UnityEngine;
using System.Collections;

//This script is to control the timing of rockets fired
[RequireComponent(typeof(PlayerInputHandler))]
public class Shooting : MonoBehaviour {

    public float fireRate = .5F;
    private float nextFire = 0.0F;

	private PlayerInputHandler m_input;
	// Use this for initialization
	void Start () {
		m_input = GetComponent<PlayerInputHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_input.GetButton("Shoot") && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            gameObject.GetComponent<Firing>().fire();
        }
	}
}
