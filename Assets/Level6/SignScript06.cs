using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignScript06 : MonoBehaviour
{

    GameObject moveInfo;
    GameObject spaceInfo;
    GameObject shiftInfo;
    GameObject restart;

    GameObject character;

    // Use this for initialization
    void Start()
    {
        moveInfo = GameObject.Find("move info");
        spaceInfo = GameObject.Find("space info");
        shiftInfo = GameObject.Find("shift info");
        character = GameObject.Find("Character");
        restart = GameObject.Find("restart");
        moveInfo.SetActive(false);
        spaceInfo.SetActive(false);
        shiftInfo.SetActive(false);
        restart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (character.transform.position.x >= this.transform.position.x - 1 && character.transform.position.x <= this.transform.position.x + 1)
        {
            moveInfo.SetActive(true);
            spaceInfo.SetActive(true);
            shiftInfo.SetActive(true);
            restart.SetActive(true);
        }
        else
        {
            moveInfo.SetActive (false);   
            spaceInfo.SetActive(false);
            shiftInfo.SetActive(false);
            restart.SetActive(false);
        }
    }
}
