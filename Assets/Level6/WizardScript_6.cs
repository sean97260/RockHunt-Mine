using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript_6 : MonoBehaviour
{

    GameObject PressToTalk;
    GameObject character;
    Animator wizardDialogAnim;
    Animator minerDialogAnim;
    Animator groundDialogAnim;
    Animator fireDialogAnim;

    // Use this for initialization
    void Start()
    {
        PressToTalk = GameObject.Find("PressToTalk");
        character = GameObject.Find("Character");
        PressToTalk.SetActive(false);
        wizardDialogAnim = GameObject.Find("WizardDialog").GetComponent<Animator>();
        groundDialogAnim = GameObject.Find("groundDialog").GetComponent<Animator>();
        fireDialogAnim = GameObject.Find("FireDialog").GetComponent<Animator>();
        minerDialogAnim = GameObject.Find("MinerDialog").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (character.transform.position.x >= -10 && character.transform.position.x <= -6)
        {
            PressToTalk.SetActive(true);
            if (minerDialogAnim.GetBool("pass3") == true && fireDialogAnim.GetBool("pass1") == true  && groundDialogAnim.GetBool("pass2") == true)
            {
                wizardDialogAnim.SetBool("levelPass", true);
            }
            else
            {
                wizardDialogAnim.SetBool("levelPass", false);
            }

        }
        else
        {
            PressToTalk.SetActive(false);
        }

    }
}
