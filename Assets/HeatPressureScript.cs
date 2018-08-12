using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatPressureScript : MonoBehaviour {

    Animator anim;
    public bool heatPressureOn = false;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("X")) {
            heatPressureOn = true;
        }
        if (Input.GetKeyDown("x"))
        {
            anim.SetTrigger("X");
            heatPressureOn = true;

        }
        else {
            anim.ResetTrigger("X");
        }

    }
}
