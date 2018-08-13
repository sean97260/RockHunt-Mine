using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {

    Animator timeTravelAnim;
    AudioSource music;

	// Use this for initialization
	void Start () {
        if (GameObject.Find("TimeTravel") != null) { timeTravelAnim = GameObject.Find("TimeTravel").GetComponent<Animator>(); }
        music = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (timeTravelAnim != null && timeTravelAnim.GetCurrentAnimatorStateInfo(0).IsName("TimeTravel"))
        {
            music.mute = true;
        }
        else if (music.mute) {
            music.mute = false;
        }
	}
}
