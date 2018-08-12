using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartButtonScript : MonoBehaviour {

    GameObject startButtonShaded;

	// Use this for initialization
	void Start () {
        startButtonShaded = GameObject.Find("StartButtonShaded");
        startButtonShaded.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        startButtonShaded.SetActive(true);
        SceneManager.LoadScene("Map");
    }

}
