using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour
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

	public bool stopMoving;

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
        select_1 = GameObject.Find("SelectIcon_1");
        select_2 = GameObject.Find("SelectIcon_2");
        select_3 = GameObject.Find("SelectIcon_3");
        select_4 = GameObject.Find("SelectIcon_4");

		sandInfo = GameObject.Find ("SandInfo");
		graniteInfo = GameObject.Find("graniteInfo");
        Erase(sandInfo);
        Erase(graniteInfo);

        Erase(granite_1);
        Erase(granite_2);
        Erase(sand_1);
        Erase(sand_2);
        Erase(select_4);
        Erase(select_2);
        Erase(select_3);

        grid = GameObject.Find("InventoryGrid");
        CloseBook();

		stopMoving = false;
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
            Erase(granite_2);
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
		stopMoving = true;
        grid.SetActive(true);
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
				if(GameObject.Find("SceneGranite") == null && granite_1 && granite_1.activeSelf == true){
                    Erase(sandInfo);
                    Put(graniteInfo);
				}
                Put(select_1);
            }
			else if (iconLocator == 2)
			{		
				if(GameObject.Find("SceneGranite (1)") == null && granite_2 && granite_2.activeSelf == true){
                    Erase(sandInfo);
                    Put(graniteInfo);
                }
                Put(select_2);
            }
			else if (iconLocator == 3)
            {
				if(GameObject.Find("SceneSand") == null && sand_1 && sand_1.activeSelf == true){
                    Put(sandInfo);
                    Erase(graniteInfo);
                }

                Put(select_3);
            }
			else if (iconLocator >= 4)
            {
				if(GameObject.Find("SceneSand (1)") == null && sand_2 && sand_2.activeSelf == true){
                    Put(sandInfo);
                    Erase(graniteInfo);
                }
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
			
		if ((int)objectList.GetValue(2) == 1 && (int)objectList.GetValue(3) == 1) {
			twosand = true;
		} else {
			twosand = false;
		}


    }

    public void addObject(GameObject item)
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
            objectList.SetValue(1, 2);
            item.SetActive(false);
        }

        if (item.name == "SceneSand (1)")
        {
            objectList.SetValue(1, 3);
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
        print("drop");
        if (iconLocator <= 1 && GameObject.Find("SceneGranite") == null && granite_1.activeSelf == true)
        {
            CheckAndTake(granite_1, 0);  
        }
        else if (iconLocator == 2 && GameObject.Find("SceneGranite (1)") == null && granite_2.activeSelf == true)
        {
            CheckAndTake(granite_2, 1);
        }
        else if (iconLocator == 3 && sand_1.activeSelf == true)
        {
            CheckAndTake(sand_1, 2);
        }
        else if (iconLocator >= 4 && sand_2.activeSelf == true)
        {
            CheckAndTake(sand_2, 3);
        }

        CloseBook();
    }

    void CheckAndTake(GameObject item, int position) {
        item.SetActive(false);
        objectList.SetValue(0, position);
        if (eventManager.GetComponent<EventManager03>() != null)
        {
            eventManager.GetComponent<EventManager03>().takeFromBag(item);
        }
        else if (eventManager.GetComponent<EventManager02>()) {
            eventManager.GetComponent<EventManager02>().takeFromBag(item);

        } else
        {
            eventManager.GetComponent<EventManager>().takeFromBag(item);
        }
    }

}
