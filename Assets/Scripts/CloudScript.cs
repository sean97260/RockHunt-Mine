using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour {

    private Animator animator;
    private bool IsSelected = true;
	public float timer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find("bag").GetComponent<Animator> ().SetBool ("use", false);

    }


    // The user clicked on the object
    void OnMouseUpAsButton()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("StartRaining");
    }
}
