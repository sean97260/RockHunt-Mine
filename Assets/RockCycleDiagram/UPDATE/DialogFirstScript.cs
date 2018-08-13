using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogFirstScript : MonoBehaviour
{

    GameObject characterIcon;
    Animator anim;
    GameObject wizardIcon;

    // Use this for initialization
    void Start()
    {
        wizardIcon = GameObject.Find("wizardIcon");
        characterIcon = GameObject.Find("CharacterIcon");
        characterIcon.SetActive(false);
        wizardIcon.SetActive(true);
        anim = this.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("1") && (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            anim.SetBool("2", true);
            
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("2") && (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            anim.SetBool("3", true);
            
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("3") && (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            anim.SetBool("4", true);
            
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("4") && (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            anim.SetBool("5", true);
            
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("5") && (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            anim.SetBool("6", true);
            
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("6") && (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            anim.SetBool("7", true);

        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("7") && (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            anim.SetBool("8", true);
            wizardIcon.SetActive(false);
            characterIcon.SetActive(true);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("8") && (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            wizardIcon.SetActive(true);
            characterIcon.SetActive(false);
            anim.SetBool("9", true);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("9") && (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            anim.SetBool("10", true);

        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("10") && (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            anim.SetBool("11", true);

        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("11") && (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            GameObject.Find("DialogFirst").SetActive(false);

        }




    }
}
