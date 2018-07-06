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

    // Use this for initialization
    void Start()
    {
        bag = GameObject.Find("bag");
        character = GameObject.Find("Character");
        granite_1 = GameObject.Find("SceneGranite");
        sand_1 = GameObject.Find("SceneSand");
        sand_2 = GameObject.Find("SceneSand (1)");
        if (sand_1 != null) { sand_1.SetActive(true); }
        Debug.Log(sand_1 == null);
        if (sand_2 != null) { sand_2.SetActive(true); }

    }

    // Update is called once per frame
    void Update()
    {
        if (granite_1 != null && character.GetComponent<Collider2D>().IsTouching(granite_1.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript>().addObject(granite_1);
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
    }

    public void takeFromBag(GameObject item)
    {
        if (item.name == "GraniteIcon_1")
        {
            granite_1.transform.position = new Vector3(character.transform.position.x + 2.3f, character.transform.position.y + 4f, character.transform.position.z);
            granite_1.SetActive(true);
        }

        if (item.name == "SandIcon_1")
        {
            sand_1.transform.position = new Vector3(character.transform.position.x + 2.3f, character.transform.position.y + 4f, character.transform.position.z);
            if (sand_1 != null) { sand_1.SetActive(true); }
        }

        if (item.name == "SandIcon_2")
        {
            sand_2.transform.position = new Vector3(character.transform.position.x + 2.3f, character.transform.position.y + 4f, character.transform.position.z);
            if (sand_2 != null) { sand_2.SetActive(true); }
        }
    }
}
