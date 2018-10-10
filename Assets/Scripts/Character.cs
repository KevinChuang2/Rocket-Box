using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	public int hp = 50;
    public Text hpText;

	private int invincible = 0; //how long the character is invincible for
    private bool _damage = false;

	// Use this for initialization
	void Start () {
		hp = 100;
        SetHPText();
	}

	// Update is called once per frame
	void Update () {
		if(hp <= 0){
			Debug.Log ("Character is dead");
            gameObject.SetActive(false);
		}
		//does FPS have transform? move character back by a litle
	}

	void OnControllerColliderHit(ControllerColliderHit other)
	{
        //Debug.Log("collision hit");
		if (other.gameObject.CompareTag(Tags.Rocket))
		{
			//add code when we have other types of rockets
			//.Log("Collision");
			//hp -= 2;
			TakeDamage();
		}
		if (other.gameObject.CompareTag(Tags.Spikes))
		{
			//hp--;
			invincible = 1;
			TakeDamage();
		}


	}

    void OnCollisionEnter(Collision other)
    {
      //  Debug.Log("collision hit");
        if (other.gameObject.CompareTag(Tags.Rocket))
        {
            //add code when we have other types of rockets
           // Debug.Log("Collision");
            //hp -= 2;
            TakeDamage();
        }
        if (other.gameObject.CompareTag(Tags.Spikes))
        {
            //hp--;
            invincible = 1;
            TakeDamage();
        }
    }


    public void TakeDamage()
	{
		hp-=10;
        SetHPText();
        Debug.Log ("current hp: " + hp);
	}

    public void SetHPText()
    {
        hpText.text = "HP: " + hp.ToString();
    }
}