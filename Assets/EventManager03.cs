using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager03 : MonoBehaviour
{

    GameObject bag;
    GameObject character;
    GameObject granite_1;
    GameObject sand_1;
    GameObject sand_2;

    float offset;

    // Use this for initialization
    void Start()
    {
        bag = GameObject.Find("bag");
        character = GameObject.Find("Character");
        granite_1 = GameObject.Find("SceneGranite");
        sand_1 = GameObject.Find("SceneSand");
        if (sand_1 != null) { sand_1.SetActive(true); }

    }

    // Update is called once per frame
    void Update()
    {
        if (granite_1 != null && character.GetComponent<Collider2D>().IsTouching(granite_1.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript03>().addObject(granite_1);
        }
        if (sand_1 != null && character.GetComponent<Collider2D>().IsTouching(sand_1.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript03>().addObject(sand_1);
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

        if (item.name == "SandIcon_1")
        {
            granite_1.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            granite_1.SetActive(true);
        }

        if (item.name == "SandIcon_2")
        {
            sand_1.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            sand_1.SetActive(true);
        }
    }
}
