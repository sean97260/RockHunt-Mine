using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerDialogScript05 : MonoBehaviour
{


    GameObject character;
    Animator anim;
    float timer = 1f;

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
            timer = 1f;
        }
        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
            return;
        }
        if (character.transform.position.x >= 12.5 && character.transform.position.x <= 17.3)
        {
            anim.SetBool("back", false);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle") && Input.GetKeyDown("space"))
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