﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class number2 : MonoBehaviour {

	bool activated = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{
		if (activated == true) {
			SceneManager.LoadScene("Level2");
		}

	}
}