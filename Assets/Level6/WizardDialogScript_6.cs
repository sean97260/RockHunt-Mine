using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardDialogScript_6 : MonoBehaviour
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
        if (character.transform.position.x >= -8.743 && character.transform.position.x <= -4.822)
        {
            anim.SetBool("back", false);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("wizardIdle") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk1", true);
                anim.SetBool("finishTalk", false);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("wtalk1") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk1", false);
                anim.SetBool("talk2", true);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("wtalk2") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk2", false);
                anim.SetBool("finishTalk", true);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("wtalk3") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk1", false);
                anim.SetBool("talk4", true);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("wtalk4") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk4", false);
                anim.SetBool("finishTalk", true);
                portal.SetActive(true);
            }

        }
        else
        {
            anim.SetBool("talk1", false);
            anim.SetBool("talk2", false);
            anim.SetBool("talk4", false);
            anim.SetBool("finishTalk", false);
            anim.SetBool("back", true);
        }

    }
}
