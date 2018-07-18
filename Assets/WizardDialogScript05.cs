using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardDialogScript05 : MonoBehaviour
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
        if (character.transform.position.x >= -10 && character.transform.position.x <= -6)
        {
            anim.SetBool("back", false);
            if (Input.GetKeyDown("space"))
            {
                anim.SetTrigger("Space");
            }
            else {
                anim.ResetTrigger("Space");
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                anim.SetBool("finishTalk", false);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("talk2"))
            {
                anim.SetBool("finishTalk", true);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("sandstone2") && Input.GetKeyDown("space"))
            {
                portal.SetActive(true);
            }

        }
        else
        {

            anim.SetBool("finishTalk", false);
            anim.SetBool("back", true);
        }

    }
}
