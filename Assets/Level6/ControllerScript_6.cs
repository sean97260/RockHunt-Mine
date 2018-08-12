using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript_6 : MonoBehaviour
{

	public float maxSpeed = 10f;
	public bool facingRight = true;
	public Rigidbody2D Body;
	public float timer;
	public float jump_timer = 0f;
    public float height;


	Animator anim;

	public Vector2 speed = new Vector2(10, 10);

	private Vector2 movement = new Vector2(1, 1);

	void FixedUpdate()
	{
		// 5 - Move the game object
		Body.AddForce(movement);
		//rigidbody2D.AddForce(movement);

	}

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		Body = this.GetComponent<Rigidbody2D> ();
       
	}

	// Update is called once per frame
	void Update()
	{
        if (GameObject.Find("bag").GetComponent<BagScript06>().stopMoving == true) {
			float move = Input.GetAxis ("Horizontal");
			if (HasParam (anim, "Speed")) {
				anim.SetFloat ("Speed", Mathf.Abs (move));
			}

			Body.velocity = new Vector2 (move * maxSpeed, Body.velocity.y);

			if (move > 0 && facingRight) {
				Flip ();
			} else if (move < 0 && !facingRight) {
				Flip ();
			}

			float inputX = Input.GetAxis ("Horizontal");
			float inputY = Input.GetAxis ("Vertical");

			movement = new Vector2 (
				speed.x * inputX,
				speed.y * inputY);

			if (Input.GetKeyDown ("up") && jump_timer < 0.5f) {
				transform.Translate (Vector3.up * 200 * Time.fixedDeltaTime, Space.World);
				//				Body.AddForce(Vector2.up * 40f, ForceMode2D.Impulse);
				jump_timer = 1f;
				anim.SetBool ("Jump", true);
			} else {
				anim.SetBool ("Jump", false);
			}

			Body.velocity = new Vector2(move* maxSpeed, Body.velocity.y);

			if (jump_timer > 0f) {
				jump_timer -= Time.deltaTime;
			}
		}

	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale; //get the local scale
		theScale.x *= -1; //flip the x axis
		transform.localScale = theScale; //update the local scale
	}

	bool HasParam(Animator animator, string paramName)
	{
		foreach (AnimatorControllerParameter parameter in animator.parameters)
		{
			if (parameter.name == paramName)
			{
				return true;
			}
		}
		return false;
	}

}
