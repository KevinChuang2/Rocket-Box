using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour {

    public Character character;
    public Text hpText;
    private Slider hpbar;

    // Use this for initialization
    void Start () {
        hpbar = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        int health = character.hp;
        hpbar.value = health;
        hpText.text = health.ToString() + "/" + hpbar.maxValue.ToString();
	}
}
