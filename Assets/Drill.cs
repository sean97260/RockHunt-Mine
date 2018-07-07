using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour {
   Animator charAnim;
    float time;

    // Use this for initialization
    void Start()
    {
        charAnim = GameObject.Find("Character").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (time <= 0f)
        {
            charAnim.SetBool("Drill", false);
        }
        else {
            if (time <= 0.05f) {
                GameObject granite = GameObject.Find("SceneGranite");
                if (granite == null)
                {
                    GameObject dialog = GameObject.Find("Dialog generator");
                    dialog.GetComponent<Animator>().SetTrigger("WrongDrill");
                }
            }
            time -= Time.deltaTime;
        }
    }

    private void OnMouseDown()
    {
        charAnim.SetBool("Drill", true);
        time = 2.5f;

    }
}
