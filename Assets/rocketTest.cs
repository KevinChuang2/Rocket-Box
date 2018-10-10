using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class rocketTest: MonoBehaviour
{
    public float Speed;
	public Transform rocketModel;
    public GameObject impact;
    private int bounce = 5;

	private Vector3 currentVelocity;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * Speed;
	}

    // Update is called once per frame
//    void Update()
//    {
//        // transform.position = transform.position + transform.forward * Time.deltaTime * Speed;
//		// rb.MovePosition(transform.position + transform.forward * Time.deltaTime * Speed);
//    }

	void FixedUpdate() {
		currentVelocity = rb.velocity;
	}

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject != gameObject)
        {
            if (bounce == 0)
            {
				if(impact != null) {

                	Instantiate(impact, other.contacts[0].point, Quaternion.identity);
                }
                // gameObject.SetActive(false);
				// Might want to change this to delete so the scene isn't full of inactive gameobjects
				Destroy(gameObject);
            }
            else if(other.gameObject.tag=="Player")
            {
                if (impact != null)
                {

                    Instantiate(impact, other.contacts[0].point, Quaternion.identity);
                }
                Destroy(gameObject);
            }
            else
            {

				// If the rocket gets stuck in a corner then destroy it
                /*
				if(other.contacts.Length > 1) {
					Debug.Log("Hit " + other.contacts.Length + " objects at the same time. Destroying rocket.");
					Destroy(gameObject);
				}
                */

                // Vector3 reflected = Vector3.Reflect(transform.forward, other.transform.forward);
				Vector3 reflected = Vector3.Reflect(currentVelocity, other.contacts[0].normal);
				rb.velocity = reflected;

				rocketModel.LookAt(transform.position + reflected.normalized);

//                Quaternion reflectedRotation = Quaternion.LookRotation(reflected);


//				rb.isKinematic = true;
//				rb.MoveRotation(reflectedRotation);
//				rb.isKinematic = false;
				// rb.angularVelocity = Vector3.zero;
                // transform.rotation = reflectedRotation;
                bounce--;
            }
        }
    }
}