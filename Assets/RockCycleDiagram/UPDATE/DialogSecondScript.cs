using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSecondScript : MonoBehaviour
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


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("2") && (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            anim.SetBool("2", true);

        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("3") && (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)))
        {
            GameObject.Find("DialogSecond").SetActive(false);
                      
        }







    }
}
