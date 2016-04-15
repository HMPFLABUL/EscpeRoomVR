using UnityEngine;
using System.Collections;

public abstract class mickroObject : MonoBehaviour {


    [SerializeField]
    Item key;
    [SerializeField]
    private bool locked;

    protected Vector3 startPos;
    [SerializeField]
    protected Vector3 movingDirVector;
    protected Vector3 endPos;
    protected Vector3 actPos;
    [SerializeField]
    private bool movable;

    protected bool outOfAction;

    protected virtual void Start()
    {
        
        Debug.Log(movingDirVector);
        startPos = gameObject.transform.localPosition;
        endPos = startPos + movingDirVector;
        actPos = startPos;
        outOfAction = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (locked)
        {
            if (Inventory.actualHeldedItem == key)
            {
                Inventory.ItemUsed(); 
                locked = false;
                if(outOfAction)
                StartCoroutine(Action());
            }
        }
        else
        {
            if(outOfAction)
            StartCoroutine(Action());
        }
      
    }

    protected virtual IEnumerator Action()
    {
        if (movable)
            StartCoroutine(MoveObj());
        yield return null;
    }

    protected virtual IEnumerator ReturnToStart()
    {
        yield return null;
    }

    protected IEnumerator MoveObj()
    {
        outOfAction = false;
        while (actPos != endPos)
        {

            actPos = Vector3.MoveTowards(actPos, endPos, 1f * Time.deltaTime);
            gameObject.transform.localPosition = actPos;
            yield return null;
        }
        yield return StartCoroutine(MoveObjBack());
    }
    protected IEnumerator MoveObjBack()
    {
        yield return new WaitForSeconds(3f);
        while (actPos != startPos)
        {
            actPos = Vector3.MoveTowards(actPos, startPos, 1f * Time.deltaTime);
            gameObject.transform.localPosition = actPos;
            yield return null;
        }
        outOfAction = true;
    }
}
