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
        anim.SetBool("Granite", false);

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

        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("Space");
        }
        else {
            anim.ResetTrigger("Space");
        }

        if (GameObject.Find("SceneGranite") && GameObject.Find("SceneGranite").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SandShowUp"))
        {
            anim.SetBool("GraniteTransformed", true);
        }

        if (character.transform.position.x >= 12.5 && character.transform.position.x <= 17.3)
        {
            anim.SetBool("Back", false);
        }
        else
        {
            anim.SetBool("Back", true);
        }

    }
}