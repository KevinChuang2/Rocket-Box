using UnityEngine;
using System.Collections;


public class Explode : MonoBehaviour {

    public float power = 10000000.0f;
    public float radius = 10.0f;
    private bool test=true ;
	//TODO: explosion model for game
	void ExplosionDamage(Vector3 center, float radius) {
        
		Collider[] hitColliders = Physics.OverlapSphere(center, radius);
		int i = 0;
		while (i < hitColliders.Length) {
			if(hitColliders[i].CompareTag(Tags.Player)){
				//check if player, apply damage if so
				hitColliders[i].gameObject.GetComponent<Character>().TakeDamage();
                //needs PlayerScript w/ AddDamage() implmented to work, yell at Tiffany
                Rigidbody rb = hitColliders[i].GetComponent<Rigidbody>();
                if(rb!=null)
                {

                    rb.AddForce(Vector3.Normalize(rb.position - transform.position)*50,ForceMode.Impulse);
                }

				break;
			}
			i++;
		}
	}

	// Use this for initialization
	void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
        if(test)
            ExplosionDamage(transform.position, radius);
        test = false;
    }


}
