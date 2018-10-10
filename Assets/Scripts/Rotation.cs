using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
    public Camera cam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = cam.transform.rotation;
    }
}
