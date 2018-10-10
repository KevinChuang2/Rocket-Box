using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikey : MonoBehaviour {

    //public int damage = 20;
    public int spring_val = 100; //how much the character jumps back when bumped into the spikey totem

	// Use this for initialization
	void Start () {
        
	}
	

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject != gameObject)
        {
            if (other.gameObject.CompareTag(Tags.Player))
            {
                Debug.Log("spikey hit");
                other.gameObject.GetComponent<Character>().TakeDamage();
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                //character's normal vector is facing into the pole, so multiplying by -1 pushes character away from the pole
                rb.AddForce(other.contacts[0].normal * spring_val * -1, ForceMode.Impulse);
            }
        }
    }
}
