using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour {

	private Animator dialogAnimator;
	private UnityEngine.AnimatorStateInfo indicator;
	GameObject portal;
	GameObject character;
	bool windgone = false;
	bool windgone_told = false;
	bool windtold;

	// Use this for initialization
	void Start () {
		dialogAnimator = GameObject.Find ("Dialog generator").GetComponent<Animator> ();
		portal = GameObject.Find ("Portal");
		portal.SetActive (false);
		character = GameObject.Find ("Character");
		windtold = false;
	}

	// Update is called once per frame
	void LateUpdate () {
		if (character.transform.position.x >= 16.8 && character.transform.position.x <= 22 && windtold == false) {
			windtold = true;
			print ("wind should go");
			dialogAnimator.SetBool ("wind", true);
		}

		if (windgone = true && windgone_told == false) {
			windgone_told = true;
			dialogAnimator.SetBool ("windgone", true);	
		}

		if (dialogAnimator.GetCurrentAnimatorStateInfo(0).IsName("portal")) {
			portal.SetActive (true);
		}

		
	}
}
