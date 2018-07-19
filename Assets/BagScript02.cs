using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript02 : MonoBehaviour
{

    GameObject grid;
    GameObject granite_1;
    GameObject granite_2;
    GameObject sand_1;
    GameObject sand_2;

    GameObject select_1;
    GameObject select_2;
    GameObject select_3;
    GameObject select_4;

    GameObject eventManager;

    GameObject graniteInfo;
    GameObject sandInfo;

    public bool twosand;

    public bool sandTransformed;

    public bool stopMoving;

    int iconLocator = 1;

    public bool bookOpened;
    int[] objectList = { 0, 0, 0, 0 };

    // Use this for initialization
    void Start()
    {
        eventManager = GameObject.Find("EventManager");
        granite_1 = GameObject.Find("GraniteIcon_1");
        sand_1 = GameObject.Find("SandIcon_1");
        select_1 = GameObject.Find("SelectIcon_1");
        select_2 = GameObject.Find("SelectIcon_2");
        select_3 = GameObject.Find("SelectIcon_3");
        select_4 = GameObject.Find("SelectIcon_4");

        sandInfo = GameObject.Find("SandInfo");
        graniteInfo = GameObject.Find("graniteInfo");
        Erase(sandInfo);
        Erase(graniteInfo);

        Erase(granite_1);
        Erase(sand_1);
        Erase(select_4);
        Erase(select_2);
        Erase(select_3);

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
            if (bookOpened)
            {
                CloseBook();
            }
            else
            {
                OpenBook();
            }
    }

    public void CloseBook()
    {
        stopMoving = false;
        Erase(select_1);
        Erase(select_2);
        Erase(select_3);
        Erase(select_4);

        grid.SetActive(false);
        if ((int)objectList.GetValue(0) == 1)
        {
            Erase(granite_1);
        }

        if ((int)objectList.GetValue(1) == 1)
        {
            Erase(sand_1);
        }

        bookOpened = false;
    }

    public void OpenBook()
    {
        stopMoving = true;
        grid.SetActive(true);
        if ((int)objectList.GetValue(0) == 1)
        {
            Put(granite_1);
        }
        if ((int)objectList.GetValue(1) == 1)
        {
            Put(sand_1);
        }
        bookOpened = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
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
                if (GameObject.Find("SceneGranite") == null && granite_1 && granite_1.activeSelf == true)
                {
                    Erase(sandInfo);
                    Put(graniteInfo);
                }
                Put(select_1);
            }
            else if (iconLocator == 2)
            {
                if (GameObject.Find("SceneSand") == null && sand_1 && sand_1.activeSelf == true)
                {
                    Put(sandInfo);
                    Erase(graniteInfo);
                }

                Put(select_2);
            }
            else if (iconLocator == 3)
            {
                Put(select_3);
            }
            else if (iconLocator == 4) {
                Put(select_4);
            }
        }
        else
        {
            stopMoving = true;
            Erase(sandInfo);
            Erase(graniteInfo);
            Erase(select_1);
            Erase(select_2);
            Erase(select_3);
            Erase(select_4);
        }

     }

    public void addObject(GameObject item)
    {
        if (item.name == "SceneGranite")
        {
            if (item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SandShowUp"))
            {
                sandTransformed = true;
                GameObject.Find("WizardDialog").GetComponent<Animator>().SetBool("Sand", true);
                objectList.SetValue(0, 0);
                objectList.SetValue(1, 1);
            }
            else
            {
                objectList.SetValue(1, 0);
            }
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

        if (direction == "left" && iconLocator > 1)
        {
            iconLocator -= 1;
        }

        if (direction == "right" && iconLocator < 4)
        {
            iconLocator += 1;
        }
    }

    void dropItem()
    {
        if (iconLocator <= 1 && GameObject.Find("SceneGranite") == null && granite_1.activeSelf == true)
        {
            CheckAndTake(granite_1, 0);
        }
        else if (iconLocator == 2 && sand_1.activeSelf == true)
        {
            GameObject.Find("WizardDialog").GetComponent<Animator>().SetBool("Sand", false);
            CheckAndTake(sand_1, 1);
        }
        CloseBook();
    }

    void CheckAndTake(GameObject item, int position)
    {
        item.SetActive(false);
        objectList.SetValue(0, position);
        eventManager.GetComponent<EventManager02>().takeFromBag(item);
    }

}
