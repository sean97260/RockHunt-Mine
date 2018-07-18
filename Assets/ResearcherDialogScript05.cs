using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearcherDialogScript05 : MonoBehaviour
{

    GameObject character;
    Animator anim;
    float timer = .1f;

    // Use this for initialization
    void Start()
    {
        character = GameObject.Find("Character");
        anim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("bag").GetComponent<BagScript05>().bookOpened)
        {
            timer = 0.1f;
        }
        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
            return; // Prevent dialog if user pressed space to choose something from the book.
        }

        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("Space");
        }
        else
        {
            anim.ResetTrigger("Space");
        }
        if (character.transform.position.x >= 42 && character.transform.position.x <= 45.2)
        {
            anim.SetBool("Back", false);

        }
        else
        {
            anim.SetBool("Back", true);
        }

    }
}
