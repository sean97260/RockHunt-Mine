using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager02 : MonoBehaviour
{

    GameObject bag;
    GameObject character;
    GameObject granite;
    GameObject sand_1;
    Animator dialogAnim;

    float offset;

    // Use this for initialization
    void Start()
    {
        bag = GameObject.Find("bag");
        character = GameObject.Find("Character");
        granite = GameObject.Find("SceneGranite");
        sand_1 = null;

    }

    // Update is called once per frame
    void Update()
    {
        if (granite != null && character.GetComponent<Collider2D>().IsTouching(granite.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript02>().addObject(granite);
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
        if (granite && item.name == "SandIcon_1")
        {
            granite.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            granite.SetActive(true);
        }

    }
}
