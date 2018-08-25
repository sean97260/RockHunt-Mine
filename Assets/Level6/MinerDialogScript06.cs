﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerDialogScript06 : MonoBehaviour {


    GameObject character;
    Animator anim;

    // Use this for initialization
    void Start () {
        character = GameObject.Find ("Character");
        anim = this.GetComponent<Animator> ();

    }

    // Update is called once per frame
    void Update () {
        if (character.transform.position.x >= 12.5 && character.transform.position.x <= 17.3) {
            anim.SetBool ("back", false);

            if (anim.GetCurrentAnimatorStateInfo (0).IsName ("minerIdle") && Input.GetKeyDown ("space")) {
                anim.SetBool ("talk1", true);
                anim.SetBool ("finishtalk", false);
            }

            if (anim.GetCurrentAnimatorStateInfo (0).IsName ("talk1") && Input.GetKeyDown ("space")) {
                anim.SetBool ("talk1", false);
                anim.SetBool ("talk2", true);
            }

            if (anim.GetCurrentAnimatorStateInfo (0).IsName ("talk2") && Input.GetKeyDown ("space")) {
                anim.SetBool ("talk2", false);
                anim.SetBool ("finishtalk", true);
            }

            if (anim.GetCurrentAnimatorStateInfo (0).IsName ("talk3") && Input.GetKeyDown ("space")) {
                anim.SetBool ("talk1", false);
                anim.SetBool ("talk4", true);
            }

            if (anim.GetCurrentAnimatorStateInfo (0).IsName ("talk4") && Input.GetKeyDown ("space")) {
                anim.SetBool ("talk4", false);
                anim.SetBool ("finishtalk", true);
            }

        } else {
            anim.SetBool ("talk1", false);
            anim.SetBool ("talk2", false);
            anim.SetBool ("talk4", false);
            anim.SetBool ("finishtalk", false);
            anim.SetBool ("back", true);
        }

    }
}