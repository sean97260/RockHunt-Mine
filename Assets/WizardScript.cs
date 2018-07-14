﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : MonoBehaviour {

	GameObject PressToTalk;
	GameObject character;
	Animator wizardDialogAnim;

	// Use this for initialization
	void Start () {
		PressToTalk = GameObject.Find ("PressToTalk");
		character = GameObject.Find ("Character");
		PressToTalk.SetActive (false);	
		wizardDialogAnim = GameObject.Find ("WizardDialog").GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (character.transform.position.x >= -10 && character.transform.position.x <= -6) {
			PressToTalk.SetActive (true);
			if (GameObject.Find ("bag").GetComponent<BagScript> ().twosand == true) {
				wizardDialogAnim.SetBool ("twoSand", true);		
			} else {
				wizardDialogAnim.SetBool ("twoSand", false);
			}

		} else {
			PressToTalk.SetActive (false);
		}
			
	}
}
