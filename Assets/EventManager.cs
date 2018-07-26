using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    GameObject bag;
    GameObject character;
    GameObject granite_1;
    GameObject granite_2;
    GameObject sand_1;
    GameObject sand_2;
    Animator dialogAnim;
	Animator minerAnim;
	Animator minerDialogAnim;
	Animator researcherAnim;
	Animator researcherDialogAnim;
    GameObject transition;

    float offset;

    public bool waterUsed;
    public bool windUsed;

    // Use this for initialization
    void Start()
    {
        dialogAnim = GameObject.Find("Dialog generator").GetComponent<Animator>();
		minerAnim = GameObject.Find("Miner").GetComponent<Animator>();
		minerDialogAnim = GameObject.Find("MinerDialog").GetComponent<Animator>();
		researcherAnim = GameObject.Find("Researcher").GetComponent<Animator>();
		researcherDialogAnim = GameObject.Find("ResearcherDialog").GetComponent<Animator>();
        bag = GameObject.Find("bag");
        character = GameObject.Find("Character");
        granite_1 = GameObject.Find("SceneGranite");
        granite_2 = GameObject.Find("SceneGranite (1)");
        sand_1 = GameObject.Find("SceneSand");
        sand_2 = GameObject.Find("SceneSand (1)");
        if (sand_1 != null) { sand_1.SetActive(false); }
        if (sand_2 != null) { sand_2.SetActive(false); }
        waterUsed = false;
        windUsed = false;
        transition = GameObject.Find("Transition");


    }

    // Update is called once per frame
    void Update()
    {

        if (granite_1 != null && character.GetComponent<Collider2D>().IsTouching(granite_1.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript>().addObject(granite_1);
        }

        if (granite_2 != null && character.GetComponent<Collider2D>().IsTouching(granite_2.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript>().addObject(granite_2);
        }

        if (sand_1 != null && character.GetComponent<Collider2D>().IsTouching(sand_1.GetComponent<Collider2D>()))
        {
            print("touch sand");
            bag.GetComponent<BagScript>().addObject(sand_1);
        }

        if (sand_2 != null && character.GetComponent<Collider2D>().IsTouching(sand_2.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript>().addObject(sand_2);
        }
        if (windUsed == true)
        {
            if (transition != null) {
                transition.GetComponent<Animator>().SetBool("Wind", true);
            }/*
            if (GameObject.Find("Wind") != null)
            {
                GameObject.Find("Wind").SetActive(false);
            }
            dialogAnim.SetBool("windgone", true);
			minerAnim.SetBool("windgone", true);
			minerDialogAnim.SetBool("windgone", true);*/
        }

        if (waterUsed == true)
        {
            if (transition != null)
            {
                transition.GetComponent<Animator>().SetBool("Water", true);
            }
            /*
			dialogAnim.SetBool("watergone", true);
			researcherAnim.SetBool("watergone", true);
			researcherDialogAnim.SetBool("watergone", true);*/
        }
    }

    public void takeFromBag(GameObject item)
    {
        if (character.GetComponent<ControllerScript>().facingRight == true)
        {
            offset = -2.3f;
        }
        else
        {
            offset = 2.3f;
        }

        if (item.name == "GraniteIcon_1")
        {
            granite_1.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            granite_1.SetActive(true);
        }

        if (item.name == "GraniteIcon_2")
        {
            granite_2.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            granite_2.SetActive(true);
        }

        if (item.name == "SandIcon_1")
        {
            sand_1.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            sand_1.SetActive(true);
        }

        if (item.name == "SandIcon_2")
        {
            sand_2.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            sand_2.SetActive(true);
        }

    }
}
