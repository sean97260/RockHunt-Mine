using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardDialogScript_2 : MonoBehaviour {

	GameObject character;
	Animator anim;
	GameObject portal;

	// Use this for initialization
	void Start () {
		character = GameObject.Find ("Character");
		anim = this.GetComponent<Animator> ();
		portal = GameObject.Find ("Portal");
		portal.SetActive (false);

	}

	// Update is called once per frame
	void Update () {
		if (character.transform.position.x >= -10 && character.transform.position.x <= -6) {
			anim.SetBool ("back", false);

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("idle") && Input.GetKeyDown ("space")) {
				anim.SetBool ("talk1", true);
				anim.SetBool ("finishTalk", false);
			}

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("talk1") && Input.GetKeyDown ("space")) {
				anim.SetBool ("talk1", false);
				anim.SetBool ("talk2", true);
			}

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("talk2") && Input.GetKeyDown ("space")) {
				anim.SetBool ("talk2", false);
				anim.SetBool ("finishTalk", true);
			}

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("twosand1") && Input.GetKeyDown ("space")) {
				anim.SetBool ("talk1", false);
				anim.SetBool ("talk4", true);
			}

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("twosand2") && Input.GetKeyDown ("space")) {
				anim.SetBool ("talk4", false);
				anim.SetBool ("finishTalk", true);
				portal.SetActive (true);
			}

		} else {
			anim.SetBool ("talk1", false);
			anim.SetBool ("talk2", false);
			anim.SetBool ("talk4", false);
			anim.SetBool ("finishTalk", false);
			anim.SetBool ("back", true);
		}

	}
}
