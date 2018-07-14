using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearcherDialogScript : MonoBehaviour {

	GameObject character;
	Animator anim;

	// Use this for initialization
	void Start () {
		character = GameObject.Find ("Character");
		anim = this.GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {
		if (character.transform.position.x >= 42 && character.transform.position.x <= 45.2) {
			anim.SetBool ("back", false);

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("researcher") && Input.GetKeyDown ("space")) {
				anim.SetBool ("talk1", true);
				anim.SetBool ("finishTalk", false);
			}

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("researcher1") && Input.GetKeyDown ("space")) {
				anim.SetBool ("talk1", false);
				anim.SetBool ("talk2", true);
			}

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("researcher2") && Input.GetKeyDown ("space")) {
				anim.SetBool ("talk2", false);
				anim.SetBool ("finishTalk", true);
			}

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("talk3") && Input.GetKeyDown ("space")) {
				anim.SetBool ("talk1", false);
				anim.SetBool ("talk4", true);
			}

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("talk4") && Input.GetKeyDown ("space")) {
				anim.SetBool ("talk4", false);
				anim.SetBool ("finishTalk", true);
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
