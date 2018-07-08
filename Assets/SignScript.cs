using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignScript : MonoBehaviour {

	GameObject moveInfo;
	GameObject spaceInfo;
	GameObject shiftInfo;

	GameObject character;

	// Use this for initialization
	void Start () {
		moveInfo = GameObject.Find ("move info");
		spaceInfo = GameObject.Find ("space info");
		shiftInfo = GameObject.Find ("shift info");
		character = GameObject.Find ("Character");		
		moveInfo.SetActive (false);	
		spaceInfo.SetActive (false);		
		shiftInfo.SetActive (false);		
	}

	// Update is called once per frame
	void Update () {
		if (character.transform.position.x >= 11.2 && character.transform.position.x <= 12.3) {
			moveInfo.SetActive (true);	
			spaceInfo.SetActive (true);		
			shiftInfo.SetActive (true);	
		} else {
			moveInfo.SetActive (false);	
			spaceInfo.SetActive (false);		
			shiftInfo.SetActive (false);	
		}
	}
}
