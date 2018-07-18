using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager05 : MonoBehaviour
{

    GameObject bag;
    GameObject character;
    GameObject sand_1, sand_2, sand_3;
    GameObject granite;
    GameObject pitSand_1, pitSand_2, pitSand_3;

    public int sand1Order, sand2Order, sand3Order; // Keep track of which pile is associated with which pit

    GameObject sandstone;
    GameObject bottomCollider;
    Animator anim;

    float time;

    float offset;

    public bool waterUsed;
    public bool windUsed;

    public bool graniteTransformed = false;

    // Use this for initialization
    void Start()
    {
        anim = GameObject.Find("Dialog generator").GetComponent<Animator>();
        bag = GameObject.Find("bag");
        character = GameObject.Find("Character");
        sand_1 = null;
        sand_2 = GameObject.Find("SceneSand");
        sand_3 = GameObject.Find("SceneSand (1)");
        granite = GameObject.Find("SceneGranite");
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
        if (sand == null || bottom == null || pitSand == null) {
            return;
        }
        if (sand.GetComponent<Collider2D>().IsTouching(bottom.GetComponent<Collider2D>())) {
            if (bottom.name == "BottomCollider")
            {
                if (sand.name == "SceneSand")
                {
                    sand2Order = 1;
                }
                else if (sand.name == "SceneSand (1)")
                {
                    sand3Order = 1;
                }
                else if (sand.name == "SceneGranite") {
                    sand1Order = 1;
                }
            }
            else if (bottom.name == "PitSand")
            {
                if (sand.name == "SceneSand")
                {
                    sand2Order = 2;
                }
                else if (sand.name == "SceneSand (1)")
                {
                    sand3Order = 2;
                }
                else if (sand.name == "SceneGranite")
                {
                    sand1Order = 2;
                }
            }
            else if (bottom.name == "PitSand (1)") {
                if (sand.name == "SceneSand")
                {
                    sand2Order = 3;
                }
                else if (sand.name == "SceneSand (1)")
                {
                    sand3Order = 3;
                }
                else if (sand.name == "SceneGranite")
                {
                    sand1Order = 3;
                }
            }
            pitSand.SetActive(true);
            sand.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sand_1 != null)
        {
            sand_1.GetComponent<Animator>().Play("SandShowUp");
        }

        if (granite != null && granite.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SandShowUp")) {
            sand_1 = granite;
            graniteTransformed = true;
            granite = null;
        }
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

        CheckAndAdd(granite);
        CheckAndAdd(sand_1);
        CheckAndAdd(sand_2);
        CheckAndAdd(sand_3);

        CheckAndAdd(sandstone);

        if (pitSand_1 != null && character.GetComponent<Collider2D>().IsTouching(pitSand_1.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript05>().addObject(pitSand_1);
            pitSand_1.SetActive(false);
        }
        if (pitSand_2 != null && character.GetComponent<Collider2D>().IsTouching(pitSand_2.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript05>().addObject(pitSand_2);
            pitSand_2.SetActive(false);
        }
        if (pitSand_3 != null && character.GetComponent<Collider2D>().IsTouching(pitSand_3.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript05>().addObject(pitSand_3);
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

    void CheckAndAdd(GameObject item) {
        if (item != null && character.GetComponent<Collider2D>().IsTouching(item.GetComponent<Collider2D>()))
        {
            Debug.Log(item.name);
            bag.GetComponent<BagScript05>().addObject(item);
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

        Debug.Log(item.name);

         if (sand_1 != null && item.name == "SandIcon_1")
        {
            sand_1.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            sand_1.SetActive(true);
        }

        if (sand_2 != null && item.name == "SandIcon_2")
        {
            sand_2.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            sand_2.SetActive(true);
        }

        if (sand_3 != null && item.name == "SandIcon_3")
        {
            sand_3.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            sand_3.SetActive(true);
        }

        if (granite != null &&  item.name == "GraniteIcon_1")
        {
            granite.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            granite.SetActive(true);
        }

        if (sandstone != null && item.name == "SandstoneIcon")
        {
            sandstone.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            sandstone.SetActive(true);
        }
    }
}
