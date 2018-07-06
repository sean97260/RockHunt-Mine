using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public static int CurrLevel = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 4; i > CurrLevel; i--) {
            string NumName = "N" + i.ToString();
            if (GameObject.Find(NumName) != null)
            {
                GameObject.Find(NumName).SetActive(false);
            }
        }
	}
}
