using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	public Rigidbody2D Body;

	Animator anim;



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
//		if (GameObject.Find ("Dialog generator").GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Silence")
//			|| GameObject.Find ("Dialog generator").GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Silence 0")
//			|| GameObject.Find ("Dialog generator").GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("portal")) {
			float move = Input.GetAxis ("Horizontal");

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) ) {
			anim.SetFloat ("Speed", Mathf.Abs (move));
			anim.SetBool ("move", true);
			GameObject.Find ("Character_leg").GetComponent<Animator> ().SetBool ("move", true);
		} else {
			anim.SetBool ("move", false);
			GameObject.Find ("Character_leg").GetComponent<Animator> ().SetBool ("move", false);
			
		}
        
			Body.velocity = new Vector2 (move * maxSpeed, Body.velocity.y);

			if (move > 0 && facingRight) {
				Flip ();
			} else if (move < 0 && !facingRight) {
				Flip ();
			}

		/*	if (Input.GetKeyDown ("space") && anim.name == "Character") {
				anim.SetBool ("Drill", true);
			} else */if (Input.GetKeyUp ("space") && anim.name == "Character") {
				anim.SetBool ("Drill", false);
			}
		//}
	}


	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale; //get the local scale
		theScale.x *= -1; //flip the x axis
		transform.localScale = theScale; //update the local scale
	}

    bool HasParam(Animator animator, string paramName) {
        foreach (AnimatorControllerParameter parameter in animator.parameters) {
            if (parameter.name == paramName) {
                return true;
            }
        }
        return false;
    }
}
