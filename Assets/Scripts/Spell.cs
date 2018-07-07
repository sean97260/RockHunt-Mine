using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    public GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
		if (this.name == "Wind") {
			obj.GetComponent<Animator> ().SetTrigger ("Chosen");
			GameObject.Find ("Character").GetComponent<Animator> ().SetBool ("Wind", true);
		} else {
			obj.GetComponent<Animator> ().SetTrigger ("Chosen");
			GameObject.Find ("Character").GetComponent<Animator> ().SetBool ("Fire", true);
		}
    }
}
