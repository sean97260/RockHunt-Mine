using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BagScript : MonoBehaviour
{

    GameObject grid;
    GameObject granite_1;
    GameObject granite_2;
    GameObject sand_1;
    GameObject sand_2;
    GameObject sand_3;

    GameObject select_1;
    GameObject select_2;
    GameObject select_3;
    GameObject select_4;

    GameObject eventManager;

    int iconLocator = 1;

    public bool bookOpened;
    int[] objectList = { 0, 0, 0, 0 };

    // Use this for initialization
    void Start()
    {
        eventManager = GameObject.Find("EventManager");
        granite_1 = GameObject.Find("GraniteIcon_1");
        granite_2 = GameObject.Find("GraniteIcon_2");
        sand_1 = GameObject.Find("SandIcon_1");
        sand_2 = GameObject.Find("SandIcon_2");
        sand_3 = GameObject.Find("SandIcon_3");
        select_1 = GameObject.Find("SelectIcon_1");
        select_2 = GameObject.Find("SelectIcon_2");
        select_3 = GameObject.Find("SelectIcon_3");
        select_4 = GameObject.Find("SelectIcon_4");

        Erase(granite_1);
        Erase(granite_2);
        Erase(sand_1);
        Erase(sand_2);
        Erase(sand_3);
        Erase(select_4);
        Erase(select_2);
        Erase(select_3);

        grid = GameObject.Find("InventoryGrid");
        CloseBook();
    }

    void Erase(GameObject obj) {
        if (obj != null) {
            obj.SetActive(false);
        }
    }

    void Put(GameObject obj) {
        if (obj != null) {
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
        Erase(select_1);
        Erase(select_2);
        Erase(select_3);
        Erase(select_4);

        grid.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Level05")
        {
            if ((int)objectList.GetValue(0) == 1)
            {
                Erase(sand_1);
            }
            if ((int)objectList.GetValue(1) == 1)
            {
                Erase(sand_2);
            }

            if ((int)objectList.GetValue(2) == 1)
            {
                Erase(sand_3);
            }
        }
        else
        {
            if ((int)objectList.GetValue(0) == 1)
            {
                Erase(granite_1);
            }
            if ((int)objectList.GetValue(1) == 1)
            {
                Erase(granite_2);
            }
        }

        if ((int)objectList.GetValue(2) == 1)
        {
            Erase(sand_1);
        }

        if ((int)objectList.GetValue(3) == 1)
        {
            Erase(sand_2);
        }
        bookOpened = false;
    }

    public void OpenBook()
    {
        print(objectList.GetValue(0));
        print(objectList.GetValue(1));
        grid.SetActive(true);
        if (SceneManager.GetActiveScene().name == "Level05")
        {
            if ((int)objectList.GetValue(0) == 1)
            {
                Put(sand_1);
            }
            if ((int)objectList.GetValue(1) == 1)
            {
                Put(sand_2);
            }
            if ((int)objectList.GetValue(2) == 1)
            {
                Put(sand_3);
            }
        }
        else
        {
            if ((int)objectList.GetValue(0) == 1)
            {
                Put(granite_1);
            }
            if ((int)objectList.GetValue(1) == 1)
            {
                Put(granite_2);
            }
            if ((int)objectList.GetValue(2) == 1)
            {
                Put(sand_1);
            }
            if ((int)objectList.GetValue(3) == 1)
            {
                Put(sand_2);
            }
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
                    CloseBook();
                }
                else
                {
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
                Put(select_1);
            }
            else if (iconLocator == 2)
            {
                Put(select_2);
            }
            else if (iconLocator == 3)
            {
                Put(select_3);
            }
            else if (iconLocator >= 4)
            {
                Put(select_4);
            }
        }
        else
        {
            Erase(select_1);
            Erase(select_2);
            Erase(select_3);
            Erase(select_4);
        }
    }

    public void addObject(GameObject item)
    {
        if (SceneManager.GetActiveScene().name == "Level05")
        {
            if (item.name == "SceneSand")
            {
                objectList.SetValue(1, 0);
                item.SetActive(false);
            }
            if (item.name == "SceneSand (1)")
            {
                objectList.SetValue(1, 1);
                item.SetActive(false);
            }

            if (item.name == "SceneSand (2)")
            {
                objectList.SetValue(1, 2);
                item.SetActive(false);
            }
        }
        else
        {
            if (item.name == "SceneGranite")
            {
                print("get");
                if (item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SandShowUp"))
                {
                    objectList.SetValue(0, 0);
                    objectList.SetValue(1, 2);
                }
                else
                {
                    objectList.SetValue(1, 0);
                }
                item.SetActive(false);
            }
            if (item.name == "SceneGranite (1)")
            {
                print("get");
                if (item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SandShowUp"))
                {
                    objectList.SetValue(0, 1);
                    objectList.SetValue(1, 3);
                }
                else
                {
                    objectList.SetValue(1, 1);
                }
                item.SetActive(false);
            }

            if (item.name == "SceneSand")
            {
                print("herehere");
                objectList.SetValue(1, 2);
                item.SetActive(false);
            }

            if (item.name == "SceneSand (1)")
            {
                objectList.SetValue(1, 3);
                item.SetActive(false);
            }
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

        if (direction == "left" && iconLocator >= 1)
        {
            iconLocator -= 1;
        }

        if (direction == "right" && iconLocator <= 4)
        {
            iconLocator += 1;
        }
    }

    void dropItem()
    {
        if (SceneManager.GetActiveScene().name == "Level05")
        {
            if (iconLocator <= 1 && GameObject.Find("SceneSand") == null && sand_1.activeSelf == true)
            {
                sand_1.SetActive(false);
                objectList.SetValue(0, 0);
                eventManager.GetComponent<EventManager05>().takeFromBag(sand_1);
            }
            else if (iconLocator == 2 && GameObject.Find("SceneSand (1)") == null && sand_2.activeSelf == true)
            {
                sand_2.SetActive(false);
                objectList.SetValue(0, 1);
                eventManager.GetComponent<EventManager05>().takeFromBag(sand_2);
            }
            else if (iconLocator == 3 && sand_3.activeSelf == true)
            {
                sand_3.SetActive(false);
                objectList.SetValue(0, 2);
                eventManager.GetComponent<EventManager05>().takeFromBag(sand_3);
            }
        }
        else
        {
            if (iconLocator <= 1 && GameObject.Find("SceneGranite") == null && granite_1.activeSelf == true)
            {
                granite_1.SetActive(false);
                objectList.SetValue(0, 0);
                if (eventManager.GetComponent<EventManager03>() != null)
                {
                    eventManager.GetComponent<EventManager03>().takeFromBag(granite_1);
                }
                else
                {
                    eventManager.GetComponent<EventManager>().takeFromBag(granite_1);
                }
            }
            else if (iconLocator == 2 && GameObject.Find("SceneGranite (1)") == null && granite_2.activeSelf == true)
            {
                granite_2.SetActive(false);
                objectList.SetValue(0, 1);
                if (eventManager.GetComponent<EventManager03>() != null)
                {
                    eventManager.GetComponent<EventManager03>().takeFromBag(granite_2);
                }
                else
                {
                    eventManager.GetComponent<EventManager>().takeFromBag(granite_2);
                }
            }
            else if (iconLocator == 3 && sand_1.activeSelf == true)
            {
                sand_1.SetActive(false);
                objectList.SetValue(0, 2);
                if (eventManager.GetComponent<EventManager03>() != null)
                {
                    eventManager.GetComponent<EventManager03>().takeFromBag(sand_1);
                }
                else
                {
                    eventManager.GetComponent<EventManager>().takeFromBag(sand_1);
                }
            }
            else if (iconLocator >= 4 && sand_2.activeSelf == true)
            {
                sand_2.SetActive(false);
                objectList.SetValue(0, 3);
                if (eventManager.GetComponent<EventManager03>() != null)
                {
                    eventManager.GetComponent<EventManager03>().takeFromBag(sand_2);
                }
                else
                {
                    eventManager.GetComponent<EventManager>().takeFromBag(sand_2);
                }
            }
        }

        CloseBook();
    }

}
