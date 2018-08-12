using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDialogScript : MonoBehaviour
{

    GameObject character;
    Animator anim;
    GameObject portal;


    // Use this for initialization
    void Start()
    {
        character = GameObject.Find("Character");
        anim = this.GetComponent<Animator>();
        portal = GameObject.Find("Portal_2 (1)");
        portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("bag").GetComponent<BagScript06>().bookOpened == false && character.transform.position.y <= -5.0 && character.transform.position.x >= 22 && character.transform.position.x <= 35)
        {
            anim.SetBool("back", false);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("fireIdle") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk1", true);
                anim.SetBool("finishTalk", false);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("talk1") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk1", false);
                anim.SetBool("talk2", true);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("talk2") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk2", false);
                anim.SetBool("finishTalk", true);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("talk3") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk1", false);
                anim.SetBool("talk4", true);
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("talk4") && Input.GetKeyDown("space"))
            {
                anim.SetBool("talk4", false);
                anim.SetBool("finishTalk", true);
                GameObject.Find("HeatPressure").GetComponent<Animator>().SetTrigger("FireWizardDone");
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
