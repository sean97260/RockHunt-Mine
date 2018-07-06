using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

	GameObject obj; 

	// Use this for initialization
	void Start () {
		obj = GameObject.Find("SceneGranite");
        if (obj != null) { obj.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("dirt (1)") != null) {
			if (GameObject.Find ("dirt (1)").GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("destroy")) {
				obj.SetActive (true);
				GameObject.Find ("Dialog generator").GetComponent<Animator> ().SetBool ("granite", true);
			}
		
		}
}
}
