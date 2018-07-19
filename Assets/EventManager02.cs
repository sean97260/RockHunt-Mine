using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager02 : MonoBehaviour
{

    GameObject bag;
    GameObject character;
    GameObject granite;
    Animator dialogAnim;

    float offset;

    public bool waterUsed;
    public bool windUsed;

    // Use this for initialization
    void Start()
    {
        dialogAnim = GameObject.Find("Dialog generator").GetComponent<Animator>();
        bag = GameObject.Find("bag");
        character = GameObject.Find("Character");
        granite = GameObject.Find("SceneGranite");
    }

    // Update is called once per frame
    void Update()
    {

        if (granite != null && character.GetComponent<Collider2D>().IsTouching(granite.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript>().addObject(granite);
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
            granite.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            granite.SetActive(true);
        }
    }
}
