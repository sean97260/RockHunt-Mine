using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {

	GameObject grid;
	GameObject alchemistBackground;
	GameObject rain;
	GameObject cloud;
	public bool bookOpened;

	// Use this for initialization
	void Start () {

		bookOpened = false;
		grid = GameObject.Find("InventoryGrid");
		alchemistBackground = GameObject.Find("alchemistBackground");
		rain = GameObject.Find("GridRain");
		cloud = GameObject.Find("Cloud");
		cloud.SetActive (false);
		CloseBook();
	}


	void OnMouseDown()
	{
		if (GameObject.Find ("Dialog generator").GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Silence")) {
			if (bookOpened) {
				CloseBook ();
				bookOpened = false;
			} else {
				OpenBook ();
				bookOpened = true;
			}
		}
    
	}

	public void CloseBook(){
	}

	public void OpenBook(){
		grid.SetActive (true);
	//	rain.SetActive (true);
	}

	// Update is called once per frame
	void Update () {

		if (this.GetComponent<Animator>().GetBool("closeBook") == true) {
			this.GetComponent<Animator> ().SetBool ("closeBook", false);
			cloud.SetActive (true);
			OnMouseDown();
		}
    }
}
