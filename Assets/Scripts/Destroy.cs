using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	Animator anim;
	Animator bagAnim;
	GameObject otherObject;
	int rockCollected;
	bool digged = false;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		bagAnim = GameObject.Find ("bag").GetComponent<Animator>();
	}
		
    void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Cowboy") {
			otherObject = other.gameObject;
		}
	}

	// Update is called once per frame
	void Update () {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("destroy")) {
			this.gameObject.GetComponent<Renderer>().enabled = false;
			Destroy (this.gameObject);
		}

		if (otherObject != null && 
			otherObject.GetComponent<Collider2D>().IsTouching(this.gameObject.GetComponent<Collider2D>()) &&
			otherObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo (0).IsName ("Drill") &&
			digged == false) {
				rockCollected = bagAnim.GetInteger ("rock_collected");
				bagAnim.SetInteger ("rock_collected", rockCollected + 1);
				digged = true;
				anim.SetBool ("explode", true);
				
		}
	}
}
