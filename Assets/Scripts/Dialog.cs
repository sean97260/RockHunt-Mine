using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour {

	private Animator dialogAnimator;
	private UnityEngine.AnimatorStateInfo indicator;
	GameObject portal;
    public GameObject cloud;

	// Use this for initialization
	void Start () {
		dialogAnimator = GameObject.Find ("Dialog generator").GetComponent<Animator> ();
		portal = GameObject.Find ("Portal");
		portal.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (dialogAnimator.GetCurrentAnimatorStateInfo(0).IsName("portal")) {
			portal.SetActive (true);
		}
        if (Input.GetKeyDown("space"))
        {
            dialogAnimator.SetTrigger("Space");
            indicator = dialogAnimator.GetCurrentAnimatorStateInfo(0);
            if (indicator.IsName("HelloThereWait"))
            {
                dialogAnimator.SetBool("gap1", true);
            }
            else if (indicator.IsName("SelfIntroductionWait"))
            {
                dialogAnimator.SetBool("gap2", true);
            }
            else if (indicator.IsName("HelpMeWait"))
            {
                dialogAnimator.SetBool("gap3", true);
            }
            else if (indicator.IsName("TryThisWait"))
            {
                dialogAnimator.SetBool("gap4", true);
            }
            else if (indicator.IsName("Rain"))
            {
                dialogAnimator.SetBool("getRain", true);
                if (cloud != null)
                {
                    cloud.SetActive(true);
                }
            }
            else if (dialogAnimator.GetBool("granite") == true && indicator.IsName("GraniteGot"))
            {
                dialogAnimator.SetBool("gap5", true);
            }
            else if (indicator.IsName("rememberWait"))
            {
                dialogAnimator.SetBool("remember", true);
            }
            else if (dialogAnimator.GetBool("gotSand") == true && indicator.IsName("gotSand"))
            {
                dialogAnimator.SetBool("gap6", true);
            }
            else if (indicator.IsName("endWait"))
            {
                dialogAnimator.SetBool("gap7", true);
            }
        }
        else {
            dialogAnimator.ResetTrigger("Space");
        }
		
	}
}
