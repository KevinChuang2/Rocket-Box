using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	//initial pos -2, 4.8, -1
	bool movePosX;
	bool movePosZ;
	bool moveNegX;
	bool moveNegZ;
	// Use this for initialization
	void Start () {
		movePosX = true;//-2-9
		moveNegX = false;
		movePosZ = false;//-1-8
		moveNegZ = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(movePosX){
			this.transform.Translate(0.05f, 0, 0);
			if(this.transform.position.x >= 9){
				movePosX = false;
				movePosZ = true;
			}
		} else if(movePosZ){
			this.transform.Translate(0, 0, 0.05f);
			if(this.transform.position.z >= 8){
				movePosZ = false;
				moveNegX = true;
			}
		} else if(moveNegX){
			this.transform.Translate(-0.05f, 0, 0);
			if(this.transform.position.x <= -2){
				moveNegX = false;
				moveNegZ = true;
			}
		} else if(moveNegZ){
			this.transform.Translate(0, 0, -0.05f);
			if(this.transform.position.z <= -1){
				moveNegZ = false;
				movePosX = true;
			}
		}
	}
}
