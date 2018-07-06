using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRain : MonoBehaviour {

	bool selected;


	// Use this for initialization
	void Start () {

	}


	void OnMouseDown()
	{
		if (selected) {
			this.gameObject.GetComponent<Animator> ().SetBool ("selected", false);
			selected = false;
			GameObject.Find("bag").GetComponent<Animator> ().SetBool ("use", false);
		} else {
			this.gameObject.GetComponent<Animator> ().SetBool ("selected", true);
			selected = true;
			GameObject.Find("bag").GetComponent<Animator> ().SetBool ("use", true);
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
