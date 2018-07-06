using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemScript : MonoBehaviour, ISelectHandler
{
    public Sprite NotFoundSprite;
    public Sprite SelecSprite;
    public Sprite FoundSprite;
    public bool IsFound = false;
    public GameObject FoundInfo;
    public GameObject NotFoundInfo;
    private GameObject Info;
    public bool IsSelected = false;


    void Start()
    {
        Update();
    }

    void Update() {
		if (GameObject.Find ("bag").GetComponent<Animator> ().GetInteger ("rock_collected") > 0 && this.tag == "Rock" &&
			this.name == "Granite") {
			IsFound = true;
		}
			
        if (IsSelected && IsFound) {
            GetComponent<SpriteRenderer>().sprite = SelecSprite;
            Info = FoundInfo;
        }
        else if (IsFound)
        {
            GetComponent<SpriteRenderer>().sprite = FoundSprite;
            Info = FoundInfo;
        }
        else {
            GetComponent<SpriteRenderer>().sprite = NotFoundSprite;
            Info = NotFoundInfo;
        }
    }

    // The info is visible when the mouse is over object
    void OnMouseEnter()
    {
        Info.SetActive(true);
    }

    // The user clicked on the object
    void OnMouseUpAsButton() {
        if (!IsSelected)
        {
            IsSelected = true;
        }
        else {
            IsSelected = false;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
    }

    // Make the info not visible
    void OnMouseExit()
    {
        Info.SetActive(false);
    }
}