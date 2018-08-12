using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDialogScript : MonoBehaviour
{

    GameObject character;
    Animator anim;
    GameObject portal;

    // Use this for initialization
    void Start()
    {
        character = GameObject.Find("Character");
        anim = this.GetComponent<Animator>();
        portal = GameObject.Find("Portal_2");
   //     portal.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("bag").GetComponent<BagScript06>().bookOpened == false  && character.transform.position.x >= 77.5 && character.transform.position.x <= 81.5)
        {
            anim.SetBool("back", false);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("groundIdle") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk1", true);
                anim.SetBool("finishTalk", false);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("gtalk1") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk1", false);
                anim.SetBool("talk2", true);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("gtalk2") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk2", false);
                anim.SetBool("finishTalk", true);
                portal.SetActive(true);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("gtalk3") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk1", false);
                anim.SetBool("talk3", true);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("gtalk4") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk3", false);
                anim.SetBool("finishTalk", true);
                portal.SetActive(true);
            }

        }
        else
        {
            anim.SetBool("talk1", false);
            anim.SetBool("talk2", false);
            anim.SetBool("talk3", false);
            anim.SetBool("finishTalk", false);
            anim.SetBool("back", true);
        }

    }
}
