using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour {

    private Animator animator;
    private bool IsSelected = true;
	public float timer;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
		animator.SetTrigger("StartRaining");
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find("bag").GetComponent<Animator> ().SetBool ("use", false);
		animator.SetTrigger("StartRaining");
		timer += 1.0F * Time.deltaTime;
		if (timer >= 4)
		{
			timer = 0;
			this.gameObject.SetActive(false);
		}
    }


    // The user clicked on the object
    void OnMouseUpAsButton()
    {
 
    }
}
