using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public float Speed;
    public GameObject impact;
    private int bounce=5; //number of bounces left before the rocket explodes

    // Update is called once per frame
    void Update()
    {
        transform.position=transform.position + transform.forward * Time.deltaTime * Speed;

    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("hello");
        
		if (other.gameObject != gameObject) {
			if (bounce == 0) {
				Debug.Log ("explode");
				Instantiate (impact, other.contacts [0].point, Quaternion.identity);
				gameObject.SetActive (false);
			}	
            else
            {
				Debug.Log("hit " + bounce);
                Vector3 reflected = Vector3.Reflect(transform.forward, other.transform.forward);
                Quaternion reflectedRotation = Quaternion.LookRotation(reflected);
                transform.rotation = reflectedRotation;
				bounce--;
            }
        }
	}
}
