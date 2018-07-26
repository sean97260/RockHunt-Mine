using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager01 : MonoBehaviour {

    public GameObject character;
    public GameObject sand;
    public Animator WizardDialogController;

	// Use this for initialization
	void Start () {
        character = GameObject.Find("Character");
        sand = GameObject.Find("Sand");
        WizardDialogController = GameObject.Find("WizardDialog").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (character.GetComponent<BoxCollider2D>().IsTouching(sand.GetComponent<BoxCollider2D>())) {
            sand.SetActive(false);
            WizardDialogController.SetBool("Sand", true); 
        }
	}
}
