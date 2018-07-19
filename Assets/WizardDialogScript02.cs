using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardDialogScript02 : MonoBehaviour
{

    GameObject character;
    Animator anim;
    GameObject portal;

    // Use this for initialization
    void Start()
    {
        character = GameObject.Find("Character");
        anim = this.GetComponent<Animator>();
        portal = GameObject.Find("Portal");
        portal.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (character.transform.position.x >= -10 && character.transform.position.x <= -7)
        {
            anim.SetBool("Back", false);
            if (Input.GetKeyDown("space"))
            {
                anim.SetTrigger("Space");
            }
            else
            {
                anim.ResetTrigger("Space");
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("end2") && Input.GetKeyDown("space"))
            {
                portal.SetActive(true);
            }

        }
        else
        {
            anim.SetBool("Back", true);
        }

    }
}
