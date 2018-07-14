using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerScript : MonoBehaviour {

	GameObject PressToTalk;
	GameObject character;
	Animator anim;

	// Use this for initialization
	void Start () {
		PressToTalk = GameObject.Find ("PressToTalkMiner");
		character = GameObject.Find ("Character");
		anim = this.GetComponent<Animator> ();
		PressToTalk.SetActive (false);	
	}

	// Update is called once per frame
	void Update () {
		if (character.transform.position.x >= 12.5 && character.transform.position.x <= 17.3) {
			PressToTalk.SetActive (true);


		} else {
			PressToTalk.SetActive (false);
		}

	}
}
