using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFScript : MonoBehaviour {

    public GameObject rock; // the rock that needs to be placed in a certain spot
    Animator anim;
    GameObject character;

    float leftBound;
    float rightBound;

    // Sometimes we need the area to be wider
    public float leftOffset;
    public float rightOffset;

	// Use this for initialization
	void Start () {
        leftBound = this.transform.position.x - 2 + leftOffset;
        rightBound = this.transform.position.x + 2 + rightOffset;
        anim = this.GetComponent<Animator>();
        character = GameObject.Find("Character");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("x"))
        {
            anim.SetTrigger("X");
        }
        else
        {
            anim.ResetTrigger("X");
        }

        if (leftBound - 2 <= character.transform.position.x && character.transform.position.x <= rightBound + 2)
        {
            anim.SetBool("Character", true);
        }
        else {
            anim.SetBool("Character", false);
        }

        if (rock.activeSelf && leftBound <= rock.transform.position.x && rock.transform.position.x <= rightBound)
        {
            anim.SetBool("Rock", true);
        }
        else
        {
            anim.SetBool("Rock", false);
        }
	}
}
