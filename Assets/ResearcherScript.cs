using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearcherScript : MonoBehaviour {

	GameObject PressToTalk;
	GameObject character;
	Animator anim;

	// Use this for initialization
	void Start () {
		PressToTalk = GameObject.Find ("PressToTalkResearcher");
		character = GameObject.Find ("Character");
		anim = this.GetComponent<Animator> ();
		PressToTalk.SetActive (false);	
	}

	// Update is called once per frame
	void Update () {
		if (character.transform.position.x >= 42 && character.transform.position.x <= 45.2) {
			PressToTalk.SetActive (true);


		} else {
			PressToTalk.SetActive (false);
		}

	}
}