using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundWizardScript : MonoBehaviour
{

    GameObject PressToTalk;
    GameObject character;
    Animator wizardDialogAnim;

    // Use this for initialization
    void Start()
    {
        PressToTalk = GameObject.Find("PressToTalkGround");
        character = GameObject.Find("Character");

        wizardDialogAnim = GameObject.Find("groundDialog").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( character.transform.position.x >= 77.5 && character.transform.position.x <= 81.5)
        {
            PressToTalk.SetActive(true);
            if (GameObject.Find("bag").GetComponent<BagScript06>().twomagma == true)
            {
                wizardDialogAnim.SetBool("two magma", true);
                wizardDialogAnim.SetBool("pass2", true);
            }
            else
            {
                wizardDialogAnim.SetBool("two magma", false);
            }

        }
        else
        {
            PressToTalk.SetActive(false);
        }

    }
}
