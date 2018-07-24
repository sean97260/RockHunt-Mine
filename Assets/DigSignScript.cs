using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigSignScript : MonoBehaviour
{

    GameObject digInfo;

    GameObject character;

    GameObject cover;

    // Use this for initialization
    void Start()
    {
        cover = GameObject.Find("Cover");
        digInfo = GameObject.Find("DigInfo");
        character = GameObject.Find("Character");
        digInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (character.transform.position.x >= this.transform.position.x - 1 && character.transform.position.x <= this.transform.position.x + 1)
        {
            digInfo.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X)) {
                cover.SetActive(false);
            }
        }
        else
        {
            digInfo.SetActive(false);
        }
    }
}
