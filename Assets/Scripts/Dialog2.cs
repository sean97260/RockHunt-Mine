using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog2 : MonoBehaviour
{

    private Animator dialogAnimator;
    private UnityEngine.AnimatorStateInfo indicator;
    GameObject portal;
	GameObject character;
	bool windgone = false;

    // Use this for initialization
    void Start()
    {
        dialogAnimator = GameObject.Find("Dialog generator").GetComponent<Animator>();
        portal = GameObject.Find("Portal");
        portal.SetActive(false);
		character = GameObject.Find ("Character");
    }

    // Update is called once per frame
    void LateUpdate()
    {	

		if (character.transform.position.x >= 16.8 && character.transform.position.x <= 22) {
			print ("wind should go");
			dialogAnimator.SetBool ("wind", true);
		} 

		if (character.transform.position.x >= 51 && character.transform.position.x <= 56) {
			dialogAnimator.SetBool ("water", true);
		} 



        if (dialogAnimator.GetCurrentAnimatorStateInfo(0).IsName("portal"))
        {
            portal.SetActive(true);
        }
        if (Input.GetKeyDown("space"))
        {
            dialogAnimator.SetTrigger("Space");
        }

        if (GameObject.Find("Sand") != null) {
            dialogAnimator.GetComponent<Animator>().SetBool("gotSand", true);
        }
    }
}
