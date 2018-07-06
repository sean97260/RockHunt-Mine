using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Animator> ().SetBool ("closeBook", false);
	}

	void OnMouseDown()
	{
		GameObject.Find("bag").GetComponent<Animator> ().SetBool ("closeBook", true);
		this.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

		
	}
}
