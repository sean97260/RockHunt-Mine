using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizardScript : MonoBehaviour
{

    GameObject PressToTalk;
    GameObject character;
    Animator wizardDialogAnim;

    // Use this for initialization
    void Start()
    {
        PressToTalk = GameObject.Find("PressToTalkFire");
        character = GameObject.Find("Character");
        PressToTalk.SetActive(false);
        wizardDialogAnim = GameObject.Find("FireDialog").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        print(character.transform.position.x);
        if (character.transform.position.y <= -5.0 && character.transform.position.x >= 22 && character.transform.position.x <= 29.8)
        {
            PressToTalk.SetActive(true);
            if (GameObject.Find("bag").GetComponent<BagScript06>().twometaq == true)
            {
                wizardDialogAnim.SetBool("twoGranites", true);
                wizardDialogAnim.SetBool("pass1", true);
                GameObject.Find("Transition").GetComponent<Animator>().SetTrigger("FireSatisfied");
            }
            else
            {
                wizardDialogAnim.SetBool("twoGranites", false);
            }

        }
        else
        {
            PressToTalk.SetActive(false);
        }

    }
}
