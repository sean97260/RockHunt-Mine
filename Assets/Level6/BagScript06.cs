using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript06 : MonoBehaviour
{

    GameObject grid;
    GameObject granite_1;
    GameObject granite_2;
    GameObject sandstone_1;
    GameObject sandstone_2;
    GameObject metaq_1;
    GameObject metaq_2;
    GameObject magma_1;
    GameObject magma_2;

    GameObject select_1;
    GameObject select_2;
    GameObject select_3;
    GameObject select_4;
    GameObject select_5;
    GameObject select_6;
    GameObject select_7;
    GameObject select_8;

    GameObject eventManager;

    GameObject graniteInfo;
    GameObject magmaInfo;
    GameObject metaqInfo;
    GameObject sandstoneInfo;

    public bool twogranite;
    public bool twometaq;
    public bool twomagma;

    public bool stopMoving;

    int iconLocator = 1;

    public bool bookOpened;
    int[] objectList = { 0, 0, 0, 0 ,0, 0, 0, 0};

    // Use this for initialization
    void Start()
    {
        eventManager = GameObject.Find("EventManager");
        granite_1 = GameObject.Find("GraniteIcon_1");
        granite_2 = GameObject.Find("GraniteIcon_2");
        sandstone_1 = GameObject.Find("SandStoneIcon_1");
        sandstone_2 = GameObject.Find("SandStoneIcon_2");
        metaq_1 = GameObject.Find("MetaqIcon_1");
        metaq_2 = GameObject.Find("MetaqIcon_2");
        magma_1 = GameObject.Find("MagmaIcon_1");
        magma_2 = GameObject.Find("MagmaIcon_2");

        select_1 = GameObject.Find("SelectIcon_1");
        select_2 = GameObject.Find("SelectIcon_2");
        select_3 = GameObject.Find("SelectIcon_3");
        select_4 = GameObject.Find("SelectIcon_4");
        select_5 = GameObject.Find("SelectIcon_5");
        select_6 = GameObject.Find("SelectIcon_6");
        select_7 = GameObject.Find("SelectIcon_7");
        select_8 = GameObject.Find("SelectIcon_8");


        graniteInfo = GameObject.Find("graniteInfo");
        magmaInfo = GameObject.Find("MagmaInfo");
        metaqInfo = GameObject.Find("MetaqInfo");
        sandstoneInfo = GameObject.Find("SandstoneInfo");

        graniteInfo.SetActive(false);

        Erase(magmaInfo);
        Erase(metaqInfo);
        Erase(sandstoneInfo);

        Erase(granite_1);
        Erase(granite_2);
        Erase(sandstone_1);
        Erase(sandstone_2);
        Erase(metaq_2);
        Erase(metaq_1);
        Erase(magma_1);
        Erase(magma_2);
        Erase(select_4);
        Erase(select_2);
        Erase(select_3);
        Erase(select_5);
        Erase(select_6);
        Erase(select_1);
        Erase(select_7);
        Erase(select_8);


        grid = GameObject.Find("InventoryGrid");
        CloseBook();

        stopMoving = false;
        print("start");
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
        Erase(select_5);
        Erase(select_6);
        Erase(select_7);
        Erase(select_8);

        grid.SetActive(false);
        if ((int)objectList.GetValue(0) == 1)
        {
            Erase(sandstone_1);
        }
        if ((int)objectList.GetValue(1) == 1)
        {
            Erase(sandstone_2);
        }

        if ((int)objectList.GetValue(2) == 1)
        {
            Erase(metaq_1);
        }

        if ((int)objectList.GetValue(3) == 1)
        {
            Erase(metaq_2);
        }
        if ((int)objectList.GetValue(4) == 1)
        {
            Erase(granite_1);
        }

        if ((int)objectList.GetValue(5) == 1)
        {
            Erase(granite_2);
        }
        if ((int)objectList.GetValue(6) == 1)
        {
            Erase(magma_1);
        }
        if ((int)objectList.GetValue(7) == 1)
        {
            Erase(magma_2);
        }


        bookOpened = false;
    }

    public void OpenBook()
    {
        stopMoving = true;
        grid.SetActive(true);
        if ((int)objectList.GetValue(0) == 1)
        {
            Put(sandstone_1);
        }
        if ((int)objectList.GetValue(1) == 1)
        {
            Put(sandstone_2);
        }
        if ((int)objectList.GetValue(2) == 1)
        {
            Put(metaq_1);
        }
        if ((int)objectList.GetValue(3) == 1)
        {
            Put(metaq_2);
        }
        if ((int)objectList.GetValue(4) == 1)
        {
            Put(granite_1);
        }
        if ((int)objectList.GetValue(5) == 1)
        {
            Put(granite_2);
        }
        if ((int)objectList.GetValue(6) == 1)
        {
            Put(magma_1);
        }
        if ((int)objectList.GetValue(7) == 1)
        {
            Put(magma_2);
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
                if (GameObject.Find("SceneSandStone") == null && sandstone_1.activeSelf == true)
                {
                    Put(sandstoneInfo);
                    //sandInfo.SetActive(false);
                    //graniteInfo.SetActive(true);
                }
                Put(select_1);
            }
            else if (iconLocator == 2)
            {
                if (GameObject.Find("SceneSandStone (1)") == null && sandstone_2.activeSelf == true)
                {
                    Erase(metaqInfo);
                    Put(sandstoneInfo);
                    //sandInfo.SetActive(false);
                    //graniteInfo.SetActive(true);
                }
                Put(select_2);
            }
            else if (iconLocator == 3)
            {
                if (GameObject.Find("SceneMetaq") == null && metaq_1.activeSelf == true)
                {
                    //sandInfo.SetActive(true);
                    //graniteInfo.SetActive(false);
                    Put(metaqInfo);
                }

                Put(select_3);
            }
            else if (iconLocator == 4)
            {
                if (GameObject.Find("SceneMetaq (1)") == null && metaq_2.activeSelf == true)
                {
                    //sandInfo.SetActive(true);
                    //graniteInfo.SetActive(false);
                    Put(metaqInfo);
                    Erase(graniteInfo);
                }
                Put(select_4);
            }
            else if (iconLocator == 5)
            {
                if (GameObject.Find("SceneGranite") == null && granite_1.activeSelf == true)
                {
                    //sandInfo.SetActive(true);
                    //graniteInfo.SetActive(false);
                    Erase(metaqInfo);
                    Put(graniteInfo);
                }
                Put(select_5);
            }
            else if (iconLocator == 6)
            {
                if (GameObject.Find("SceneGranite (1)") == null && granite_2.activeSelf == true)
                {
                    //sandInfo.SetActive(true);
                    //graniteInfo.SetActive(false);
                    Put(graniteInfo);
                    Erase(magmaInfo);
                }
                Put(select_6);
            }
            else if (iconLocator == 7)
            {
                if (GameObject.Find("SceneMagma") == null && magma_1.activeSelf == true)
                {
                    //sandInfo.SetActive(true);
                    //graniteInfo.SetActive(false);
                    Erase(graniteInfo);
                    Put(magmaInfo);
                }
                Put(select_7);
            }
            else if (iconLocator == 8)
            {
                if (GameObject.Find("SceneMagma (1)") == null && magma_2.activeSelf == true)
                {
                    //sandInfo.SetActive(true);
                    //graniteInfo.SetActive(false);
                    
                }
                Put(select_8);
            }
        }
        else
        {
            stopMoving = true;
            //sandInfo.SetActive(false);
            //graniteInfo.SetActive(false);
            Erase(select_1);
            Erase(select_2);
            Erase(select_3);
            Erase(select_4);
            Erase(select_5);
            Erase(select_6);
            Erase(select_7);
            Erase(select_8);

            Erase(graniteInfo);
            Erase(metaqInfo);
            Erase(magmaInfo);
            Erase(sandstoneInfo);

        }

        if ((int)objectList.GetValue(4) == 1 && (int)objectList.GetValue(5) == 1)
        {
            twogranite = true;
        }
        else
        {
            twogranite = false;
        }

        if ((int)objectList.GetValue(2) == 1 && (int)objectList.GetValue(3) == 1)
        {
            twometaq = true;
        }
        else
        {
            twometaq = false;
        }

        if ((int)objectList.GetValue(6) == 1 && (int)objectList.GetValue(7) == 1)
        {
            twomagma = true;
        }
        else
        {
            twomagma = false;
        }


    }

    public void addObject(GameObject item)
    {
        if (item.name == "SceneGranite")
        {
            print("get");
            if (item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("magma"))
            {
                objectList.SetValue(0, 4);
                objectList.SetValue(1, 6);
            }
            else
            {
                objectList.SetValue(1, 4);
            }
            item.SetActive(false);
        }
        if (item.name == "SceneGranite (1)")
        {
            print("get");
            if (item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("magma"))
            {
                objectList.SetValue(0, 5);
                objectList.SetValue(1, 7);
            }
            else
            {
                objectList.SetValue(1, 5);
            }
            item.SetActive(false);
        }

        if (item.name == "SceneSandStone")
        {
            if (item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("metaq"))
            {
                objectList.SetValue(0, 0);
                objectList.SetValue(1, 2);
                item.SetActive(false);
            }
            else
            {
                objectList.SetValue(1, 0);
                item.SetActive(false);
            }
        }

        if (item.name == "SceneSandStone (1)")
        {
            if (item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("metaq"))
            {
                objectList.SetValue(0, 1);
                objectList.SetValue(1, 3);
                item.SetActive(false);
            }
            else
            {
                objectList.SetValue(1, 1);
                item.SetActive(false);
            }
        }

        if (item.name == "SceneMetaq")
        {
            if (item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("magma_metaq"))
            {
                objectList.SetValue(0, 2);
                objectList.SetValue(1, 6);
                item.SetActive(false);
            }
            else
            {
                objectList.SetValue(1, 2);
                item.SetActive(false);
            }
        }

        if (item.name == "SceneMetaq (1)")
        {
            if (item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("magma_metaq"))
            {
                objectList.SetValue(0, 3);
                objectList.SetValue(1, 7);
                item.SetActive(false);
            }
            else
            {
                objectList.SetValue(1, 3);
                item.SetActive(false);
            }
        }

        if (item.name == "SceneMagma_1")
        {
            if (item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("granite"))
            {
                objectList.SetValue(0, 6);
                objectList.SetValue(1, 4);
                item.SetActive(false);
            }
            else
            {
                objectList.SetValue(1, 6);
                item.SetActive(false);
            }
        }

        if (item.name == "SceneMagma_2")
        {
            if (item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("granite"))
            {
                objectList.SetValue(0, 7);
                objectList.SetValue(1, 5);
                item.SetActive(false);
            }
            else
            {
                objectList.SetValue(1, 7);
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
        else if (iconLocator == 5)
        {
            select_5.SetActive(false);
        }
        else if (iconLocator == 6)
        {
            select_6.SetActive(false);
        }
        else if (iconLocator == 7)
        {
            select_7.SetActive(false);
        }
        else if (iconLocator == 8)
        {
            select_8.SetActive(false);
        }

        if (direction == "left" && iconLocator > 1)
        {
            iconLocator -= 1;
        }

        if (direction == "right" && iconLocator < 8)
        {
            iconLocator += 1;
        }
    }

    void dropItem()
    {
        print("drop");
        if (iconLocator == 5 && GameObject.Find("SceneGranite") == null && granite_1.activeSelf == true)
        {
            CheckAndTake(granite_1, 4);
        }
        else if (iconLocator == 6 && GameObject.Find("SceneGranite (1)") == null && granite_2.activeSelf == true)
        {
            CheckAndTake(granite_2, 5);
        }
        else if (iconLocator == 1 && sandstone_1.activeSelf == true)
        {
            CheckAndTake(sandstone_1, 0);
        }
        else if (iconLocator == 2 && sandstone_2.activeSelf == true)
        {
            CheckAndTake(sandstone_2, 1);
        }
        else if (iconLocator == 3 && metaq_1.activeSelf == true)
        {
            CheckAndTake(metaq_1, 2);
        }
        else if (iconLocator == 4 && metaq_2.activeSelf == true)
        {
            CheckAndTake(metaq_2, 3);
        }
        else if (iconLocator == 7 && magma_1.activeSelf == true)
        {
            CheckAndTake(magma_1, 6);
        }
        else if (iconLocator == 8 && magma_2.activeSelf == true)
        {
            CheckAndTake(magma_2, 7);
        }

        CloseBook();
    }

    void CheckAndTake(GameObject item, int position)
    {
        item.SetActive(false);
        objectList.SetValue(0, position);
        
        if (eventManager.GetComponent<EventManager06>() != null)
        {
            eventManager.GetComponent<EventManager06>().takeFromBag(item);
        }
        else
        {
            eventManager.GetComponent<EventManager06>().takeFromBag(item);
        }

    }

}
