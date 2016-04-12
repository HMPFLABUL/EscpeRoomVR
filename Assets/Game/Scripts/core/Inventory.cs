using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    //public GameObject[] items;
    public List<Item> items;
    public List<Button> buttons;
    [SerializeField] Sprite buttonBasicSprite;
    public GameObject playerHead;
    public GameObject itemsObj;
    public Item hand;
    private static bool itemUsed = false;
    
    public static Item actualHeldedItem;
	// Use this for initialization
	void Start () {
        items = new List<Item>();
        actualHeldedItem = hand;
        items.Add(hand);
        foreach(Transform child in transform)
        {
            buttons.Add(child.GetComponent<Button>()); 
        }
        Display();
    }
	
	// Update is called once per frame
	void Update () {
        _ItemUsed();
	}

    public void OnItemCLick(Item item)
    {
        if (actualHeldedItem == hand)
        {
            AddToInv(item);
        }

    }

    public void Display()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i;
            if (items.Count > i)
            {
                buttons[i].image.sprite = items[i].sprite;
                buttons[i].interactable = true;
                
                buttons[i].onClick.AddListener(() =>
                {
                    actualHeldedItem.gameObject.SetActive(false);
                    actualHeldedItem = items[index];
                    items[index].gameObject.SetActive(true);
                });
            }
            else
            {
                buttons[i].image.sprite = buttonBasicSprite;
                buttons[i].interactable = false;

            }
            
        }

    }

    public void AddToInv(Item item)
    {
        item.gameObject.SetActive(false);
        item.transform.parent = playerHead.transform;
        item.transform.localPosition = new Vector3(0.2f, -0.2f, 0.4f);
        //item.transform.position = new Vector3(0.4f, -0.6f, 1.25f);
        //item.transform.position+= playerHead.transform.position;
        items.Add(item);
        Display();
    }

    public static void ItemUsed()
    {
        itemUsed = true;
    }

    public void _ItemUsed()
    {
        if (itemUsed)
        {
            actualHeldedItem.gameObject.SetActive(false);
            items.Remove(actualHeldedItem);
            Display();
            actualHeldedItem = hand;
            itemUsed = false;
        }
    }
}
