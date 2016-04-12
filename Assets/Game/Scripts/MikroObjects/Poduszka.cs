using UnityEngine;
using System.Collections;

public class Poduszka : mickroObject {

   /* private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 actPos;
    private bool outOfAction;
	// Use this for initialization
	void Start () {
        startPos = gameObject.transform.position;
        endPos = startPos + new Vector3(0f, 0.5f, 0f);
        actPos = startPos;
        outOfAction = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        if(outOfAction)
        StartCoroutine(MoveObj());
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
        yield return new WaitForSeconds(3f);
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
