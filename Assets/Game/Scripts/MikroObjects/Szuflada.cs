using UnityEngine;
using System.Collections;

public class Szuflada : mickroObject {
   
    //protected override IEnumerator Action() { 
       // Debug.Log("Hi");
      //  yield return null;
  //  }
   // void Start()
   // {
     //   Debug.Log("hiii");
   // }


   /* private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 actPos;
    [SerializeField]
    Item key;
    private bool outOfAction;
    // Use this for initialization
    void Start () {
        startPos = gameObject.transform.position;
        endPos = startPos + new Vector3(-0.35f, 0f, 0f);
        actPos = startPos;
        outOfAction = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        if (outOfAction && Inventory.actualHeldedItem == key)
        {
            StartCoroutine(MoveObj());
            Inventory.ItemUsed();
        }
    }

    IEnumerator MoveObj()
    {
        outOfAction = false;
        while (actPos != endPos)
        {
            actPos = Vector3.MoveTowards(actPos, endPos, 1f * Time.deltaTime);
            gameObject.transform.position = actPos;
            yield return null;
        }
        yield return StartCoroutine(MoveObjBack());
    }

    IEnumerator MoveObjBack()
    {
        Item[] arr;
        arr = GetComponentsInChildren<Item>();
        while (arr.Length != 0)
        {
            arr = GetComponentsInChildren<Item>();
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        while (actPos != startPos)
        {
            actPos = Vector3.MoveTowards(actPos, startPos, 1f * Time.deltaTime);
            gameObject.transform.position = actPos;
            yield return null;
        }
        outOfAction = true;
        //yield return null;
    }*/
}
