using UnityEngine;
using System.Collections;

public class BigObject : MonoBehaviour {

    public Vector3 playerPosition;
    public DataPlayer.StandingPoints[] avaiblePoints;

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        //GetComponent<BoxCollider>().enabled = false;
        var allChildren = gameObject.GetComponentsInChildren<Collider>();

        foreach (Collider child in allChildren)
        {
            // do whatever with child transform here
            child.enabled = true;
        }
        GetComponent<Collider>().enabled = false;

    }
}
