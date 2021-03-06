﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript05 : MonoBehaviour
{

    GameObject grid;
    GameObject granite;
    GameObject sand_1, sand_2, sand_3;
    GameObject sandstone;

    GameObject select_1, select_2, select_3, select_4, select_5;

    GameObject eventManager;

    GameObject graniteInfo, sandInfo, sandstoneInfo;

    public bool sandstoneInBag;

    public bool stopMoving;

    int iconLocator = 1;

    public bool bookOpened;
    int[] objectList = { 0, 0, 0, 0, 0};

    // Use this for initialization
    void Start()
    {
        eventManager = GameObject.Find("EventManager");
        granite = GameObject.Find("GraniteIcon_1");
        sand_1 = GameObject.Find("SandIcon_1");
        sand_2 = GameObject.Find("SandIcon_2");
        sand_3 = GameObject.Find("SandIcon_3");
        sandstone = GameObject.Find("SandstoneIcon");
        select_1 = GameObject.Find("SelectIcon_1");
        select_2 = GameObject.Find("SelectIcon_2");
        select_3 = GameObject.Find("SelectIcon_3");
        select_4 = GameObject.Find("SelectIcon_4");
        select_5 = GameObject.Find("SelectIcon_5");

        sandInfo = GameObject.Find("SandInfo");
        graniteInfo = GameObject.Find("graniteInfo");
        sandstoneInfo = GameObject.Find("SandstoneInfo");
        sandInfo.SetActive(false);
        graniteInfo.SetActive(false);

        Erase(granite);
        Erase(sand_1);
        Erase(sand_2);
        Erase(sand_3);
        Erase(sandstone);

        Erase(select_4);
        Erase(select_2);
        Erase(select_3);
        Erase(select_5);

        grid = GameObject.Find("InventoryGrid");
        CloseBook();

        stopMoving = false;
    }

    void Erase(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(false);
        }
    }

    void Put(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(true);
        }
    }


    void OnMouseDown()
    {
        if (GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence")
            || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 0")
            || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 1")
            || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 2")
            || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 3"))
        {
            if (bookOpened)
            {
                CloseBook();
            }
            else
            {
                OpenBook();
            }
        }
    }

    public void CloseBook()
    {
        stopMoving = false;
        Erase(select_1);
        Erase(select_2);
        Erase(select_3);
        Erase(select_4);
        Erase(select_5);

        grid.SetActive(false);
        if ((int)objectList.GetValue(0) == 1)
        {
            Erase(granite);
        }
        if ((int)objectList.GetValue(1) == 1)
        {
            Erase(sand_1);
        }

        if ((int)objectList.GetValue(2) == 1)
        {
            Erase(sand_2);
        }

        if ((int)objectList.GetValue(3) == 1)
        {
            Erase(sand_3);
        }

        if ((int)objectList.GetValue(4) == 1) {
            Erase(sandstone);
        }
        bookOpened = false;
    }

    public void OpenBook()
    {
        stopMoving = true;
        grid.SetActive(true);
        if ((int)objectList.GetValue(0) == 1)
        {
            Put(granite);
        }
        if ((int)objectList.GetValue(1) == 1)
        {
            Put(sand_1);
        }
        if ((int)objectList.GetValue(2) == 1)
        {
            Put(sand_2);
        }
        if ((int)objectList.GetValue(3) == 1)
        {
            Put(sand_3);
        }
        if ((int)objectList.GetValue(4) == 1)
        {
            Put(sandstone);
        }
        bookOpened = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence")
               || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 0")
                || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 1")
                || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 2")
                || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 3")
                || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 4")
                || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 5")
                || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 2 0")
                || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 1 0")
                || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 3 0")
               || GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("portal"))
            {
                if (bookOpened)
                {
                    stopMoving = false;
                    CloseBook();
                }
                else
                {
                    stopMoving = true;
                    OpenBook();
                }
            }
        }

        if (GameObject.Find("Dialog generator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Silence 1"))
        {
            GameObject.Find("Dialog generator").GetComponent<Animator>().ResetTrigger("Space");
        }

        if (this.GetComponent<Animator>().GetBool("closeBook") == true)
        {
            this.GetComponent<Animator>().SetBool("closeBook", false);
            OnMouseDown();
        }

        if (bookOpened == true)
        {
            stopMoving = false;
            if (Input.GetKeyDown("space"))
            {
                dropItem();
            }
            if (Input.GetKeyDown("left"))
            {
                moveSelectIcon("left");
            }
            if (Input.GetKeyDown("right"))
            {
                moveSelectIcon("right");
            }

            if (iconLocator <= 1)
            {
                if (GameObject.Find("SceneGranite") == null && granite.activeSelf)
                {
                    sandInfo.SetActive(false);
                    graniteInfo.SetActive(true);
                    sandstoneInfo.SetActive(false);
                }
                Put(select_1);
            }
            else if (iconLocator == 2)
            {
                if (GameObject.Find("SceneGranite") == null && granite.activeSelf)
                {
                    sandInfo.SetActive(false);
                    graniteInfo.SetActive(true);
                    sandstoneInfo.SetActive(false);
                }
                Put(select_2);
            }
            else if (iconLocator == 3)
            {
                if (GameObject.Find("SceneSand") == null && sand_1.activeSelf)
                {
                    sandInfo.SetActive(true);
                    graniteInfo.SetActive(false);
                    sandstoneInfo.SetActive(false);
                }

                Put(select_3);
            }
            else if (iconLocator == 4)
            {
                if (GameObject.Find("SceneSand (1)") == null && sand_2.activeSelf)
                {
                    sandInfo.SetActive(true);
                    graniteInfo.SetActive(false);
                    sandstoneInfo.SetActive(false);
                }
                Put(select_4);
            }
            else if (iconLocator >= 5) {
                if (GameObject.Find("Sandstone") == null && sandstone.activeSelf)
                {
                    sandstoneInfo.SetActive(true);
                    graniteInfo.SetActive(false);
                    sandInfo.SetActive(false);
                }
                Put(select_5);
            }
        }
        else
        {
            stopMoving = true;
            sandInfo.SetActive(false);
            graniteInfo.SetActive(false);
            sandstoneInfo.SetActive(false);
            Erase(select_1);
            Erase(select_2);
            Erase(select_3);
            Erase(select_4);
            Erase(select_5);
        }
    }

    public void addObject(GameObject item)
    {
        if (item.name == "SceneGranite")
        {
            if (eventManager.GetComponent<EventManager05>().graniteTransformed) {
                item.SetActive(true);
                item.GetComponent<Animator>().Play("SandShowUp");
                Debug.Log("HERE");
            }
            Debug.Log(item.activeSelf);
            item.GetComponent<Animator>().Play("SandShowUp");
            Debug.Log(item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SandShowUp"));
            if (item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SandShowUp"))
            {
                Debug.Log("granite is transformed");
                objectList.SetValue(0, 0);
                objectList.SetValue(1, 1);
            }
            else
            {
                Debug.Log("granite is the same");
                objectList.SetValue(1, 0);
            }
            item.SetActive(false);
        }
        if (item.name == "SceneSand")
        {
            objectList.SetValue(1, 2);
            item.SetActive(false);
        }

        if (item.name == "SceneSand (1)")
        {
            objectList.SetValue(1, 3);
            item.SetActive(false);
        }
        if (item.name == "Sandstone")
        {
            objectList.SetValue(0, 3);
            objectList.SetValue(1, 4);
            item.SetActive(false);
            sandstoneInBag = true;
        }
        int pos;
        if (item.name == "PitSand (2)")
        {
            pos = eventManager.GetComponent<EventManager05>().sand3Order;
            objectList.SetValue(1, pos);
            item.SetActive(false);
        }

        if (item.name == "PitSand (1)")
        {
            pos = eventManager.GetComponent<EventManager05>().sand2Order;

            objectList.SetValue(1, pos);
            item.SetActive(false);
        }
        if (item.name == "PitSand")
        {
            pos = eventManager.GetComponent<EventManager05>().sand1Order;

            objectList.SetValue(1, pos);
            item.SetActive(false);
        }
    }

    void moveSelectIcon(string direction)
    {
        if (iconLocator == 1)
        {
            select_1.SetActive(false);
        }
        else if (iconLocator == 2)
        {
            select_2.SetActive(false);
        }
        else if (iconLocator == 3)
        {
            select_3.SetActive(false);
        }
        else if (iconLocator == 4)
        {
            select_4.SetActive(false);
        }
        else if (iconLocator == 5)
        {
            select_5.SetActive(false);
        }

        if (direction == "left" && iconLocator > 1)
        {
            iconLocator -= 1;
        }

        if (direction == "right" && iconLocator < 5)
        {
            iconLocator += 1;
        }
    }

    void dropItem()
    {
        if (iconLocator <= 1 && GameObject.Find("SceneGranite") == null && granite.activeSelf)
        {
            RemoveAndTake(granite, 0);
        }
        else if (iconLocator == 2 && sand_1.activeSelf)
        {
            RemoveAndTake(sand_1, 1);
        }
        else if (iconLocator == 3 && sand_2.activeSelf)
        {
            RemoveAndTake(sand_2, 2);
        }
        else if (iconLocator == 4 && sand_3.activeSelf)
        {
            RemoveAndTake(sand_3, 3);
        }
        else if (iconLocator >= 5 && sandstone.activeSelf) {
            RemoveAndTake(sandstone, 4);
            sandstoneInBag = false;
        }
        CloseBook();
    }

    void RemoveAndTake(GameObject item, int position)
    {
        item.SetActive(false);
        objectList.SetValue(0, position);
        eventManager.GetComponent<EventManager05>().takeFromBag(item);
    }

}
