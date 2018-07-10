using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager05 : MonoBehaviour
{

    GameObject bag;
    GameObject character;
    GameObject sand_1;
    GameObject sand_2;
    GameObject sand_3;
    GameObject pitSand_1, pitSand_2, pitSand_3;
    GameObject sandstone;
    GameObject bottomCollider;
    Animator anim;

    float time;

    float offset;

    public bool waterUsed;
    public bool windUsed;

    // Use this for initialization
    void Start()
    {
        anim = GameObject.Find("Dialog generator").GetComponent<Animator>();
        bag = GameObject.Find("bag");
        character = GameObject.Find("Character");
        sand_1 = GameObject.Find("SceneSand");
        sand_2 = GameObject.Find("SceneSand (1)");
        sand_3 = GameObject.Find("SceneSand (2)");
        pitSand_1 = GameObject.Find("PitSand");
        pitSand_2 = GameObject.Find("PitSand (1)");
        pitSand_3 = GameObject.Find("PitSand (2)");
        sandstone = GameObject.Find("Sandstone");
        bottomCollider = GameObject.Find("BottomCollider");

        pitSand_1.SetActive(false);
        pitSand_2.SetActive(false);
        pitSand_3.SetActive(false);
        sandstone.SetActive(false);

        time = 5.0f;
    }

    void CheckSandPit(GameObject sand, GameObject bottom, GameObject pitSand) {
        if (sand.GetComponent<Collider2D>().IsTouching(bottom.GetComponent<Collider2D>())) {
            pitSand.SetActive(true);
            sand.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence")) {
            GameObject.Find("Dialog generator").GetComponent<Animator>().ResetTrigger("Space");
        }
        CheckSandPit(sand_1, bottomCollider, pitSand_1);
        CheckSandPit(sand_2, bottomCollider, pitSand_1);
        CheckSandPit(sand_3, bottomCollider, pitSand_1);
        CheckSandPit(sand_1, pitSand_1, pitSand_2);
        CheckSandPit(sand_2, pitSand_1, pitSand_2);
        CheckSandPit(sand_3, pitSand_1, pitSand_2);
        CheckSandPit(sand_1, pitSand_2, pitSand_3);
        CheckSandPit(sand_2, pitSand_2, pitSand_3);
        CheckSandPit(sand_3, pitSand_2, pitSand_3);
        if (sand_1 != null && character.GetComponent<Collider2D>().IsTouching(sand_1.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript>().addObject(sand_1);
        }

        if (sand_2 != null && character.GetComponent<Collider2D>().IsTouching(sand_2.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript>().addObject(sand_2);
        }
        if (sand_3 != null && character.GetComponent<Collider2D>().IsTouching(sand_3.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript>().addObject(sand_3);
        }
        if (pitSand_1 != null && character.GetComponent<Collider2D>().IsTouching(pitSand_1.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript>().addObject(sand_1);
            pitSand_1.SetActive(false);
        }
        if (pitSand_2 != null && character.GetComponent<Collider2D>().IsTouching(pitSand_2.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript>().addObject(sand_2);
            pitSand_2.SetActive(false);
        }
        if (pitSand_3 != null && character.GetComponent<Collider2D>().IsTouching(pitSand_3.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript>().addObject(sand_3);
            pitSand_3.SetActive(false);
        }
        if (pitSand_1.activeSelf && pitSand_2.activeSelf && pitSand_3.activeSelf)
        {
            time = time - Time.deltaTime;
            if (time <= 0f)
            {
                PutSandstone();
            }
        }
    }

    void PutSandstone() {
        sandstone.SetActive(true);
        GameObject.Find("Dialog generator").GetComponent<Animator>().SetTrigger("Sandstone");
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

        if (item.name == "SandIcon_3")
        {
            sand_3.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            sand_3.SetActive(true);
        }
    }
}
