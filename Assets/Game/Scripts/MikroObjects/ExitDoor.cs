using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour {

    [SerializeField]
    Item key;
    public GameObject text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        if (Inventory.actualHeldedItem == key)
        {
            Debug.Log("U Fkin Won M8");
            text.SetActive(true);
            Inventory.ItemUsed();
        }
    }
}
