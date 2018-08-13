using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager06 : MonoBehaviour
{

    GameObject bag;
    GameObject character;
    GameObject granite_1;
    GameObject granite_2;
    GameObject sandstone_1;
    GameObject sandstone_2;
    GameObject metaq_1;
    GameObject metaq_2;
    GameObject magma_1;
    GameObject magma_2;
    Animator minerAnim;
    Animator minerDialogAnim;
    Animator researcherAnim;
    Animator researcherDialogAnim;

    float offset;

    public bool waterUsed;
    public bool windUsed;

    // Use this for initialization
    void Start()
    {
        
        bag = GameObject.Find("bag");
        character = GameObject.Find("Character");
        granite_1 = GameObject.Find("SceneGranite");
        granite_2 = GameObject.Find("SceneGranite (1)");
        sandstone_1 = GameObject.Find("SceneSandStone");
        sandstone_2 = GameObject.Find("SceneSandStone (1)");
        metaq_1 = GameObject.Find("SceneMetaq");
        metaq_2 = GameObject.Find("SceneMetaq (1)");
        magma_1 = GameObject.Find("SceneMagma_1");
        magma_2 = GameObject.Find("SceneMagma_2");

        if (magma_2 != null) { magma_2.SetActive(false); }
        if (magma_1 != null) { magma_1.SetActive(false); }
        if (granite_1 != null) { granite_1.SetActive(false); }
        if (granite_2 != null) { granite_2.SetActive(false); }
        if (metaq_1 != null) { metaq_1.SetActive(false); }
        if (metaq_2 != null) { metaq_2.SetActive(false); }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")) {
            SceneManager.LoadScene("Level06");
        }
        if (granite_1 != null && character.GetComponent<Collider2D>().IsTouching(granite_1.GetComponent<Collider2D>()))
        {
            if(granite_1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("magma")){
                granite_1.GetComponent<Animator>().SetBool("returnGranite", true);

            }
            bag.GetComponent<BagScript06>().addObject(granite_1);
        }

        if (granite_2 != null && character.GetComponent<Collider2D>().IsTouching(granite_2.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript06>().addObject(granite_2);
        }

        if (sandstone_1 != null && character.GetComponent<Collider2D>().IsTouching(sandstone_1.GetComponent<Collider2D>()))
        {
            
            bag.GetComponent<BagScript06>().addObject(sandstone_1);
        }

        if (sandstone_2 != null && character.GetComponent<Collider2D>().IsTouching(sandstone_2.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript06>().addObject(sandstone_2);
        }

        if (metaq_1 != null && character.GetComponent<Collider2D>().IsTouching(metaq_1.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript06>().addObject(metaq_1);
        }

        if (metaq_2 != null && character.GetComponent<Collider2D>().IsTouching(metaq_2.GetComponent<Collider2D>()))
        {
            bag.GetComponent<BagScript06>().addObject(metaq_2);
        }

        if (magma_1 != null && character.GetComponent<Collider2D>().IsTouching(magma_1.GetComponent<Collider2D>()))
        {
            
            bag.GetComponent<BagScript06>().addObject(magma_1);
        }

        if (magma_2 != null && character.GetComponent<Collider2D>().IsTouching(magma_2.GetComponent<Collider2D>()))
        {
            
            bag.GetComponent<BagScript06>().addObject(magma_2);
        }


    }

    public void takeFromBag(GameObject item)
    {
        if (character.GetComponent<ControllerScript_6>().facingRight == true)
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

        if (item.name == "SandStoneIcon_1")
        {
            sandstone_1.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            sandstone_1.SetActive(true);
        }

        if (item.name == "SandStoneIcon_2")
        {
            sandstone_2.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            sandstone_2.SetActive(true);
        }

        if (item.name == "MetaqIcon_1")
        {
            metaq_1.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            metaq_1.SetActive(true);
        }

        if (item.name == "MetaqIcon_2")
        {
            metaq_2.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            metaq_2.SetActive(true);
        }

        if (item.name == "MagmaIcon_1")
        {
            magma_1.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            magma_1.SetActive(true);
        }

        if (item.name == "MagmaIcon_2")
        {
            magma_2.transform.position = new Vector3(character.transform.position.x + offset, character.transform.position.y + 4f, character.transform.position.z);
            magma_2.SetActive(true);
        }

    }
}
