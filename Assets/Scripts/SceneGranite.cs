using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGranite : MonoBehaviour {

	private float timer;

    public GameObject obj;

	// Use this for initialization
	void Start () {
		timer = 0f;
        
    }
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x >= 29 && transform.position.x <= 33) {
			if (GameObject.Find ("EventManager").GetComponent<EventManager> ().windUsed == false) {
				timer += Time.deltaTime;

				if (timer >= 10) {
					timer = 0f;
					this.gameObject.GetComponent<Animator> ().SetBool ("transform", true);
					GameObject.Find ("EventManager").GetComponent<EventManager> ().windUsed = true;
					GameObject.Find ("Dialog generator").GetComponent<Animator>().SetBool("windgone",true);
					print ("success");
				}
			}else {
				timer = 0f;
			}
		} 

		if (transform.position.x >= 56 && transform.position.x <= 62.3){
			if (GameObject.Find("EventManager").GetComponent<EventManager>().waterUsed == false){
				timer += Time.deltaTime;

				if (timer >= 10) {
					timer = 0f;
					this.gameObject.GetComponent<Animator> ().SetBool ("transform", true);
					GameObject.Find ("EventManager").GetComponent<EventManager> ().waterUsed = true;
					GameObject.Find ("Dialog Generator").GetComponent<Animator>().SetBool("watergone",true);
				} 

			} else {
				timer = 0f;
			}
		} 

    }
}
