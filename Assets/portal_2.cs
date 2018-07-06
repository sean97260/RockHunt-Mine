using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal_2 : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Cowboy") {
			SceneManager.LoadScene("Map2");
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
