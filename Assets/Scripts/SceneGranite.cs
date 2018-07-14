using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGranite : MonoBehaviour
{

    public GameObject obj;
	float timer;
	float timer2;

    // Use this for initialization
    void Start()
    {
		timer = 0f;
		timer2 = 0f;
    }

    // Update is called once per frame
    void Update()
    {

		if (this.gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("granite pieces")) {
			timer2 += Time.deltaTime;
			if (timer2 >= 7) {
				this.gameObject.GetComponent<Animator> ().SetBool ("sand", true);
				if (transform.position.x >= 29 && transform.position.x <= 33) {
					GameObject.Find ("EventManager").GetComponent<EventManager> ().windUsed = true;
					GameObject.Find ("Dialog generator").GetComponent<Animator> ().SetBool ("windgone", true);
				} else if (transform.position.x >= 56 && transform.position.x <= 62.3) {
					GameObject.Find ("EventManager").GetComponent<EventManager> ().waterUsed = true;
					GameObject.Find ("Dialog generator").GetComponent<Animator>().SetBool("watergone",true);
				}
			}

		} else {
			timer2 = 0f;
		}

		if (transform.position.x >= 29 && transform.position.x <= 33) {
			if (GameObject.Find ("EventManager").GetComponent<EventManager> ().windUsed == false) {
				timer += Time.deltaTime;

				if (timer >= 10) {
					timer = 0f;
					this.gameObject.GetComponent<Animator> ().SetBool ("transform", true);
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
				} 

			} else {
				timer = 0f;
			}
		} 


        if (this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SandShowUp"))
        {
            GameObject.Find("Dialog generator").GetComponent<Animator>().SetBool("gotSand", true);

        }

        GameObject cloud = GameObject.Find("Cloud");

        if (cloud != null && cloud.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Rain")
            && cloud.transform.position.x - 2 <= this.transform.position.x && cloud.transform.position.x + 2 >= this.transform.position.x)
        {
            this.gameObject.GetComponent<Animator>().SetBool("transform", true);
        }

    }
}
